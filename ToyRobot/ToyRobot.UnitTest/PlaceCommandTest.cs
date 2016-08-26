using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Core.Commands.Implementations;
using ToyRobot.Core.Models;
using ToyRobot.Infrastructure;
using ToyRobot.Infrastructure.Exceptions;

namespace ToyRobot.UnitTest
{
    [TestClass]
    public class PlaceCommandTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidReceiverException), "can't place receiver in null")]
        public void ShouldFailWhenMapIsNull()
        {
            var receiver = new Robot();
            var command = new PlaceCommand(receiver, null, 0, 0, ENUMERATIONS.DIRECTIONS.NORTH);
            command.Execute();
        }

        [TestMethod]
        public void ShouldDoNothingWhenPlaceWithNegativeValues()
        {
            var map = new TableTop(5, 5);
            var receiver = new Robot();

            var command1 = new PlaceCommand(receiver, map, -1, 1, ENUMERATIONS.DIRECTIONS.NORTH);
            command1.Execute();
            Assert.IsNull(receiver.Map);
            Assert.AreEqual(receiver.X, 0);
            Assert.AreEqual(receiver.Y, 0);
            Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.UNKNOWN);
            Assert.AreEqual(receiver.IsValid, false);

            var command2 = new PlaceCommand(receiver, map, 2, -2, ENUMERATIONS.DIRECTIONS.NORTH);
            command2.Execute();
            Assert.IsNull(receiver.Map);
            Assert.AreEqual(receiver.X, 0);
            Assert.AreEqual(receiver.Y, 0);
            Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.UNKNOWN);
            Assert.AreEqual(receiver.IsValid, false);
        }


        [TestMethod]
        public void ShouldDoNothingWhenPlaceWithValuesGreaterThanMap()
        {
            var map = new TableTop(5, 5);
            var receiver = new Robot();

            var command1 = new PlaceCommand(receiver, map, 7, 1, ENUMERATIONS.DIRECTIONS.NORTH);
            command1.Execute();
            Assert.IsNull(receiver.Map);
            Assert.AreEqual(receiver.X, 0);
            Assert.AreEqual(receiver.Y, 0);
            Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.UNKNOWN);
            Assert.AreEqual(receiver.IsValid, false);

            var command2 = new PlaceCommand(receiver, map, 2, 8, ENUMERATIONS.DIRECTIONS.NORTH);
            command2.Execute();
            Assert.IsNull(receiver.Map);
            Assert.AreEqual(receiver.X, 0);
            Assert.AreEqual(receiver.Y, 0);
            Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.UNKNOWN);
            Assert.AreEqual(receiver.IsValid, false);
        }

        [TestMethod]
        public void ShouldPlaceMapWithValidData()
        {
            var map = new TableTop(5, 5);
            var receiver = new Robot();

            var command1 = new PlaceCommand(receiver, map, 1, 1, ENUMERATIONS.DIRECTIONS.NORTH);
            command1.Execute();
            Assert.AreEqual(receiver.Map, map);
            Assert.AreEqual(receiver.X, 1);
            Assert.AreEqual(receiver.Y, 1);
            Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.NORTH);
            Assert.AreEqual(receiver.IsValid, true);
        }
        [TestMethod]
        public void ShouldOverideTheFirstPlaceMapWithNewPlace()
        {
            var map = new TableTop(5, 5);
            var receiver = new Robot();

            var command1 = new PlaceCommand(receiver, map, 1, 1, ENUMERATIONS.DIRECTIONS.NORTH);
            command1.Execute();
            var command2 = new PlaceCommand(receiver, map, 4, 4, ENUMERATIONS.DIRECTIONS.WEST);
            command2.Execute();
            Assert.AreEqual(receiver.Map, map);
            Assert.AreEqual(receiver.X, 4);
            Assert.AreEqual(receiver.Y, 4);
            Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.WEST);
            Assert.AreEqual(receiver.IsValid, true);
        }
    }
}
