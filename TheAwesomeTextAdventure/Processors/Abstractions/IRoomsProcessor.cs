using TheAwesomeTextAdventure.Domain.Characters;

namespace TheAwesomeTextAdventure.Processors.Abstractions
{
    public interface IRoomsProcessor
    {
        void StartProcessing(Player player);
    }
}