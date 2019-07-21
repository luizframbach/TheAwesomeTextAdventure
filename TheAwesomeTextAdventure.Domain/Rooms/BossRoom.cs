using System.Collections.Generic;
using TheAwesomeTextAdventure.Domain.Enemies;

namespace TheAwesomeTextAdventure.Domain.Rooms
{
    public class BossRoom : Room
    {
        const string _startHistory = "Boss room start";

        const string _endHistory = "boom room end";

        public static IList<Enemy> Enemies => new List<Enemy>
        {
            new Rival()
        };

        public BossRoom() : base(_startHistory, _endHistory, Enemies)
        {
        }
    }
}
