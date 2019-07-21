using System.Collections.Generic;
using TheAwesomeTextAdventure.Domain.Enemies;

namespace TheAwesomeTextAdventure.Domain.Rooms
{
    public class Shopping : Room
    {
        const string _startHistory = "BEM VINDO A LOJA!";

        const string _endHistory = "VOLTE SEMPRE!";

        public static IList<Enemy> Enemies => new List<Enemy>();

        public Shopping() : base(_startHistory, _endHistory, Enemies)
        {
        }
    }
}