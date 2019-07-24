using System;

namespace TheAwesomeTextAdventure.Domain.Configurations
{
    public class GeneralConfiguration
    {
        public string SavePath { get; }

        public string SavePathWithPlayerArchive { get; }

        public GeneralConfiguration(
            string savePath,
            string savePathWithPlayerArchive)
        {
            SavePath = savePath ?? throw new ArgumentNullException(nameof(savePath));
            SavePathWithPlayerArchive = savePathWithPlayerArchive ?? throw new ArgumentNullException(nameof(savePathWithPlayerArchive));
        }
    }
}
