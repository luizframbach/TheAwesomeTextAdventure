using System.Collections.Generic;
using TheAwesomeTextAdventure.Domain.Enemies;

namespace TheAwesomeTextAdventure.Domain.Rooms
{
    public class BarberShopRoom : Room
    {
        const string _startHistory = "Uma Barbearia abandonada!";

        const string _endHistory = "barber room end";

        public new static IList<Enemy> Enemies => new List<Enemy>
        {
            new AngryBarber()
        };

        public BarberShopRoom() : base(_startHistory, _endHistory, Enemies)
        {
        }
    }
}
