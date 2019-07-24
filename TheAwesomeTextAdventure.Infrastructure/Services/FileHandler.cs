using System.Diagnostics.CodeAnalysis;
using System.IO;
using TheAwesomeTextAdventure.Infrastructure.Services.Abstractions;

namespace TheAwesomeTextAdventure.Infrastructure.Services
{
    [ExcludeFromCodeCoverage]
    public class FileHandler : IFileHandler
    {
        public bool Exists(string path)
            => File.Exists(path);

        public StreamWriter CreateText(string path)
            => File.CreateText(path);

        public void Delete(string path)
            => File.Delete(path);

        public StreamReader OpenText(string path)
            => File.OpenText(path);
    }
}
