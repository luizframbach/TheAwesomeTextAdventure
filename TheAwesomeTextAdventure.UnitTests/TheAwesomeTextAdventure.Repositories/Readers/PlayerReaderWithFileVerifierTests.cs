using AutoFixture.Idioms;
using FluentAssertions;
using NSubstitute;
using TheAwesomeTextAdventure.Infrastructure.Readers;
using TheAwesomeTextAdventure.Infrastructure.Readers.Abstractions;
using TheAwesomeTextAdventure.UnitTests.AutoFixture;
using Xunit;

namespace TheAwesomeTextAdventure.UnitTests.TheAwesomeTextAdventure.Repositories.Readers
{
    public class PlayerReaderWithFileVerifierTests
    {
        [Theory, AutoNSubstituteData]
        public void Sut_ShouldGuardItsClause(GuardClauseAssertion assertion)
            => assertion.Verify(typeof(PlayerReaderWithFileVerifier).GetConstructors());

        [Theory, AutoNSubstituteData]
        public void Sut_Is_IPlayerReader(PlayerReaderWithFileVerifier sut)
            => Assert.IsAssignableFrom<IPlayerReader>(sut);

        [Theory, AutoNSubstituteData]
        public void Read_WhenFileNotExists_ReturnNull(
            string path,
            PlayerReaderWithFileVerifier sut)
        {
            sut.ConfigurationReader.ReadSavePathWithPlayerArchive().Returns(path);

            sut.FileHandler.Exists(path).Returns(false);

            var response = sut.Read();

            response.Should().Be(null);

            sut.ConfigurationReader.Received().ReadSavePathWithPlayerArchive();

            sut.PlayerReader.DidNotReceive().Read();
        }

        [Theory, AutoNSubstituteData]
        public void Read_ShouldInvokePipeLineCorrectly(
            string path,
            PlayerReaderWithFileVerifier sut)
        {
            sut.ConfigurationReader.ReadSavePathWithPlayerArchive().Returns(path);

            sut.FileHandler.Exists(path).Returns(true);

            sut.Read();

            sut.ConfigurationReader.Received().ReadSavePathWithPlayerArchive();

            sut.PlayerReader.Received().Read();
        }
    }
}
