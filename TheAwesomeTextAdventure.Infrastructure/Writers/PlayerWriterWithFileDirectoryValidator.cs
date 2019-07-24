using System;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Infrastructure.Readers.Abstractions;
using TheAwesomeTextAdventure.Infrastructure.Services.Abstractions;
using TheAwesomeTextAdventure.Infrastructure.Writers.Abstractions;

namespace TheAwesomeTextAdventure.Infrastructure.Writers
{
    public class PlayerWriterWithFileDirectoryValidator : IPlayerWriter
    {
        public IPlayerWriter PlayerWriter { get; }

        public IConfigurationReader ConfigurationReader { get; }

        public IDirectoryHandler DirectoryHandler { get; }

        public PlayerWriterWithFileDirectoryValidator(
            IPlayerWriter playerWriter,
            IConfigurationReader configurationReader,
            IDirectoryHandler directoryHandler)
        {
            PlayerWriter = playerWriter ?? throw new ArgumentNullException(nameof(playerWriter));
            ConfigurationReader = configurationReader ?? throw new ArgumentNullException(nameof(configurationReader));
            DirectoryHandler = directoryHandler ?? throw new ArgumentNullException(nameof(directoryHandler));
        }

        public void Write(Player player)
        {
            var savePath = ConfigurationReader.ReadSavePath();

            if (DirectoryHandler.Exists(savePath) == false)
                DirectoryHandler.CreateDirectory(savePath);

            PlayerWriter.Write(player);
        }
    }
}
