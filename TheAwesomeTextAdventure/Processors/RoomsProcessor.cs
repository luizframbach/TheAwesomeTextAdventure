using System;
using System.Collections.Generic;
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
            IRoomHandler roomHandler) : base(playerWriter, actionWrapper, exitWrapper)
        {
            RoomsChainGenerator = roomsChainGenerator ?? throw new ArgumentNullException(nameof(roomsChainGenerator));
            RoomHandler = roomHandler ?? throw new ArgumentNullException(nameof(roomHandler));
        }

        public void StartProcessing(Player player)
        {
            var rooms = RoomsChainGenerator.GetShuffledRooms();

            foreach (var room in rooms)
            {
                room.ActionList.AddRange(_actionList);

                RoomHandler.StartRoomHistory(room);

                while (room.Finished == false)
                {
                    RoomHandler.ReadRoomActions(room, player, ActionWrapper.ReadLine());
                }

                RoomHandler.EndRoomHistory(room);
            }
        }
    }
}
