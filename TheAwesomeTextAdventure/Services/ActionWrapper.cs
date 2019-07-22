using System;
using System.Diagnostics.CodeAnalysis;
using TheAwesomeTextAdventure.Services.Abstractions;

namespace TheAwesomeTextAdventure.Services
{
    [ExcludeFromCodeCoverage]
    public class ActionWrapper : IActionWrapper
    {
        public string ReadLine()
            => Console.ReadLine().ToUpper();
    }
}
