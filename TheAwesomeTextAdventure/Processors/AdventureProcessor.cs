using System;
using System.Collections.Generic;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Infrastructure.Writers.Abstractions;
using TheAwesomeTextAdventure.Processors.Abstractions;
using TheAwesomeTextAdventure.Wrappers.Abstractions;

namespace TheAwesomeTextAdventure.Processors
{
    public class AdventureProcessor : BaseProcessor, IAdventureProcessor
    {
        public IRoomsProcessor RoomsProcessor { get; }

        private Player _player;

        private Dictionary<string, Action> _actionList
            => new Dictionary<string, Action>
            {
                { "SIM", YesAction},
                { "NAO", NoAction}
            };

        public AdventureProcessor(
            IPlayerWriter playerWriter,
            IActionWrapper actionWrapper,
            IExitWrapper exitWrapper,
            IRoomsProcessor roomsProcessor) : base(playerWriter, actionWrapper, exitWrapper)
        {
            RoomsProcessor = roomsProcessor ?? throw new ArgumentNullException(nameof(roomsProcessor));
        }

        public void StartAdventure(Player player)
        {
            _player = player;

            StartAdventureHistory(player.Name);

            ReadAction(_actionList);
        }

        private void StartAdventureHistory(string playerName)
        {
            Console.WriteLine($"ENTAO {playerName}...");
            Console.WriteLine("ESSA JORNADA É A INCRIVEL JORNADA PARA DESCOBRIR OS VERDADEIROS SEGREDOS DO BIGODE");
            Console.WriteLine("QUEM NUNCA QUIS TER UM GRANDE BIGODE DE RESPEITO NE? HAHAHAH");
            Console.WriteLine("ENTÃO HÁ BOATOS QUE SE VOCE CHEGAR ATÉ O FINAL DAS SALAS...");
            Console.WriteLine("VOCE ENCONTRARÁ O SEU GRANDE RIVAL, QUEM SERIA ELE? A PESSOA QUE JÁ POSSUI O BIGODE MAIS MAGNIFICO DE TODOS!");
            Console.WriteLine("VOCE TEM CERTEZA QUE IRÁ ATRAS DO SEU SONHO?");
        }

        private void YesAction()
        {
            Console.WriteLine("ENTÃO VÁ ATE O FINAL DAS SALAS, DERROTE SEU RIVAL E DESCUBRA O SEGREDO QUE TE DARÁ O MELHOR BIGODE JAMAIS VISTO");

            RoomsProcessor.StartProcessing(_player);
        } 
        
        private void NoAction()
        {
            Console.WriteLine("AH.. QUE PENA.. BOA SORTE NA PROXIMA..");
            Exit();
        }
    }
}
