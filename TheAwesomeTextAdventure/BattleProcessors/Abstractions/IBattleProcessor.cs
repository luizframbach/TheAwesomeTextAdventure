using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Domain.Rooms;

namespace TheAwesomeTextAdventure.BattleProcessors.Abstractions
{
    public interface IBattleProcessor
    {
        void StartBattle(Player player, Room room);
    }
}
