using TheAwesomeTextAdventure.Domain.Characters;

namespace TheAwesomeTextAdventure.Infrastructure.Writers.Abstractions
{
    public interface IPlayerWriter
    {
        void WritePlayer(Player player);
    }
}