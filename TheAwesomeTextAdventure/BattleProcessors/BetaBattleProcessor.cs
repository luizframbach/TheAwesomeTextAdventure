using System;
using TheAwesomeTextAdventure.BattleProcessors.Abstractions;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Domain.Enemies;
using TheAwesomeTextAdventure.Domain.Rooms;
using TheAwesomeTextAdventure.Wrappers.Abstractions;

namespace TheAwesomeTextAdventure.BattleProcessors
{
    public class BetaBattleProcessor : IBattleProcessor
    {
        public IActionWrapper ActionWrapper { get; }

        public BetaBattleProcessor(
            IActionWrapper actionWrapper)
        {
            ActionWrapper = actionWrapper 
                            ?? throw new ArgumentNullException(nameof(actionWrapper));
        }

        public void StartBattle(
            Player player,
            Room room)
        {
            foreach (var enemy in room.Enemies)
            {
                Console.WriteLine(enemy.EnemyHistory);

                Console.WriteLine("VOCE NOTA QUE SEU RIVAL TEM APARELHOS AUDITIVOS, DA PARA TIRAR UMA OPORTUNIDADE DISSO");

                ReadPossibleActions(enemy);

                while (enemy.Defeat == false)
                {
                    ReadPlayerActions(enemy, player);
                }

                room.SetFinished();
            }
        }

        private void ReadPossibleActions(Enemy enemy)
        {
            Console.WriteLine("ESSAS SAO AS POSSIVEIS AÇOES CONTRA O INIMIGO");

            foreach (var action in enemy.ActionList)
            {
                Console.WriteLine(action.Key);
            }
        }

        private void ReadPlayerActions(
            Enemy enemy, Player player)
        {
            var action = Console.ReadLine();

            if (enemy.ActionList.ContainsKey(action) == false)
            {
                Console.WriteLine("NAO CONSIGO ENTENDER SUA AÇAO, TENTE NOVAMENTE");
                return;
            }

            enemy.ActionList[action].Invoke(player);
        }
    }
}
