using TheAwesomeTextAdventure.Domain.Characters;

namespace TheAwesomeTextAdventure.Infrastructure.Readers.Abstractions
{
    public interface IPlayerReader
    {
        Player ReadPlayer();
    }
}