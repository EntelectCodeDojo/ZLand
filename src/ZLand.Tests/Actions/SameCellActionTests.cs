using System;
using NUnit.Framework;
using ZLand.Actions;
using ZLand.Actors;
using ZLand.Services;
using ZLand.World;

namespace ZLand.Tests.Actions
{
    [TestFixture]
    public class SameCellActionTests
    {
        private Stats _stats;

        [SetUp]
        public void Intialise()
        {
            var notificationService = new FakeNotificationService();
            var randomiser = new BasicRandomiser();
            _stats = new Stats(notificationService, randomiser);
        }

        [Test]
        public void Given_AnActorWith100ActionsPerTurn_When_IPerformMyTestAction_Then_ItShouldSucceed()
        {
            var bob = new TestActor(
                actionPointsPerTurn: 100,
                currentPosition: new Cell(1, 1),
                baseMoveSpeed: 1,
                stats: _stats,
                maxHealth: 100,
                maximumWeight: 100,
                name: "Bob");
            var sameCellAction = new TestSameCellAction(1, "Test Action");
            sameCellAction.Apply(bob);
        }

        [TestCase(100,1, Result = 99)]
        [TestCase(100, 2, Result = 98)]
        [TestCase(1, 1, Result = 0)]
        [TestCase(1, 2, ExpectedException = typeof(NotEnoughActionPointsException))]
        [TestCase(0, 1, ExpectedException = typeof(ArgumentException))]
        [TestCase(-1, 1, ExpectedException = typeof(ArgumentException))]
        public int Given_AnActorWithXActionsPerTurn_When_IPerformMyTestActionCostingYPoints_Then_TheActorShouldHaveXMinusYPoints(int intialPoints, int actionCost)
        {
            var bob = new TestActor(
                actionPointsPerTurn: intialPoints,
                currentPosition: new Cell(1, 1),
                baseMoveSpeed: 1,
                stats: _stats,
                maxHealth: 100,
                maximumWeight: 100,
                name: "Bob");
            var sameCellAction = new TestSameCellAction(actionCost, "Test Action");
            sameCellAction.Apply(bob);
            return bob.CurrentActionPoints;
        }
    }

    public class TestActor : Actor
    {
        public TestActor(int actionPointsPerTurn, Cell currentPosition, int baseMoveSpeed, Stats stats, int maxHealth, double maximumWeight, string name) 
            : base(actionPointsPerTurn, currentPosition, baseMoveSpeed, stats, maxHealth, maximumWeight, name)
        {
        }
    }

    public class TestSameCellAction : SameCellAction
    {
        public TestSameCellAction(int baseCost, string name) 
            : base(baseCost, name)
        {
        }
    }
}