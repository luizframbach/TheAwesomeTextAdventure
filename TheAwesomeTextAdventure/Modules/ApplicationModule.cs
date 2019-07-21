using Microsoft.Extensions.Configuration;
using SimpleInjector;
using TheAwesomeTextAdventure.Modules.Abstractions;
using TheAwesomeTextAdventure.Processor;
using TheAwesomeTextAdventure.Processor.Abstractions;
using TheAwesomeTextAdventure.Services;
using TheAwesomeTextAdventure.Services.Abstractions;

namespace TheAwesomeTextAdventure.Modules
{
    public class ApplicationModule : IModule
    {
        public void Load(Container container, IConfiguration configuration)
        {
            container.Register<IAdventureProcessor, AdventureProcessor>();
            container.Register<IAdventureInitializer, AdventureInitializer>();

            container.Register<IPlayerHandler, PlayerHandler>();

            container.Register<IRoomsProcessor, RoomsProcessor>();
        }
    }
}
