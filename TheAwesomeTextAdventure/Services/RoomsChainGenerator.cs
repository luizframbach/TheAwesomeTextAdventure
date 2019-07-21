using System;
using System.Collections.Generic;
using TheAwesomeTextAdventure.Domain.Rooms;
using TheAwesomeTextAdventure.Services.Abstractions;

namespace TheAwesomeTextAdventure.Services
{
    public class RoomsChainGenerator : IRoomsChainGenerator
    {
        public IList<Room> Rooms { get; }

        public RoomsChainGenerator(List<Room> rooms)
        {
            Rooms = rooms ?? throw new ArgumentNullException(nameof(rooms));
        }

        public IList<Room> GetRooms() => Rooms;
    }
}
