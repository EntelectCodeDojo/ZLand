using System;
using FluentAssertions;
using Moq;
using ZLand.World;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZLand.Tests.World
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void GivenAMapThatIsNotNull_WhenICreateANewGame_ThenItShouldSetTheMapToTheSuppliedMap()
        {
            var map = new Map(5, 5);
            var game = new Game(map, new PersistanceFake());
            Assert.AreSame(map, game.Map);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GivenAMapThatIsNull_WhenICreateANewGame_ThenItShouldThrowAnError()
        {
            Map map = null;
            new Game(map, new PersistanceFake());
        }

        [TestMethod]
        public void WhenCreatingAGame_ThenTheCurrentTurnShouldBe1()
        {
            var game = new Game(new Map(5, 5), new PersistanceFake());
            Assert.AreEqual(1, game.CurrentTurn);
        }

        [TestMethod]
        public void WhenCreatingAGame_ThenYouShouldBeAbleToSpecifyIfThereAreMaxTurns()
        {
            const int expectedMaxTurns = 5;
            var game = new Game(new Map(5, 5), new PersistanceFake(), expectedMaxTurns);
            game.MaxTurns.Should().Be(expectedMaxTurns);
        }

        [TestMethod]
        public void WhenSavingAGame_ThenTheSaveMethodShouldBeCalledExactlyOnce()
        {
            var persistanceMock = new Mock<IPersistanceService>();
            persistanceMock.Setup(persistanceService => persistanceService.Save(It.IsAny<Game>()));
            var game = new Game(new Map(5, 5), persistanceMock.Object);
            game.Save();
            persistanceMock.Verify(persistanceService => persistanceService.Save(It.IsAny<Game>()), Times.Exactly(1));
        }

        [TestMethod]
        public void WhenSavingAGame_ThenThePersistanceServiceShouldBePassedTheGame()
        {
            var persistanceMock = new Mock<IPersistanceService>();
            var game = new Game(new Map(5, 5), persistanceMock.Object);
            persistanceMock.Setup(persistanceService => persistanceService.Save(It.IsAny<Game>()))
                .Callback<Game>(passedInGame => Assert.AreSame(game, passedInGame));
            game.Save();
        }
    }
}