using TheAwesomeTextAdventure.Domain.Characters;

namespace TheAwesomeTextAdventure.Handlers.Abstractions
{
    public interface IPlayerHandler
    {
        Player CreatePlayer();

        Player LoadPlayer();
    }
}