using System;
using System.Collections.Generic;
using System.Linq;
using TheAwesomeTextAdventure.Domain.Rooms;
using TheAwesomeTextAdventure.Services.Abstractions;

namespace TheAwesomeTextAdventure.Services
{
    public class RoomsChainGenerator : IRoomsChainGenerator
    {
        public IList<Room> Rooms { get; }

        public Room BossRoom { get; }

        public IRandomNumberGenerator RandomNumberGenerator { get; }

        public RoomsChainGenerator(
            List<Room> rooms,
            Room bossRoom,
            IRandomNumberGenerator randomNumberGenerator)
            
        {
            Rooms = rooms ?? throw new ArgumentNullException(nameof(rooms));
            BossRoom = bossRoom ?? throw new ArgumentNullException(nameof(bossRoom));
            RandomNumberGenerator = randomNumberGenerator ?? throw new ArgumentNullException(nameof(randomNumberGenerator));
        }

        public IList<Room> GetShuffledRooms()
        {
            var shuffledRooms = Rooms.Select(x => new
            {
                Rank = RandomNumberGenerator.Next(), Room = x
            });

            var roomsOrderByRank = 
                shuffledRooms
                    .OrderBy(r => r.Rank)
                    .Select(x => x.Room)
                    .ToList();

            roomsOrderByRank.Add(BossRoom);

            return roomsOrderByRank;
        }
    }
}
