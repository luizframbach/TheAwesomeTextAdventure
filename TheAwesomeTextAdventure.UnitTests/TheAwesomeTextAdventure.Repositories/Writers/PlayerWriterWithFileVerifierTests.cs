using AutoFixture.Idioms;
using NSubstitute;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Infrastructure.Writers;
using TheAwesomeTextAdventure.Infrastructure.Writers.Abstractions;
using TheAwesomeTextAdventure.UnitTests.AutoFixture.Attributes;
using Xunit;

namespace TheAwesomeTextAdventure.UnitTests.TheAwesomeTextAdventure.Repositories.Writers
{
    public class PlayerWriterWithFileVerifierTests
    {
        [Theory, AutoNSubstituteData]
        public void Sut_ShouldGuardItsClause(GuardClauseAssertion assertion)
            => assertion.Verify(typeof(PlayerWriterWithFileVerifier).GetConstructors());

        [Theory, AutoNSubstituteData]
        public void Sut_Is_IPlayerWriter(PlayerWriterWithFileVerifier sut)
            => Assert.IsAssignableFrom<IPlayerWriter>(sut);

        [Theory, AutoNSubstituteData]
        public void Write_WhenFileExists_ShouldCallDelete(
            Player player,
            string path,
            PlayerWriterWithFileVerifier sut)
        {
            sut.ConfigurationReader.ReadSavePathWithPlayerArchive().Returns(path);

            sut.FileHandler.Exists(path).Returns(true);

            sut.Write(player);

            sut.FileHandler.Received().Delete(path);

            sut.PlayerWriter.Received().Write(player);
        }

        [Theory, AutoNSubstituteData]
        public void Write_WhenFileNotExists_ShouldNotCallDelete(
            Player player,
            string path,
            PlayerWriterWithFileVerifier sut)
        {
            sut.ConfigurationReader.ReadSavePathWithPlayerArchive().Returns(path);

            sut.FileHandler.Exists(path).Returns(false);

            sut.Write(player);

            sut.FileHandler.DidNotReceive().Delete(path);

            sut.PlayerWriter.Received().Write(player);
        }
    }
}
