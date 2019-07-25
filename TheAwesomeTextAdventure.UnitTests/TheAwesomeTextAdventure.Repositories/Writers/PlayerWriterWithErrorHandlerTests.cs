using AutoFixture.Idioms;
using NSubstitute;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Infrastructure.Writers;
using TheAwesomeTextAdventure.Infrastructure.Writers.Abstractions;
using TheAwesomeTextAdventure.UnitTests.AutoFixture.Attributes;
using Xunit;

namespace TheAwesomeTextAdventure.UnitTests.TheAwesomeTextAdventure.Repositories.Writers
{
    public class PlayerWriterWithErrorHandlerTests
    {
        [Theory, AutoNSubstituteData]
        public void Sut_ShouldGuardItsClause(GuardClauseAssertion assertion)
            => assertion.Verify(typeof(PlayerWriterWithErrorHandler).GetConstructors());

        [Theory, AutoNSubstituteData]
        public void Sut_Is_IPlayerWriter(PlayerWriterWithErrorHandler sut)
            => Assert.IsAssignableFrom<IPlayerWriter>(sut);

        [Theory, AutoNSubstituteData]
        public void WritePlayer_ShouldCallPlayerWriter(
            Player player,
            PlayerWriterWithErrorHandler sut)
        {
            sut.Write(player);

            sut.PlayerWriter.Received().Write(player);
        }
    }
}
