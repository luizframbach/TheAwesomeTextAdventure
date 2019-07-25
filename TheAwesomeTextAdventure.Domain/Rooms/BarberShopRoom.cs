using System;
using System.Collections.Generic;
using TheAwesomeTextAdventure.Domain.Characters;
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

        public Dictionary<string, Action<Player>> _actionList
            => new Dictionary<string, Action<Player>>
            {
                {"1", x => SetFinished()},
            };

        public BarberShopRoom() : base(
            _startHistory,
            _endHistory,
            Enemies)
        {
            SetActions(_actionList);
        }
    }
}
