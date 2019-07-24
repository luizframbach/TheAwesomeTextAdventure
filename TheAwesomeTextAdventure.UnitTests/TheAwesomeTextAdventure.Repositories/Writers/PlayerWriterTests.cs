using AutoFixture.Idioms;
using NSubstitute;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Infrastructure.Writers;
using TheAwesomeTextAdventure.Infrastructure.Writers.Abstractions;
using TheAwesomeTextAdventure.UnitTests.AutoFixture;
using Xunit;

namespace TheAwesomeTextAdventure.UnitTests.TheAwesomeTextAdventure.Repositories.Writers
{
    public class PlayerWriterTests
    {
        [Theory, AutoNSubstituteData]
        public void Sut_ShouldGuardItsClause(GuardClauseAssertion assertion)
            => assertion.Verify(typeof(PlayerWriter).GetConstructors());

        [Theory, AutoNSubstituteData]
        public void Sut_Is_IPlayerWriter(PlayerWriter sut)
            => Assert.IsAssignableFrom<IPlayerWriter>(sut);

        [Theory, AutoNSubstituteData]
        public void Write_ShouldInvokePipeLineCorrectly(
            Player player,
            PlayerWriter sut)
        {
            sut.Write(player);

            sut.CustomSerialization.Received().Serialize(player);

            sut.ConfigurationReader.Received().ReadSavePath();
        }
    }
}
