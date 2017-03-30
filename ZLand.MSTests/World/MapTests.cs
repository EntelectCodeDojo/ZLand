using ZLand.World;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZLand.Tests.World
{
    [TestClass]
    public class MapTests
    {
        [TestMethod]
        public void WhenCreatingAMap_ThenIMustProvideTheSizeOfTheMap()
        {
            var map = new Map(5,5);
            Assert.IsNotNull(map);
        }

        [TestMethod]
        public void WhenCreatingAMap_ThenItShouldContainCells()
        {
            var map = new Map(5, 5);
            Assert.IsNotNull(map.Cells);
        }

        [TestMethod]
        public void WhenCreatingAMapOfACertainSize_ThenTheMapHeightAndWidthShouldMatchTheSuppliedArguments()
        {
            const int width = 7;
            const int height = 4;
            var map = new Map(width, height);
            Assert.AreEqual(width, map.Width);
            Assert.AreEqual(height, map.Height);
        }

        [TestMethod]
        public void WhenCreatingAMapOfACertainSize_ThenThereShouldBeA2DArrayOfCellsOfThatSize()
        {
            const int width = 7;
            const int height = 4;
            var map = new Map(width, height);
            Assert.AreEqual(width, map.Cells.GetLength(0));
            Assert.AreEqual(height, map.Cells.GetLength(1));
        }

        [TestMethod]
        public void WhenCreatingAMap_ThenItShouldInstantiateTheCellArray()
        {
            var map = new Map(5, 5);
            for (int xValue = 0; xValue < map.Width; xValue++)
            {
                for (int yValue = 0; yValue < map.Height; yValue++)
                {
                    Assert.IsNotNull(map.Cells[xValue,yValue]);
                }
            }
        }
    }
}