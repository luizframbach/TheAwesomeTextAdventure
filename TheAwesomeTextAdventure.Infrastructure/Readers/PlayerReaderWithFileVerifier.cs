using System;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Infrastructure.Readers.Abstractions;
using TheAwesomeTextAdventure.Infrastructure.Services.Abstractions;

namespace TheAwesomeTextAdventure.Infrastructure.Readers
{
    public class PlayerReaderWithFileVerifier : IPlayerReader
    {
        public IPlayerReader PlayerReader { get; }

        public IConfigurationReader ConfigurationReader { get; }

        public IFileHandler FileHandler { get; }

        public PlayerReaderWithFileVerifier(
            IPlayerReader playerReader,
            IConfigurationReader configurationReader,
            IFileHandler fileHandler)
        {
            PlayerReader = playerReader ?? throw new ArgumentNullException(nameof(playerReader));
            ConfigurationReader = configurationReader ?? throw new ArgumentNullException(nameof(configurationReader));
            FileHandler = fileHandler ?? throw new ArgumentNullException(nameof(fileHandler));
        }

        public Player Read()
        {
            var playerFilePath = ConfigurationReader.ReadSavePathWithPlayerArchive();

            if (FileHandler.Exists(playerFilePath) == false)
                return null;

            return PlayerReader.Read();
        }
    }
}
