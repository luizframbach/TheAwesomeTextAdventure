using Microsoft.Extensions.Configuration;
using SimpleInjector;
using System.Collections.Generic;
using TheAwesomeTextAdventure.BattleProcessors;
using TheAwesomeTextAdventure.BattleProcessors.Abstractions;
using TheAwesomeTextAdventure.Domain.Rooms;
using TheAwesomeTextAdventure.Handlers;
using TheAwesomeTextAdventure.Handlers.Abstractions;
using TheAwesomeTextAdventure.Modules.Abstractions;
using TheAwesomeTextAdventure.Processors;
using TheAwesomeTextAdventure.Processors.Abstractions;
using TheAwesomeTextAdventure.Services;
using TheAwesomeTextAdventure.Services.Abstractions;
using TheAwesomeTextAdventure.Wrappers;
using TheAwesomeTextAdventure.Wrappers.Abstractions;

namespace TheAwesomeTextAdventure.Modules
{
    public class ApplicationModule : IModule
    {
        public void Load(Container container, IConfiguration configuration)
        {
            //Processors
            container.Register<IAdventureInitializer, AdventureInitializer>();
            container.Register<IAdventureProcessor, AdventureProcessor>();
            container.Register<IRoomsProcessor, RoomsProcessor>();

            //Handlers
            container.Register<IPlayerHandler, PlayerHandler>();
            container.Register<IRoomHandler, RoomHandler>();

            //Wrappers
            container.Register<IActionWrapper, ActionWrapper>();
            container.Register<IExitWrapper, ExitWrapper>();

            //Services
            container.Register<IRandomNumberGenerator, RandomNumberGenerator>();
            container.Register<IRoomsChainGenerator>(() =>
                    new RoomsChainGenerator(
                        new List<Room>
                        {
                            new BaldnessRoom(),
                            new BarberShopRoom()
                        },
                        new BossRoom(),
                        container.GetInstance<IRandomNumberGenerator>())
            );

            //BattleProcessors
            container.Register<IBattleProcessor, BetaBattleProcessor>();
        }
    }
}
