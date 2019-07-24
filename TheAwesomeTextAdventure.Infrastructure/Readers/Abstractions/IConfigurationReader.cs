namespace TheAwesomeTextAdventure.Infrastructure.Readers.Abstractions
{
    public interface IConfigurationReader
    {
        string ReadSavePath();
        string ReadSavePathWithPlayerArchive();
    }
}