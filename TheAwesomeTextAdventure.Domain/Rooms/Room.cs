using System;
using System.Collections.Generic;
using TheAwesomeTextAdventure.Domain.Enemies;

namespace TheAwesomeTextAdventure.Domain.Rooms
{
    public class Room
    {
        public string History { get; }

        public string EndingHistory { get; }

        public IList<Enemy> Enemies { get; }

        public Room(
            string history,
            string endingHistory,
            IList<Enemy> enemies)
        {
            History = history ?? throw new ArgumentNullException(nameof(history));
            EndingHistory = endingHistory ?? throw new ArgumentNullException(nameof(endingHistory));
            Enemies = enemies ?? throw new ArgumentNullException(nameof(enemies));
        }
    }
}