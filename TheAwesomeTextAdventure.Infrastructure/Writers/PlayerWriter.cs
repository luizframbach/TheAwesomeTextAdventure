using System;
using System.IO;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Infrastructure.Serializers.Abstractions;
using TheAwesomeTextAdventure.Infrastructure.Writers.Abstractions;

namespace TheAwesomeTextAdventure.Infrastructure.Writers
{
    public class PlayerWriter : IPlayerWriter
    {
        public ICustomSerialization CustomSerialization { get; }

        public string SavePath { get; }

        public PlayerWriter(
            ICustomSerialization customSerialization,
            string savePath)
        {
            CustomSerialization = customSerialization ?? throw new ArgumentNullException(nameof(customSerialization));
            SavePath = savePath ?? throw new ArgumentNullException(nameof(savePath));
        }

        public void WritePlayer(Player player)
        {
            if (Directory.Exists(SavePath) == false)
                Directory.CreateDirectory(SavePath);

            if (!File.Exists(SavePath))
            {
                using (StreamWriter sw = File.CreateText(SavePath))
                {
                    sw.WriteLine("Hello");
                    sw.WriteLine("And");
                    sw.WriteLine("Welcome");
                }
            }
        }
    }
}
