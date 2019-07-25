using System;
using System.Diagnostics.CodeAnalysis;
using TheAwesomeTextAdventure.Wrappers.Abstractions;

namespace TheAwesomeTextAdventure.Wrappers
{
    [ExcludeFromCodeCoverage]
    public class ExitWrapper : IExitWrapper
    {
        public void Exit()
            => Environment.Exit(0);
    }
}
