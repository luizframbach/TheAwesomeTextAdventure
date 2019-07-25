using System;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Handlers.Abstractions;
using TheAwesomeTextAdventure.Infrastructure.Readers.Abstractions;
using TheAwesomeTextAdventure.Wrappers.Abstractions;

namespace TheAwesomeTextAdventure.Handlers
{
    public class PlayerHandler : IPlayerHandler
    {
        public IPlayerReader PlayerReader { get; }

        public IActionWrapper ActionWrapper { get; }

        public PlayerHandler(
            IPlayerReader playerReader,
            IActionWrapper actionWrapper)
        {
            PlayerReader = playerReader ?? throw new ArgumentNullException(nameof(playerReader));
            ActionWrapper = actionWrapper ?? throw new ArgumentNullException(nameof(actionWrapper));
        }

        public Player CreatePlayer()
        {
            StartPlayerCommunication();

            var name = ActionWrapper.ReadLine();

            var player = new Player(name);

            FinishStartPlayerCommunication(player);

            return player;
        }

        public Player LoadPlayer()
            => PlayerReader.Read();

        private static void StartPlayerCommunication()
        {
            Console.WriteLine("BEM VINDO GRANDE AVENTUREIRO!");
            Console.WriteLine("A JORNADA DO SEGREDO DO BIGODE!");
            Console.WriteLine("EU ACABEI ESQUECENDO SEU NOME... PODERIA ME AJUDAR A REELEMBRAR?");
        }

        private static void FinishStartPlayerCommunication(Player player)
        {
            Console.WriteLine("OBRIGADO, ACABEI DE ME LEMBRAR HAHAHAH");
            Console.WriteLine($"BOA SORTE NA SUA JORNADA GRANDE AVENTUREIRO {player.Name}");
        }
    }
}
