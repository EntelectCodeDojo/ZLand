using System;
using FluentAssertions;
using NUnit.Framework;
using ZLand.World;

namespace ZLand.Tests.World
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void GivenAMapThatIsNotNull_WhenICreateANewGame_ThenItShouldSetTheMapToTheSuppliedMap()
        {
            var map = new Map(5, 5);
            var game = new Game(map);
            Assert.AreSame(map, game.Map);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GivenAMapThatIsNull_WhenICreateANewGame_ThenItShouldThrowAnError()
        {
            Map map = null;
            new Game(map);
        }

        [Test]
        public void WhenCreatingAGame_ThenTheCurrentTurnShouldBe1()
        {
            var game = new Game(new Map(5, 5));
            Assert.AreEqual(1, game.CurrentTurn);
        }

        [Test]
        public void WhenCreatingAGame_ThenYouShouldBeAbleToSpecifyIfThereAreMaxTurns()
        {
            const int expectedMaxTurns = 5;
            var game = new Game(new Map(5, 5), expectedMaxTurns);
            game.MaxTurns.Should().Be(expectedMaxTurns);
        }
    }
}