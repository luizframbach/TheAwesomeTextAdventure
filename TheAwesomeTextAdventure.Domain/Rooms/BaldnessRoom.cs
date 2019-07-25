using System;
using System.Collections.Generic;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Domain.Enemies;

namespace TheAwesomeTextAdventure.Domain.Rooms
{
    public class BaldnessRoom : Room
    {
        const string _startHistory = "Uma caverna estranha, com restos de cabelo por toda parte";

        const string _endHistory = "baldness room end";

        private new static IList<Enemy> Enemies => new List<Enemy>
        {
            new BaldnessMonster()
        };

        public Dictionary<string, Action<Player>> _actionList
            => new Dictionary<string, Action<Player>>
            {
                { "1", x => SetFinished() },
            };

        public BaldnessRoom() :
            base(_startHistory,
                _endHistory,
                Enemies)
        {
            SetActions(_actionList);
        }
    }
}
