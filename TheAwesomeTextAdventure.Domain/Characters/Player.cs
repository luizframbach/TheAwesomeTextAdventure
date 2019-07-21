using System.Collections.Generic;
using TheAwesomeTextAdventure.Domain.Consumables;

namespace TheAwesomeTextAdventure.Domain.Characters
{
    public class Player
    {
        public string Name { get; }

        public int Health { get; }

        public string Weapon { get; }

        public List<Consumable> Consumables { get; }

        public Player(string name)
        {
            Name = name;
            Health = 20;
            Weapon = null;
            Consumables = new List<Consumable>();
        }
    }
}
