using System;
using System.Diagnostics.CodeAnalysis;
using TheAwesomeTextAdventure.Wrappers.Abstractions;

namespace TheAwesomeTextAdventure.Wrappers
{
    [ExcludeFromCodeCoverage]
    public class ActionWrapper : IActionWrapper
    {
        public string ReadLine()
            => Console.ReadLine().ToUpper();
    }
}
