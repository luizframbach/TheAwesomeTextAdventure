using AutoFixture.Idioms;
using NSubstitute;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Processors;
using TheAwesomeTextAdventure.Processors.Abstractions;
using TheAwesomeTextAdventure.UnitTests.AutoFixture.Attributes;
using Xunit;

namespace TheAwesomeTextAdventure.UnitTests.TheAwesomeTextAdventure.Processors
{
    public class AdventureInitializerTests
    {
        [Theory, AutoNSubstituteData]
        public void Sut_ShouldGuardItsClause(GuardClauseAssertion assertion)
            => assertion.Verify(typeof(AdventureInitializer).GetConstructors());

        [Theory, AutoNSubstituteData]
        public void Sut_Is_IAdventureInitializer(AdventureInitializer sut)
            => Assert.IsAssignableFrom<IAdventureInitializer>(sut);

        [Theory, AutoNSubstituteData]
        public void StartGame_WhenActionIsNovoJogo_ShouldCallPlayerHandlerCreateAndAdventureProcessor(
            Player player,
            AdventureInitializer sut)
        {
            sut.ActionWrapper.ReadLine().Returns("NOVO JOGO");

            sut.PlayerHandler.CreatePlayer().Returns(player);

            sut.StartGame();

            sut.PlayerHandler.Received().CreatePlayer();

            sut.AdventureProcessor.Received().StartAdventure(player);
        }

        [Theory, AutoNSubstituteData]
        public void StartGame_WhenActionIsCarregarJogoSalvo_ShouldCallPlayerHandlerLoadAndAdventureProcessor(
            Player player,
            AdventureInitializer sut)
        {
            sut.ActionWrapper.ReadLine().Returns("CARREGAR JOGO SALVO");

            sut.PlayerHandler.LoadPlayer().Returns(player);

            sut.StartGame();

            sut.PlayerHandler.Received().LoadPlayer();

            sut.AdventureProcessor.Received().StartAdventure(player);
        }

        [Theory, AutoNSubstituteData]
        public void StartGame_WhenActionIsSair_ShouldCallExitWrapper(
            Player player,
            AdventureInitializer sut)
        {
            sut.ActionWrapper.ReadLine().Returns("SAIR");

            sut.StartGame();

            sut.ExitWrapper.Received().Exit();
        }
    }
}
