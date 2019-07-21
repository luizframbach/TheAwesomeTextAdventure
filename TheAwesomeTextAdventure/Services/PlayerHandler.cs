using System;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Infrastructure.Readers.Abstractions;
using TheAwesomeTextAdventure.Services.Abstractions;

namespace TheAwesomeTextAdventure.Services
{
    public class PlayerHandler : IPlayerHandler
    {
        public IPlayerReader PlayerReader { get; }
        
        public PlayerHandler(
            IPlayerReader playerReader)
        {
            PlayerReader = playerReader ?? throw new ArgumentNullException(nameof(playerReader));
        }

        public Player CreatePlayer()
        {
            StartPlayerCommunication();

            var name = Console.ReadLine();

            var player = new Player(name);

            FinishStartPlayerCommunication(player);

            return player;
        }

        public Player LoadPlayer()
            => PlayerReader.ReadPlayer();

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
