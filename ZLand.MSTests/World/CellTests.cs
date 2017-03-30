using System;
using ZLand.World;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZLand.Tests.World
{
    [TestClass]
    public class CellTests
    {
        [TestMethod]
        public void WhenCreatingACell_ThenItShouldStoreItsXAndYCoordinates()
        {
            const int xValue = 3;
            const int yValue = 7;
            var cell = new Cell(3, 7);
            Assert.AreEqual(xValue,cell.XValue);
            Assert.AreEqual(yValue, cell.YValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenCreatingACell_ThenTheXValueCannotBeLessThan0()
        {
            const int x = -1;
            const int y = 5;
            new Cell(x, y);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenCreatingACell_ThenTheYValueCannotBeLessThan0()
        {
            const int x = 5;
            const int y = -1;
            new Cell(x, y);
        }

        /* The following is not supported in MsTest , see http://stackoverflow.com/questions/1010685/does-mstest-have-an-equivalent-to-nunits-testcase*/
        //[TestCase(0, 0, 0, 0, 0)]
        //[TestCase(0, 0, 0, 5, 5)]
        //[TestCase(0, 0, 5, 0, 5)]
        //[TestCase(1, 1, 2, 2, 1)]
        //[TestCase(1, 2, 3, 4, 2)]
        //[TestCase(0, 0, 7, 7, 7)]
        //[TestCase(0, 0, 6, 6, 6)]
        //[TestCase(0, 0, 5, 5, 5)]
        //[TestCase(0, 0, 4, 4, 4)]
        //[TestCase(0, 0, 3, 3, 3)]
        //[TestCase(0, 0, 2, 2, 2)]
        //[TestCase(0, 0, 1, 1, 1)]
        //[TestCase(0, 0, 1, 2, 2)]
        //public void GivenTwoDifferentCells_WhenYouCalculateTheDistance_ThenItShouldShowTheDistanceInCells(int xValue1, int yValue1,int xValue2, int yValue2, int expectedDistance)
        //{
        //    var cell1 = new Cell(xValue1, yValue1);
        //    var cell2 = new Cell(xValue2, yValue2);
        //    Assert.AreEqual(expectedDistance, cell1.DistanceTo(cell2));
        //}
    }
}