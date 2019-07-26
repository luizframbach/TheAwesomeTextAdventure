using System;
using System.Collections.Generic;
using TheAwesomeTextAdventure.BattleProcessors.Abstractions;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Extensions;
using TheAwesomeTextAdventure.Handlers.Abstractions;
using TheAwesomeTextAdventure.Infrastructure.Writers.Abstractions;
using TheAwesomeTextAdventure.Processors.Abstractions;
using TheAwesomeTextAdventure.Services.Abstractions;
using TheAwesomeTextAdventure.Wrappers.Abstractions;

namespace TheAwesomeTextAdventure.Processors
{
    public class RoomsProcessor : BaseProcessor, IRoomsProcessor
    {
        public IRoomsChainGenerator RoomsChainGenerator { get; }

        public IRoomHandler RoomHandler { get; }

        public IBattleProcessor BattleProcessor { get; }

        private Dictionary<string, Action<Player>> _actionList
            => new Dictionary<string, Action<Player>>
            {
                { "SALVAR", SaveProcess },
                { "SAIR", x => Exit() },
            };

        public RoomsProcessor(
            IPlayerWriter playerWriter,
            IActionWrapper actionWrapper,
            IExitWrapper exitWrapper, 
            IRoomsChainGenerator roomsChainGenerator, 
            IRoomHandler roomHandler,
            IBattleProcessor battleProcessor) : base(playerWriter, actionWrapper, exitWrapper)
        {
            RoomsChainGenerator = roomsChainGenerator ?? throw new ArgumentNullException(nameof(roomsChainGenerator));
            RoomHandler = roomHandler ?? throw new ArgumentNullException(nameof(roomHandler));
            BattleProcessor = battleProcessor ?? throw new ArgumentNullException(nameof(battleProcessor));
        }

        public void StartProcessing(Player player)
        {
            var rooms = RoomsChainGenerator.GetShuffledRooms();

            foreach (var room in rooms)
            {
                room.ActionList.AddRange(_actionList);

                RoomHandler.StartRoomHistory(room);

                RoomHandler.ReadPossibleActions(room);

                while (room.Finished == false)
                {
                    RoomHandler.ReadRoomActions(room, player, ActionWrapper.ReadLine());

                    if (room.StartBattle)
                        BattleProcessor.StartBattle(player, room);
                }

                RoomHandler.EndRoomHistory(room);
            }
        }
    }
}
