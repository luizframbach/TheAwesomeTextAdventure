using Microsoft.Extensions.Configuration;
using SimpleInjector;
using TheAwesomeTextAdventure.Domain.Configurations;
using TheAwesomeTextAdventure.Infrastructure.Readers;
using TheAwesomeTextAdventure.Infrastructure.Readers.Abstractions;
using TheAwesomeTextAdventure.Infrastructure.Serializers;
using TheAwesomeTextAdventure.Infrastructure.Serializers.Abstractions;
using TheAwesomeTextAdventure.Infrastructure.Services;
using TheAwesomeTextAdventure.Infrastructure.Services.Abstractions;
using TheAwesomeTextAdventure.Infrastructure.Writers;
using TheAwesomeTextAdventure.Infrastructure.Writers.Abstractions;
using TheAwesomeTextAdventure.Modules.Abstractions;

namespace TheAwesomeTextAdventure.Modules
{
    public class InfrastructureModule : IModule
    {
        public void Load(Container container, IConfiguration configuration)
        {

            container.Register<IFileHandler, FileHandler>();
            container.Register<IDirectoryHandler, DirectoryHandler>();
            container.Register<ICustomSerialization, CustomJsonSerializer>();
            container.Register<IConfigurationReader>(
                () => new ConfigurationReader(
                    new GeneralConfiguration(
                        "C:\\TheAwesomeTextAdventure\\Saves",
                        "C:\\TheAwesomeTextAdventure\\Saves\\Player.txt")));

           //PlayerWriter 
           container.Register<IPlayerWriter, PlayerWriter>();
           container.RegisterDecorator<IPlayerWriter, PlayerWriterWithFileVerifier>();
           container.RegisterDecorator<IPlayerWriter, PlayerWriterWithFileDirectoryValidator>();
           container.RegisterDecorator<IPlayerWriter, PlayerWriterWithErrorHandler>();
           
           //PlayerReader
           container.Register<IPlayerReader, PlayerReader>();
           container.RegisterDecorator<IPlayerReader, PlayerReaderWithFileVerifier>();
           container.RegisterDecorator<IPlayerReader, PlayerReaderWithFileDirectoryValidator>();
           container.RegisterDecorator<IPlayerReader, PlayerReaderWithErrorHandler>();
        }
    }
}
