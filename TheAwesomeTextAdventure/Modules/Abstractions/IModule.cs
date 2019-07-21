using Microsoft.Extensions.Configuration;
using SimpleInjector;

namespace TheAwesomeTextAdventure.Modules.Abstractions
{
    public interface IModule
    {
        void Load(Container container, IConfiguration configuration);
    }
}
