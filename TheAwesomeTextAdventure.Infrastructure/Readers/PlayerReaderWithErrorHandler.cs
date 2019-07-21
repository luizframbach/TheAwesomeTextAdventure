using System;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Infrastructure.Readers.Abstractions;

namespace TheAwesomeTextAdventure.Infrastructure.Readers
{
    public class PlayerReaderWithErrorHandler : IPlayerReader
    {
        public IPlayerReader PlayerReader { get; }

        public PlayerReaderWithErrorHandler(IPlayerReader playerReader)
        {
            PlayerReader = playerReader ?? throw new ArgumentNullException(nameof(playerReader));
        }

        public Player ReadPlayer()
        {
            try
            {
                return PlayerReader.ReadPlayer();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
