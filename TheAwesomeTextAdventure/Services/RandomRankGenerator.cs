using System;
using TheAwesomeTextAdventure.Services.Abstractions;

namespace TheAwesomeTextAdventure.Services
{
    public class RandomRankGenerator : IRandomRankGenerator
    {
        public int Next() => new Random().Next();
    }
}
