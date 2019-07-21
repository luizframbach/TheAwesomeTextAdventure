using System.Collections.Generic;
using TheAwesomeTextAdventure.Domain.Enemies;

namespace TheAwesomeTextAdventure.Domain.Rooms
{
    public class BaldnessRoom : Room
    {
        const string _startHistory = "Uma caverna estranha, com restos de cabelo por toda parte";

        const string _endHistory = "baldness room end";

        public new static IList<Enemy> Enemies => new List<Enemy>
        {
            new BaldnessMonster()
        };

        public BaldnessRoom() : base(_startHistory, _endHistory, Enemies)
        {
        }
    }
}
