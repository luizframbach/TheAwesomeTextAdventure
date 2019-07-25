using System;
using System.Collections.Generic;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Domain.Enemies;

namespace TheAwesomeTextAdventure.Domain.Rooms
{
    public class FirstRoom : Room
    {
        const string _startHistory = "First room starts";

        const string _endHistory = "First room end";

        public new static IList<Enemy> Enemies => new List<Enemy>();

        public Dictionary<string, Action<Player>> _actionList
            => new Dictionary<string, Action<Player>>
            {
                { "1", x => SetFinished() },
            };

        public FirstRoom() : base(
            _startHistory,
            _endHistory,
            Enemies)
        {
            SetActions(_actionList);
        }
    }
}
