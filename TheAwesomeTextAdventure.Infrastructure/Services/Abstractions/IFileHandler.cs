using System.IO;

namespace TheAwesomeTextAdventure.Infrastructure.Services.Abstractions
{
    public interface IFileHandler
    {
        bool Exists(string path);
        StreamWriter CreateText(string path);
        void Delete(string path);
        StreamReader OpenText(string path);
    }
}