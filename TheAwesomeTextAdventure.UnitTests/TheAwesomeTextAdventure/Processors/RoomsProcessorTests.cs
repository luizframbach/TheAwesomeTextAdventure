using AutoFixture.Idioms;
using NSubstitute;
using System.Collections.Generic;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Domain.Rooms;
using TheAwesomeTextAdventure.Processors;
using TheAwesomeTextAdventure.Processors.Abstractions;
using TheAwesomeTextAdventure.UnitTests.AutoFixture.Attributes;
using TheAwesomeTextAdventure.UnitTests.Helpers;
using Xunit;

namespace TheAwesomeTextAdventure.UnitTests.TheAwesomeTextAdventure.Processors
{
    public class RoomsProcessorTests
    {
        [Theory, AutoNSubstituteData]
        public void Sut_ShouldGuardItsClause(GuardClauseAssertion assertion)
            => assertion.Verify(typeof(RoomsProcessor).GetConstructors());

        [Theory, AutoNSubstituteData]
        public void Sut_Is_IRoomsProcessor(RoomsProcessor sut)
            => Assert.IsAssignableFrom<IRoomsProcessor>(sut);

        [Theory, AutoNSubstituteData]
        public void StartProcessing_ShouldExecuteCorrectlyPipeLine(
            Player player,
            Room room,
            RoomsProcessor sut)
        {
            room.SetProperty("Finished", true);

            sut.RoomsChainGenerator.GetShuffledRooms().Returns(new List<Room>
            {
                room
            });

            sut.StartProcessing(player);

            sut.RoomsChainGenerator.Received().GetShuffledRooms();

            sut.RoomHandler.Received().StartRoomHistory(room);

            sut.RoomHandler.Received().ReadPossibleActions(room);

            sut.RoomHandler.Received().EndRoomHistory(room);
        }
    }
}
