using AutoFixture.Idioms;
using TheAwesomeTextAdventure.Processors;
using TheAwesomeTextAdventure.Processors.Abstractions;
using TheAwesomeTextAdventure.UnitTests.AutoFixture;
using Xunit;

namespace TheAwesomeTextAdventure.UnitTests.TheAwesomeTextAdventure.Processors
{
    public class RoomsProcessorTests
    {
        [Theory, AutoNSubstituteData]
        public void Sut_ShouldGuardItsClause(GuardClauseAssertion assertion)
            => assertion.Verify(typeof(RoomsProcessor).GetConstructors());

        [Theory, AutoNSubstituteData]
        public void Sut_Is_IRoomsProcessor(RoomsProcessor sut)
            => Assert.IsAssignableFrom<IRoomsProcessor>(sut);

    }
}
