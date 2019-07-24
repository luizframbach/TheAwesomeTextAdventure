using System;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Infrastructure.Readers.Abstractions;
using TheAwesomeTextAdventure.Infrastructure.Services.Abstractions;

namespace TheAwesomeTextAdventure.Infrastructure.Readers
{
    public class  PlayerReaderWithFileDirectoryValidator : IPlayerReader
    {
        public IPlayerReader PlayerReader { get; }

        public IConfigurationReader ConfigurationReader { get; }

        public IDirectoryHandler DirectoryHandler { get; }

        public PlayerReaderWithFileDirectoryValidator(
            IPlayerReader playerReader,
            IConfigurationReader configurationReader,
            IDirectoryHandler directoryHandler)
        {
            PlayerReader = playerReader ?? throw new ArgumentNullException(nameof(playerReader));
            ConfigurationReader = configurationReader ?? throw new ArgumentNullException(nameof(configurationReader));
            DirectoryHandler = directoryHandler ?? throw new ArgumentNullException(nameof(directoryHandler));
        }

        public Player Read()
        {
            var savePath = ConfigurationReader.ReadSavePath();

            if (DirectoryHandler.Exists(savePath) == false)
                DirectoryHandler.CreateDirectory(savePath);

            return PlayerReader.Read();
        }
    }
}
