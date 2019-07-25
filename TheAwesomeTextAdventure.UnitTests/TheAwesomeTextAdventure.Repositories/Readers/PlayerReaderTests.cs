using AutoFixture.Idioms;
using TheAwesomeTextAdventure.Infrastructure.Readers;
using TheAwesomeTextAdventure.Infrastructure.Readers.Abstractions;
using TheAwesomeTextAdventure.UnitTests.AutoFixture.Attributes;
using Xunit;

namespace TheAwesomeTextAdventure.UnitTests.TheAwesomeTextAdventure.Repositories.Readers
{
    public class PlayerReaderTests
    {
        [Theory, AutoNSubstituteData]
        public void Sut_ShouldGuardItsClause(GuardClauseAssertion assertion)
            => assertion.Verify(typeof(PlayerReader).GetConstructors());

        [Theory, AutoNSubstituteData]
        public void Sut_Is_IPlayerReader(PlayerReader sut)
            => Assert.IsAssignableFrom<IPlayerReader>(sut);
    }
}
