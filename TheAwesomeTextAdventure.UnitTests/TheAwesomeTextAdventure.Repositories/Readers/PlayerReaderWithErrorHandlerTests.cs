using AutoFixture.Idioms;
using NSubstitute;
using TheAwesomeTextAdventure.Infrastructure.Readers;
using TheAwesomeTextAdventure.Infrastructure.Readers.Abstractions;
using TheAwesomeTextAdventure.UnitTests.AutoFixture.Attributes;
using Xunit;

namespace TheAwesomeTextAdventure.UnitTests.TheAwesomeTextAdventure.Repositories.Readers
{
    public class PlayerReaderWithErrorHandlerTests
    {
        [Theory, AutoNSubstituteData]
        public void Sut_ShouldGuardItsClause(GuardClauseAssertion assertion)
            => assertion.Verify(typeof(PlayerReaderWithErrorHandler).GetConstructors());

        [Theory, AutoNSubstituteData]
        public void Sut_Is_IPlayerWriter(PlayerReaderWithErrorHandler sut)
            => Assert.IsAssignableFrom<IPlayerReader>(sut);

        [Theory, AutoNSubstituteData]
        public void ReadPlayer_ShouldCallPlayerReader(
            PlayerReaderWithErrorHandler sut)
        {
            sut.Read();

            sut.PlayerReader.Received().Read();
        }
    }
}
