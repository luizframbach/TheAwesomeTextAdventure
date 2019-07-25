using AutoFixture.Idioms;
using FluentAssertions;
using NSubstitute;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Handlers;
using TheAwesomeTextAdventure.Handlers.Abstractions;
using TheAwesomeTextAdventure.UnitTests.AutoFixture.Attributes;
using Xunit;

namespace TheAwesomeTextAdventure.UnitTests.TheAwesomeTextAdventure.Handlers
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
