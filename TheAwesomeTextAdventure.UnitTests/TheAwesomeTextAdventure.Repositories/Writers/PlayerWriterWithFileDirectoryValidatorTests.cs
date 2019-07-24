using AutoFixture.Idioms;
using NSubstitute;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Infrastructure.Writers;
using TheAwesomeTextAdventure.Infrastructure.Writers.Abstractions;
using TheAwesomeTextAdventure.UnitTests.AutoFixture;
using Xunit;

namespace TheAwesomeTextAdventure.UnitTests.TheAwesomeTextAdventure.Repositories.Writers
{
    public class PlayerWriterWithFileDirectoryValidatorTests
    {
        [Theory, AutoNSubstituteData]
        public void Sut_ShouldGuardItsClause(GuardClauseAssertion assertion)
            => assertion.Verify(typeof(PlayerWriterWithFileDirectoryValidator).GetConstructors());

        [Theory, AutoNSubstituteData]
        public void Sut_Is_IPlayerWriter(PlayerWriterWithFileDirectoryValidator sut)
            => Assert.IsAssignableFrom<IPlayerWriter>(sut);

        [Theory, AutoNSubstituteData]
        public void Write_WhenDirectoryNotExists_ShouldCallCreateDirectory(
            Player player,
            string path,
            PlayerWriterWithFileDirectoryValidator sut)
        {
            sut.ConfigurationReader.ReadSavePath().Returns(path);

            sut.DirectoryHandler.Exists(path).Returns(false);

            sut.Write(player);

            sut.DirectoryHandler.Received().CreateDirectory(path);

            sut.PlayerWriter.Write(player);
        }

        [Theory, AutoNSubstituteData]
        public void Write_WhenDirectoryExists_ShouldNotCallCreateDirectory(
            Player player,
            string path,
            PlayerWriterWithFileDirectoryValidator sut)
        {
            sut.ConfigurationReader.ReadSavePath().Returns(path);

            sut.DirectoryHandler.Exists(path).Returns(true);

            sut.Write(player);

            sut.DirectoryHandler.DidNotReceive().CreateDirectory(path);

            sut.PlayerWriter.Write(player);
        }
    }
}
