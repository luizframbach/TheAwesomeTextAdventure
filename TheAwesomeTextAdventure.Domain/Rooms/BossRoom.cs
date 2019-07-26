using System;
using System.Collections.Generic;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Domain.Enemies;

namespace TheAwesomeTextAdventure.Domain.Rooms
{
    public class BossRoom : Room
    {
        const string _startHistory = "FINALMENTE VOCE CHEGA NA ULTIMA SALA, E ENCONTRA UMA PESSOA COM UM BIGODE LINDO DE MORRER, COM CERTEZA E SEU RIVAL! VAI LA E DERROTE ELE E TENHA O BIGODE MAIS LINDO DO MUNDO";

        const string _endHistory = "PARABENS VOCE É O GRANDE BIGODUDO, A PESSOA QUE POSSUI O BIGODE MAIS LINDO DO MUNDO!";

        private const string _battleHistory =
            "VOCE CORRE EM DIREÇAO AO SEU RIVAl, PARA SE TENTAR DERROTA-LO";

        public new static IList<Enemy> Enemies => new List<Enemy>
        {
            new Rival()
        };

        public Dictionary<string, Action<Player>> _actionList
            => new Dictionary<string, Action<Player>>
            {
                {"OLHAR PARA OS LADOS", x =>  Console.WriteLine(SearchForAnything())},
                {"ENFRENTAR O RIVAL", x => SetBattleOn()}
            };

        public BossRoom() : base(
            _startHistory,
            _endHistory,
            Enemies)
        {
            SetActions(_actionList);
        }

        private string SearchForAnything()
            => "VOCE TENTA OLHAR PELA SALA, PARA TENTAR ACHAR ALGUM MEIO DE DERROTAR SEU ADVERSARIO MAS PARECE SER MEIO IMPOSSIVEL";
    }
}
