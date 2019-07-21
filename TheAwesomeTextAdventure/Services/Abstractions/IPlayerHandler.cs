using TheAwesomeTextAdventure.Domain.Characters;

namespace TheAwesomeTextAdventure.Services.Abstractions
{
    public interface IPlayerHandler
    {
        Player CreatePlayer();

        Player LoadPlayer();
    }
}