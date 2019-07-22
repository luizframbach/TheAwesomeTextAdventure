using AutoFixture.Idioms;
using NSubstitute;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Processors;
using TheAwesomeTextAdventure.Processors.Abstractions;
using TheAwesomeTextAdventure.UnitTests.AutoFixture;
using Xunit;

namespace TheAwesomeTextAdventure.UnitTests.TheAwesomeTextAdventure.Processors
{
    public class AdventureProcessorTests
    {
        [Theory, AutoNSubstituteData]
        public void Sut_ShouldGuardItsClause(GuardClauseAssertion assertion)
            => assertion.Verify(typeof(AdventureProcessor).GetConstructors());

        [Theory, AutoNSubstituteData]
        public void Sut_Is_IAdventureProcessor(AdventureProcessor sut)
            => Assert.IsAssignableFrom<IAdventureProcessor>(sut);

        [Theory, AutoNSubstituteData]
        public void StartGame_WhenActionIsSIM_ShouldCallRomsProcessor(
            Player player,
            AdventureProcessor sut)
        {
            sut.ActionWrapper.ReadLine().Returns("SIM");

            sut.StartAdventure(player);

            sut.RoomsProcessor.Received().StartProcessing(player);
        }

        [Theory, AutoNSubstituteData]
        public void StartGame_WhenActionIsNAO_ShouldNotCallRomsProcessor(
            Player player,
            AdventureProcessor sut)
        {
            sut.ActionWrapper.ReadLine().Returns("NAO");

            sut.StartAdventure(player);

            sut.RoomsProcessor.DidNotReceive().StartProcessing(player);

            sut.ExitWrapper.Received().Exit();
        }
    }
}
