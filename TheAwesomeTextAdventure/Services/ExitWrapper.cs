using System;
using System.Diagnostics.CodeAnalysis;
using TheAwesomeTextAdventure.Services.Abstractions;

namespace TheAwesomeTextAdventure.Services
{
    [ExcludeFromCodeCoverage]
    public class ExitWrapper : IExitWrapper
    {
        public void Exit()
            => Environment.Exit(0);
    }
}
