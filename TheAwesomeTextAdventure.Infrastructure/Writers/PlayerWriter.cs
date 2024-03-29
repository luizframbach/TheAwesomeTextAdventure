﻿using System;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Infrastructure.Readers.Abstractions;
using TheAwesomeTextAdventure.Infrastructure.Serializers.Abstractions;
using TheAwesomeTextAdventure.Infrastructure.Services.Abstractions;
using TheAwesomeTextAdventure.Infrastructure.Writers.Abstractions;

namespace TheAwesomeTextAdventure.Infrastructure.Writers
{
    public class PlayerWriter : IPlayerWriter
    {
        public ICustomSerialization CustomSerialization { get; }

        public IConfigurationReader ConfigurationReader { get; }

        public IFileHandler FileHandler { get; }

        public PlayerWriter(
            ICustomSerialization customSerialization,
            IConfigurationReader configurationReader,
            IFileHandler fileHandler)
        {
            CustomSerialization = customSerialization ?? throw new ArgumentNullException(nameof(customSerialization));
            ConfigurationReader = configurationReader ?? throw new ArgumentNullException(nameof(configurationReader));
            FileHandler = fileHandler ?? throw new ArgumentNullException(nameof(fileHandler));
        }

        public void Write(Player player)
        {
            var serializedPlayer = CustomSerialization.Serialize(player);

            using (var sw = FileHandler.CreateText(ConfigurationReader.ReadSavePath()))
            {
                sw.Write(serializedPlayer);
            }
        }
    }
}
