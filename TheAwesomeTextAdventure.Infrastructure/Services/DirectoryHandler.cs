using System.Diagnostics.CodeAnalysis;
using System.IO;
using TheAwesomeTextAdventure.Infrastructure.Services.Abstractions;

namespace TheAwesomeTextAdventure.Infrastructure.Services
{
    [ExcludeFromCodeCoverage]
    public class DirectoryHandler : IDirectoryHandler
    {
        public bool Exists(string path)
            => Directory.Exists(path);

        public void CreateDirectory(string path)
            => Directory.CreateDirectory(path);
    }
}
