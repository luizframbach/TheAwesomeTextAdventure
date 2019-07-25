using Microsoft.Extensions.Configuration;
using SimpleInjector;
using System;
using TheAwesomeTextAdventure.Extensions;
using TheAwesomeTextAdventure.Modules;
using TheAwesomeTextAdventure.Processors.Abstractions;

namespace TheAwesomeTextAdventure
{
    public class Program
    {
        private static Container container;

        public static void Main(string[] args)
        {
            ConfigureInjectionContainer();

            StarMenu();

            var adventureInitializer = container.GetInstance<IAdventureInitializer>();
            adventureInitializer.StartGame();
        }

        private static void StarMenu()
        {
            Console.WriteLine("O SEGREDO DO BIGODE ");
            Console.WriteLine("░░░░░░░░▄▄▄▄▄░░░░░▄▄▄▄▄░░░░░░░░░ \n" +
                              "░░░░░▄█████████▄█████████▄░░░░░░ \n" +
                              "░░▄█████████████████████████▄░░░ \n" +
                              "████████████████████████████████ \n" +
                              "██████████████▀░▀███████████████ \n" +
                              "████████████▀░░░░░▀█████████████ \n" +
                              "░▀▀▀▀▀▀▀▀▀░░░░░░░░░░░▀▀▀▀▀▀▀▀▀░░ \n");
            Console.WriteLine("O QUE VOCE GOSTARIA DE FAZER? (DIGITE EXATAMENTE A AÇÃO INDICADA)");
            Console.WriteLine("- NOVO JOGO");
            Console.WriteLine("- CARREGAR JOGO SALVO");
            Console.WriteLine("- SAIR");
        }

        private static void ConfigureInjectionContainer()
        {
            IConfiguration config = new ConfigurationBuilder()
                .Build();

            container = new Container();

            container.RegisterModule<ApplicationModule>(config);
            container.RegisterModule<InfrastructureModule>(config);

            container.Verify();
        }
    }
}
