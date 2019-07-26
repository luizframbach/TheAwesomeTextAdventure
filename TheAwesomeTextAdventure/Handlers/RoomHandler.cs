using System;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Domain.Rooms;
using TheAwesomeTextAdventure.Handlers.Abstractions;

namespace TheAwesomeTextAdventure.Handlers
{
    public class RoomHandler : IRoomHandler
    {
        public void StartRoomHistory(Room room)
        {
            Console.WriteLine(room.History);
        }

        public void EndRoomHistory(Room room)
        {
            Console.WriteLine(room.EndingHistory);
        }

        public void ReadRoomActions(
            Room room,
            Player player,
            string action)
        {
            if (room.ActionList.ContainsKey(action) == false)
            {
                Console.WriteLine("NAO CONSIGO ENTENDER SUA AÇAO, TENTE NOVAMENTE");
                return;
            }

            room.ActionList[action].Invoke(player);
        }

        public void ReadPossibleActions(Room room)
        {
            Console.WriteLine("ESSAS SAO AS POSSIVEIS AÇOES DA SALA");

            foreach (var action in room.ActionList)
            {
                Console.WriteLine(action.Key);
            }
        }
    }
}
