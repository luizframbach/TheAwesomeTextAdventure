using System.Collections.Generic;
using TheAwesomeTextAdventure.Domain.Enemies;

namespace TheAwesomeTextAdventure.Domain.Rooms
{
    public class FirstRoom : Room
    {
        const string _startHistory = "First room starts";

        const string _endHistory = "First room end";

        public static IList<Enemy> Enemies => new List<Enemy>();

        public FirstRoom() : base(_startHistory, _endHistory, Enemies)
        {
        }
    }
}
