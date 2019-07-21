using System;
using System.Collections.Generic;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Infrastructure.Writers.Abstractions;

namespace TheAwesomeTextAdventure.Processor
{
    public class BaseProcessor
    {
        public IPlayerWriter PlayerWriter { get; } 

        public BaseProcessor(IPlayerWriter playerWriter)
        {
            PlayerWriter = playerWriter ?? throw new ArgumentNullException(nameof(playerWriter));
        }

        protected void ReadAction(
            Dictionary<string, Action> possibleActions)
        {
            var action = Console.ReadLine().ToUpper();

            if (possibleActions.ContainsKey(action) == false)
            {
                Console.WriteLine($"NÃO CONSIGO ENTENDER O QUE QUER FAZER - {action}");
                ReadAction(possibleActions);
            }

            possibleActions[action].Invoke();
        }

        protected void Exit()
            => Environment.Exit(0);

        protected void SaveProcess(Player player)
            => PlayerWriter.WritePlayer(player);
    }
}
