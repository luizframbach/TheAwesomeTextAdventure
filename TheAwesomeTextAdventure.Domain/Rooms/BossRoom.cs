using System;
using System.Collections.Generic;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Domain.Enemies;

namespace TheAwesomeTextAdventure.Domain.Rooms
{
    public class BossRoom : Room
    {
        const string _startHistory = "Boss room start";

        const string _endHistory = "PARABENS VOCE É O GRANDE BIGODUDO, A PESSOA QUE POSSUI O BIGODE MAIS LINDO DO MUNDO!";

        public new static IList<Enemy> Enemies => new List<Enemy>
        {
            new Rival()
        };

        public Dictionary<string, Action<Player>> _actionList
            => new Dictionary<string, Action<Player>>
            {
                { "1", x => SetFinished() },
            };

        public BossRoom() : base(
            _startHistory,
            _endHistory,
            Enemies)
        {
            SetActions(_actionList);
        }
    }
}
