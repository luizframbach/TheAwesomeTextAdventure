using System;
using System.Collections.Generic;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Infrastructure.Writers.Abstractions;
using TheAwesomeTextAdventure.Services.Abstractions;

namespace TheAwesomeTextAdventure.Processors
{
    public class BaseProcessor
    {
        public IPlayerWriter PlayerWriter { get; }

        public IActionWrapper ActionWrapper { get; }

        public IExitWrapper ExitWrapper { get; }

        private int count = 0;

        public BaseProcessor(
            IPlayerWriter playerWriter,
            IActionWrapper actionWrapper,
            IExitWrapper exitWrapper)
        {
            PlayerWriter = playerWriter ?? throw new ArgumentNullException(nameof(playerWriter));
            ActionWrapper = actionWrapper ?? throw new ArgumentNullException(nameof(actionWrapper));
            ExitWrapper = exitWrapper ?? throw new ArgumentNullException(nameof(exitWrapper));
        }

        public void ReadAction(
            Dictionary<string, Action> possibleActions)
        {
            count++;

            var action = ActionWrapper.ReadLine();

            if (possibleActions.ContainsKey(action) == false)
            {
                if (count == 20)
                {
                    Console.WriteLine("DESCULPA, TO FICANDO COM MEDO, TEREI QUE IR EMBORA..");
                    Exit();
                }
                
                Console.WriteLine($"NÃO CONSIGO ENTENDER O QUE QUER FAZER - {action}");
                ReadAction(possibleActions);
            }

            possibleActions[action].Invoke();
        }

        public void Exit()
            => ExitWrapper.Exit();

        public void SaveProcess(Player player)
            => PlayerWriter.Write(player);
    }
}
