using AutoFixture.Idioms;
using FluentAssertions;
using TheAwesomeTextAdventure.Infrastructure.Readers;
using TheAwesomeTextAdventure.Infrastructure.Readers.Abstractions;
using TheAwesomeTextAdventure.UnitTests.AutoFixture.Attributes;
using Xunit;

namespace TheAwesomeTextAdventure.UnitTests.TheAwesomeTextAdventure.Repositories.Readers
{
    public class ConfigurationReaderTests
    {
        [Theory, AutoNSubstituteData]
        public void Sut_ShouldGuardItsClause(GuardClauseAssertion assertion)
            => assertion.Verify(typeof(ConfigurationReader).GetConstructors());

        [Theory, AutoNSubstituteData]
        public void Sut_Is_IConfigurationReader(ConfigurationReader sut)
            => Assert.IsAssignableFrom<IConfigurationReader>(sut);


        [Theory, AutoNSubstituteData]
        public void ReadSavePath_ShouldReturnSavePath(
            ConfigurationReader sut)
            => sut.ReadSavePath().Should().Be(sut.GeneralConfiguration.SavePath);

        [Theory, AutoNSubstituteData]
        public void ReadSaveSavePathWithPlayerArchive_ShouldReturnReadSavePathWithPlayerArchive(
            ConfigurationReader sut)
            => sut.ReadSavePathWithPlayerArchive().Should().Be(sut.GeneralConfiguration.SavePathWithPlayerArchive);
    }
}
