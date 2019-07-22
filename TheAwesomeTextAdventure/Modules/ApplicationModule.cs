using Microsoft.Extensions.Configuration;
using SimpleInjector;
using TheAwesomeTextAdventure.Modules.Abstractions;
using TheAwesomeTextAdventure.Processors;
using TheAwesomeTextAdventure.Processors.Abstractions;
using TheAwesomeTextAdventure.Services;
using TheAwesomeTextAdventure.Services.Abstractions;

namespace TheAwesomeTextAdventure.Modules
{
    public class ApplicationModule : IModule
    {
        public void Load(Container container, IConfiguration configuration)
        {
            container.Register<IAdventureInitializer, AdventureInitializer>();
            container.Register<IAdventureProcessor, AdventureProcessor>();
            container.Register<IRoomsProcessor, RoomsProcessor>();

            container.Register<IPlayerHandler, PlayerHandler>();

            container.Register<IActionWrapper, ActionWrapper>();
            container.Register<IExitWrapper, ExitWrapper>();
        }
    }
}
