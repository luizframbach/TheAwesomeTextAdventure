using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Domain.Rooms;

namespace TheAwesomeTextAdventure.Handlers.Abstractions
{
    public interface IRoomHandler
    {
        void StartRoomHistory(Room room);
        void EndRoomHistory(Room room);

        void ReadRoomActions(
            Room room,
            Player player,
            string action);
        void ReadPossibleActions(Room room);
    }
}