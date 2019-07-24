using System;
using TheAwesomeTextAdventure.Domain.Configurations;
using TheAwesomeTextAdventure.Infrastructure.Readers.Abstractions;

namespace TheAwesomeTextAdventure.Infrastructure.Readers
{
    public class ConfigurationReader : IConfigurationReader
    {
        public GeneralConfiguration GeneralConfiguration { get; }

        public ConfigurationReader(GeneralConfiguration generalConfiguration)
        {
            GeneralConfiguration = generalConfiguration ?? throw new ArgumentNullException(nameof(generalConfiguration));
        }

        public string ReadSavePath()
            => GeneralConfiguration.SavePath;

        public string ReadSavePathWithPlayerArchive()
            => GeneralConfiguration.SavePathWithPlayerArchive;
    }
}
