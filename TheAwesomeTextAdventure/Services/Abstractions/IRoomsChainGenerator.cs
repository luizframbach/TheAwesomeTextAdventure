using System.Collections.Generic;
using TheAwesomeTextAdventure.Domain.Rooms;

namespace TheAwesomeTextAdventure.Services.Abstractions
{
    public interface IRoomsChainGenerator
    {
        IList<Room> GetShuffledRooms();
    }
}