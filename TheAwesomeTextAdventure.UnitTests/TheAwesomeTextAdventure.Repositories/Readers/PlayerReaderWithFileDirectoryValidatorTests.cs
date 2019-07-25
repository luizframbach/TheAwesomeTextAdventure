using AutoFixture.Idioms;
using NSubstitute;
using TheAwesomeTextAdventure.Infrastructure.Readers;
using TheAwesomeTextAdventure.Infrastructure.Readers.Abstractions;
using TheAwesomeTextAdventure.UnitTests.AutoFixture.Attributes;
using Xunit;

namespace TheAwesomeTextAdventure.UnitTests.TheAwesomeTextAdventure.Repositories.Readers
{
    public class PlayerReaderWithFileDirectoryValidatorTests
    {
        [Theory, AutoNSubstituteData]
        public void Sut_ShouldGuardItsClause(GuardClauseAssertion assertion)
            => assertion.Verify(typeof(PlayerReaderWithFileDirectoryValidator).GetConstructors());

        [Theory, AutoNSubstituteData]
        public void Sut_Is_IPlayerReader(PlayerReaderWithFileDirectoryValidator sut)
            => Assert.IsAssignableFrom<IPlayerReader>(sut);

        [Theory, AutoNSubstituteData]
        public void Read_WhenDirectoryExists_ShouldNotCallCreateDirectory(
            string path,
            PlayerReaderWithFileDirectoryValidator sut)
        {
            sut.ConfigurationReader.ReadSavePath().Returns(path);

            sut.DirectoryHandler.Exists(path).Returns(true);

            sut.Read();

            sut.DirectoryHandler.DidNotReceive().CreateDirectory(path);

           sut.PlayerReader.Received().Read();
        }

        [Theory, AutoNSubstituteData]
        public void Read_WhenDirectoryNotExists_ShouldCallCreateDirectory(
            string path,
            PlayerReaderWithFileDirectoryValidator sut)
        {
            sut.ConfigurationReader.ReadSavePath().Returns(path);

            sut.DirectoryHandler.Exists(path).Returns(false);

            sut.Read();

            sut.DirectoryHandler.Received().CreateDirectory(path);

            sut.PlayerReader.Received().Read();
        }
    }
}
