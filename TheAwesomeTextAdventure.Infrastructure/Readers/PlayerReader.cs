using System;
using System.IO;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Infrastructure.Readers.Abstractions;
using TheAwesomeTextAdventure.Infrastructure.Serializers.Abstractions;

namespace TheAwesomeTextAdventure.Infrastructure.Readers
{
    public class PlayerReader : IPlayerReader
    {
        public ICustomSerialization CustomSerialization { get; }

        public string SavePath { get; }

        public PlayerReader(
            ICustomSerialization customSerialization, 
            string savePath)
        {
            CustomSerialization = customSerialization ?? throw new ArgumentNullException(nameof(customSerialization));
            SavePath = savePath ?? throw new ArgumentNullException(nameof(savePath));
        }

        public Player ReadPlayer()
        {
            if (!File.Exists(SavePath))
                return null;

            using (StreamReader sr = File.OpenText(SavePath))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }

            return new Player("steste");
        }
    }
}
