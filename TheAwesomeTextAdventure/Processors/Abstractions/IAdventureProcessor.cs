using TheAwesomeTextAdventure.Domain.Characters;

namespace TheAwesomeTextAdventure.Processors.Abstractions
{
    public interface IAdventureProcessor
    {
        void StartAdventure(Player player);
    }
}