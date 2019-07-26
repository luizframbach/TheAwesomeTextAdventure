using System;
using System.Collections.Generic;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Domain.Enemies;

namespace TheAwesomeTextAdventure.Domain.Rooms
{
    public class BaldnessRoom : Room
    {
        const string _startHistory = "ESSA SALA E BEEEEM ESQUISITA AVENTUREIRO, TOME MUITO CUIDADO POR AONDE VC PASSA";

        const string _endHistory = "VOCE SEGUE EM FRENTE CORRENDO COM MEDO DE TALVEZ SEU BIGODE CAIA DE TANTO MEDO";

        private new static IList<Enemy> Enemies => new List<Enemy>
        {
            new BaldnessMonster()
        };

        public Dictionary<string, Action<Player>> _actionList
            => new Dictionary<string, Action<Player>>
            {
                {"OLHAR PARA OS LADOS", x =>  Console.WriteLine(SearchForAnything())},
                {"SEGUIR EM FRENTE", x => SetFinished()},
            };

        public BaldnessRoom() :
            base(_startHistory,
                _endHistory,
                Enemies)
        {
            SetActions(_actionList);
        }

        private string SearchForAnything()
            => "VOCE NOTA QUE A QUANTIDADE DE CABELO ESPALHADA PELO CHAO E ABSURDAMENTE ABSURDA.. CUIDADO! PODE SER QUE TENHA ALGUEM CARECA POR AI";
    }
}
