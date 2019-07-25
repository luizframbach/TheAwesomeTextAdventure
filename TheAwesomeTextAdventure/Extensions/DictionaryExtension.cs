using System;
using System.Collections.Generic;
using TheAwesomeTextAdventure.Domain.Characters;

namespace TheAwesomeTextAdventure.Extensions
{
    public static class DictionaryExtension
    {
        public static void AddRange(
            this Dictionary<string, Action<Player>> source,
            Dictionary<string, Action<Player>> collection)
        {
            foreach (var (key, value) in collection)
            {
                if (!source.ContainsKey(key))
                {
                    source.Add(key, value);
                }
            }
        }
    }
}
