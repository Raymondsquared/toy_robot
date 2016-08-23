using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Exceptions;
using ToyRobot.Models;

namespace ToyRobot.UnitTest
{
    [TestClass]
    public class TableTopTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidMapException), "map doesn't have a valid size.")]
        public void ShouldFailWhenZero()
        {
            var tableTop = new TableTop(0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMapException), "map doesn't have a valid size.")]
        public void ShouldFailWhenLessThenZero()
        {
            var tableTop1 = new TableTop(-1, 1);
            var tableTop2 = new TableTop(2, -2);
        }
    }
}
