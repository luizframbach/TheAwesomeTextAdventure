using System;
using System.Collections.Generic;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Domain.Enemies;

namespace TheAwesomeTextAdventure.Domain.Rooms
{
    public class Room
    {
        public string History { get; }

        public string EndingHistory { get; }

        public IList<Enemy> Enemies { get; }

        public Dictionary<string, Action<Player>> ActionList { get; private set; }

        public bool Finished { get; private set; }

        public bool StartBattle { get; private set; }

        public Room(
            string history,
            string endingHistory,
            IList<Enemy> enemies)
        {
            History = history ?? throw new ArgumentNullException(nameof(history));
            EndingHistory = endingHistory ?? throw new ArgumentNullException(nameof(endingHistory));
            Enemies = enemies ?? throw new ArgumentNullException(nameof(enemies));
            ActionList = new Dictionary<string, Action<Player>>();
            Finished = false;
            StartBattle = false;
        }

        public void SetFinished()
            => Finished = true;

        public void SetBattleOn()
            => StartBattle = true;

        public void SetActions(Dictionary<string, Action<Player>> actionList)
            => ActionList = actionList;
    }
}