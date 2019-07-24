using System;
using System.Diagnostics.CodeAnalysis;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Infrastructure.Readers.Abstractions;
using TheAwesomeTextAdventure.Infrastructure.Serializers.Abstractions;
using TheAwesomeTextAdventure.Infrastructure.Services.Abstractions;

namespace TheAwesomeTextAdventure.Infrastructure.Readers
{
    public class PlayerReader : IPlayerReader
    {
        public ICustomSerialization CustomSerialization { get; }

        public IConfigurationReader ConfigurationReader { get; }

        public IFileHandler FileHandler { get; }

        public PlayerReader(
            ICustomSerialization customSerialization,
            IConfigurationReader configurationReader,
            IFileHandler fileHandler)
        {
            CustomSerialization = customSerialization ?? throw new ArgumentNullException(nameof(customSerialization));
            ConfigurationReader = configurationReader ?? throw new ArgumentNullException(nameof(configurationReader));
            FileHandler = fileHandler ?? throw new ArgumentNullException(nameof(fileHandler));
        }

        [ExcludeFromCodeCoverage]
        public Player Read()
        {
            var path = ConfigurationReader.ReadSavePathWithPlayerArchive();

            using (var sr = FileHandler.OpenText(path))
            {
                var contentArchive = sr.ReadLine();

                var player = CustomSerialization.Deserialize(contentArchive, typeof(Player));

                return (Player)player;
            }
        }
    }
}
