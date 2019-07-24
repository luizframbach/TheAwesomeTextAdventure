using AutoFixture.Idioms;
using NSubstitute;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Processors;
using TheAwesomeTextAdventure.UnitTests.AutoFixture;
using Xunit;

namespace TheAwesomeTextAdventure.UnitTests.TheAwesomeTextAdventure.Processors
{
    public class BaseProcessorTests
    {
        [Theory, AutoNSubstituteData]
        public void Sut_ShouldGuardItsClause(GuardClauseAssertion assertion)
            => assertion.Verify(typeof(BaseProcessor).GetConstructors());

        [Theory, AutoNSubstituteData]
        public void Sut_Is_IAdventureProcessor(BaseProcessor sut)
            => Assert.IsAssignableFrom<BaseProcessor>(sut);

        [Theory, AutoNSubstituteData]
        public void Exit_ShouldCallExitWrapper(BaseProcessor sut)
        {
           sut.Exit();

           sut.ExitWrapper.Received().Exit();
        }

        [Theory, AutoNSubstituteData]
        public void SaveProcess_ShouldCallPlayerWriter(
            Player player,
            BaseProcessor sut)
        { 
            sut.SaveProcess(player);

            sut.PlayerWriter.Received().Write(player);
        }
    }
}
