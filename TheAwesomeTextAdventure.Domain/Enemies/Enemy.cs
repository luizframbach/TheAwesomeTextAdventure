using System;
using System.Collections.Generic;
using TheAwesomeTextAdventure.Domain.Characters;

namespace TheAwesomeTextAdventure.Domain.Enemies
{
    public class Enemy
    {
        public string EnemyHistory { get; }

        public Dictionary<string, Action<Player>> ActionList { get; private set; }

        public bool Defeat { get; private set; }

        public Enemy(
            string enemyHistory)
        {
            EnemyHistory = enemyHistory ?? throw new ArgumentNullException(nameof(enemyHistory));
            ActionList = new Dictionary<string, Action<Player>>();
            Defeat = false;
        }

        public void SetActions(Dictionary<string, Action<Player>> actionList)
            => ActionList = actionList;

        public void SetDefeated()
            => Defeat = true;
    }
}
