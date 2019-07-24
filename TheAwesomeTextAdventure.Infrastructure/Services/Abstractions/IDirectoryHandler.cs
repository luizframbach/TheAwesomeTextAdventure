namespace TheAwesomeTextAdventure.Infrastructure.Services.Abstractions
{
    public interface IDirectoryHandler
    {
        bool Exists(string path);
        void CreateDirectory(string path);
    }
}