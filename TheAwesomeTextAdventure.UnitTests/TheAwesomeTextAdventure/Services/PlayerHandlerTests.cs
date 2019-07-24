using AutoFixture.Idioms;
using FluentAssertions;
using NSubstitute;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Services;
using TheAwesomeTextAdventure.Services.Abstractions;
using TheAwesomeTextAdventure.UnitTests.AutoFixture;
using Xunit;

namespace TheAwesomeTextAdventure.UnitTests.TheAwesomeTextAdventure.Services
{
    public class PlayerHandlerTests
    {
        [Theory, AutoNSubstituteData]
        public void Sut_ShouldGuardItsClause(GuardClauseAssertion assertion)
            => assertion.Verify(typeof(PlayerHandler).GetConstructors());

        [Theory, AutoNSubstituteData]
        public void Sut_Is_IPlayerHandler(PlayerHandler sut)
            => Assert.IsAssignableFrom<IPlayerHandler>(sut);

        [Theory, AutoNSubstituteData]
        public void CreatePlayer_ShouldReturnPlayerWithName(
            string name,
            PlayerHandler sut)
        {
            sut.ActionWrapper.ReadLine().Returns(name);

            var player = sut.CreatePlayer();

            player.Name.Should().Be(name);
        }

        [Theory, AutoNSubstituteData]
        public void LoadPlayer_ShouldCallPlayerReader(
            Player playerResult,
            PlayerHandler sut)
        {
            sut.PlayerReader.Read().Returns(playerResult);

            var player = sut.LoadPlayer();

            player.Should().Be(playerResult);
        }
    }
}
