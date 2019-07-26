using System;
using System.Collections.Generic;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Domain.Enemies;

namespace TheAwesomeTextAdventure.Domain.Rooms
{
    public class BarberShopRoom : Room
    {
        const string _startHistory = "ESTA SALA PARECE UMA BARBEARIA ABANDONADA, COM DESTROÇOS E RESTOS DE CABELO PARA TODO LADO, CUIDADO POR ONDE ANDA AVENTUREIRO";

        const string _endHistory = "VOCE SEGUIU EM FRENTE, MESMO COM MUITOS OBSTACULOS E SUJEIRA E CONSEGUIU IR PARA A OUTRA SALA";

        public new static IList<Enemy> Enemies => new List<Enemy>
        {
            new AngryBarber() 
        };

        public Dictionary<string, Action<Player>> _actionList
            => new Dictionary<string, Action<Player>>
            {
                {"OLHAR PARA OS LADOS", x =>  Console.WriteLine(SearchForAnything())},
                {"SEGUIR EM FRENTE", x => SetFinished()},
            };

        public BarberShopRoom() : base(
            _startHistory,
            _endHistory,
            Enemies)
        {
            SetActions(_actionList);
        }

        private string SearchForAnything()
            => "VOCE OLHA PARA TODO LADO TENTANDO ACHAR ALGUMA PISTA, MAS SO ENCONTRA EQUIPAMENTO VELHO E MUITO CABELO";
    }
}
