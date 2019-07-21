using Microsoft.Extensions.Configuration;
using SimpleInjector;
using TheAwesomeTextAdventure.Infrastructure.Readers;
using TheAwesomeTextAdventure.Infrastructure.Readers.Abstractions;
using TheAwesomeTextAdventure.Infrastructure.Writers;
using TheAwesomeTextAdventure.Infrastructure.Writers.Abstractions;
using TheAwesomeTextAdventure.Modules.Abstractions;

namespace TheAwesomeTextAdventure.Modules
{
    public class InfrastructureModule : IModule
    {
        public void Load(Container container, IConfiguration configuration)
        {
           container.Register<IPlayerWriter, PlayerWriter>();
           container.RegisterDecorator<IPlayerWriter, PlayerWriterWithErrorHandler>();
           
           container.Register<IPlayerReader, PlayerReader>();
           container.RegisterDecorator<IPlayerReader, PlayerReaderWithErrorHandler>();
        }
    }
}
