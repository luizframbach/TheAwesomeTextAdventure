using System;
using System.Collections.Generic;
using TheAwesomeTextAdventure.Domain.Characters;

namespace TheAwesomeTextAdventure.Domain.Enemies
{
    public class Rival : Enemy
    {
        private const string _enemyHistory = "ENTAO VOCE QUER TER O BIGODE MAIS LINDO DO MUNDO?? BOA SORTE EM TENTAR TIRAR ELE DE MIM";

        public Dictionary<string, Action<Player>> _actionList
            => new Dictionary<string, Action<Player>>
            {
                {"GRITAR", x =>
                    {
                        Console.WriteLine(
                            "VOCE GRITA BEM ALTO, FAZENDO O SEU RIVAL DESMAIAR E CAIR DE CARA NO CHAO ASSIM DANIFICANDO SEU LINDO BIGODE");
                        SetDefeated();
                    }
                }
            };

        public Rival() : base(_enemyHistory)
        {
            SetActions(_actionList);
        }
    }
}