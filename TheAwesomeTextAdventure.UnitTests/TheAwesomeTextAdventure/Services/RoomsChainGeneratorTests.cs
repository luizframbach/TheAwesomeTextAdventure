using AutoFixture.Idioms;
using FluentAssertions;
using NSubstitute;
using System.Linq;
using TheAwesomeTextAdventure.Services;
using TheAwesomeTextAdventure.Services.Abstractions;
using TheAwesomeTextAdventure.UnitTests.AutoFixture;
using Xunit;

namespace TheAwesomeTextAdventure.UnitTests.TheAwesomeTextAdventure.Services
{
    public class RoomsChainGeneratorTests
    {
        [Theory, AutoNSubstituteData]
        public void Sut_ShouldGuardItsClause(GuardClauseAssertion assertion)
            => assertion.Verify(typeof(RoomsChainGenerator).GetConstructors());

        [Theory, AutoNSubstituteData]
        public void Sut_Is_IRoomsChainGenerator(RoomsChainGenerator sut)
            => Assert.IsAssignableFrom<IRoomsChainGenerator>(sut);

        [Theory, AutoNSubstituteData]
        public void GetShuffledRooms_ShouldReturnCorrectlyRooms(
            RoomsChainGenerator sut)
        {
            sut.RandomRankGenerator.Next().Returns(1);

            var shuffledRooms = sut.GetShuffledRooms();

            foreach (var room in sut.Rooms)
            {
                shuffledRooms.Contains(room).Should().BeTrue();
            }

            shuffledRooms.Last().Should().BeEquivalentTo(sut.BossRoom);
        }
    }
}
