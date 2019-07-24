using System;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Infrastructure.Readers.Abstractions;
using TheAwesomeTextAdventure.Infrastructure.Services.Abstractions;
using TheAwesomeTextAdventure.Infrastructure.Writers.Abstractions;

namespace TheAwesomeTextAdventure.Infrastructure.Writers
{
    public class PlayerWriterWithFileVerifier : IPlayerWriter
    {
        public IPlayerWriter PlayerWriter { get; }

        public IConfigurationReader ConfigurationReader { get; }

        public IFileHandler FileHandler { get; }

        public PlayerWriterWithFileVerifier(
            IPlayerWriter playerWriter,
            IConfigurationReader configurationReader, 
            IFileHandler fileHandler)
        {
            PlayerWriter = playerWriter ?? throw new ArgumentNullException(nameof(playerWriter));
            ConfigurationReader = configurationReader ?? throw new ArgumentNullException(nameof(configurationReader));
            FileHandler = fileHandler ?? throw new ArgumentNullException(nameof(fileHandler));
        }

        public void Write(Player player)
        {
            var playerFilePath = ConfigurationReader.ReadSavePathWithPlayerArchive();

            if (FileHandler.Exists(playerFilePath))
                FileHandler.Delete(playerFilePath);

            PlayerWriter.Write(player);
        }
    }
}
