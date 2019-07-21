using System;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Domain.Rooms;

namespace TheAwesomeTextAdventure.Services
{
    public class RoomHandler
    {
        public Room Room { get; }

        public Player Player { get; }

        public RoomHandler(
            Room room,
            Player player)
        {
            Room = room ?? throw new ArgumentNullException(nameof(room));
            Player = player ?? throw new ArgumentNullException(nameof(player));
        }

        public void StartRoomHistory()
        {
            Console.WriteLine(Room.History);
        }

        public void EndRoomHistory()
        {
            Console.WriteLine(Room.EndingHistory);
        }

        public void ReadRoomActions(string action)
        {

        }

        public void StartBattle()
        {

        }

        public void GetItem()
        {

        }
    }
}
