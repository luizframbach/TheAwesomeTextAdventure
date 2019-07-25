using System;
using System.Diagnostics.CodeAnalysis;
using TheAwesomeTextAdventure.Services.Abstractions;

namespace TheAwesomeTextAdventure.Services
{
    [ExcludeFromCodeCoverage]
    public class RandomRankGenerator : IRandomRankGenerator
    {
        public int Next() => new Random().Next();
    }
}
