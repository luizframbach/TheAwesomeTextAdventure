using TheAwesomeTextAdventure.Domain.Characters;

namespace TheAwesomeTextAdventure.Processor.Abstractions
{
    public interface IAdventureProcessor
    {
        void StartAdventure(Player player);
    }
}