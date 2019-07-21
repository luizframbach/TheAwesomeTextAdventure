using System;
using System.Collections.Generic;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Infrastructure.Writers.Abstractions;
using TheAwesomeTextAdventure.Processor.Abstractions;

namespace TheAwesomeTextAdventure.Processor
{
    public class AdventureProcessor : BaseProcessor, IAdventureProcessor
    {
        public IRoomsProcessor RoomsProcessor { get; }

        public AdventureProcessor(
            IPlayerWriter playerWriter,
            IRoomsProcessor roomsProcessor) : base(playerWriter)
        {
            RoomsProcessor = roomsProcessor ?? throw new ArgumentNullException(nameof(roomsProcessor));
        }

        private Dictionary<string, Action> _actionList
            => new Dictionary<string, Action>
            {
                { "SIM", YesAction},
                { "NAO", FinishGame}
            };

        public void StartAdventure(Player player)
        {
            StartAdventureHistory(player.Name);

            ReadAction(_actionList);

            RoomsProcessor.StartProcessing(player);
        }

        private void StartAdventureHistory(string playerName)
        {
            Console.WriteLine($"ENTAO {playerName}...");
            Console.WriteLine("ESSA JORNADA É A INCRIVEL JORNADA PARA DESCOBRIR OS VERDADEIROS SEGREDOS DO BIGODE");
            Console.WriteLine("QUEM NUNCA QUIS TER UM GRANDE BIGODE DE RESPEITO NE? HAHAHAH");
            Console.WriteLine("ENTÃO HÁ BOATOS QUE SE VOCE CHEGAR ATÉ O FINAL DAS SALAS...");
            Console.WriteLine("VOCE ENCONTRARÁ O SEU GRANDE RIVAL, QUEM SERIA ELE? A PESSOA QUE JÁ POSSUE O BIGODE MAIS MAGNIFICO DE TODOS!");
            Console.WriteLine("VOCE TEM CERTEZA QUE IRÁ ATRAS DO SEU SONHO?");
        }

        private void YesAction()
            => Console.WriteLine("ENTÃO VÁ ATE O FINAL DAS SALAS, DERROTE SEU RIVAL E DESCUBRA O SEGREDO QUE TE DARÁ O MELHOR BIGODE JAMAIS VISTO");
        
        private void FinishGame()
        {
            Console.WriteLine("AH.. QUE PENA.. BOA SORTE NA PROXIMA..");
            Exit();
        }
    }
}
