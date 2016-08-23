using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Commands.Implementations;
using ToyRobot.Models;

namespace ToyRobot.UnitTest
{
    [TestClass]
    public class MoveCommandTest
    {
        [TestMethod]
        public void ShouldMoveNorthWithValidData()
        {
            var map = new TableTop(5, 5);
            var receiver = new Robot();

            var command1 = new PlaceCommand(receiver, map, 1, 1, ENUMERATIONS.DIRECTIONS.NORTH);
            command1.Execute();

            var command2 = new MoveCommand(receiver);
            command2.Execute();

            Assert.AreEqual(receiver.Map, map);
            Assert.AreEqual(receiver.X, 1);
            Assert.AreEqual(receiver.Y, 2);
            Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.NORTH);
            Assert.AreEqual(receiver.IsValid, true);            
        }

        [TestMethod]
        public void ShouldMoveEastWithValidData()
        {
            var map = new TableTop(5, 5);
            var receiver = new Robot();

            var command1 = new PlaceCommand(receiver, map, 1, 1, ENUMERATIONS.DIRECTIONS.EAST);
            command1.Execute();

            var command2 = new MoveCommand(receiver);
            command2.Execute();

            Assert.AreEqual(receiver.Map, map);
            Assert.AreEqual(receiver.X, 2);
            Assert.AreEqual(receiver.Y, 1);
            Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.EAST);
            Assert.AreEqual(receiver.IsValid, true);
        }

        [TestMethod]
        public void ShouldMoveSouthWithValidData()
        {
            var map = new TableTop(5, 5);
            var receiver = new Robot();

            var command1 = new PlaceCommand(receiver, map, 1, 1, ENUMERATIONS.DIRECTIONS.SOUTH);
            command1.Execute();

            var command2 = new MoveCommand(receiver);
            command2.Execute();

            Assert.AreEqual(receiver.Map, map);
            Assert.AreEqual(receiver.X, 1);
            Assert.AreEqual(receiver.Y, 0);
            Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.SOUTH);
            Assert.AreEqual(receiver.IsValid, true);
        }

        [TestMethod]
        public void ShouldMoveWestWithValidData()
        {
            var map = new TableTop(5, 5);
            var receiver = new Robot();

            var command1 = new PlaceCommand(receiver, map, 1, 1, ENUMERATIONS.DIRECTIONS.WEST);
            command1.Execute();

            var command2 = new MoveCommand(receiver);
            command2.Execute();

            Assert.AreEqual(receiver.Map, map);
            Assert.AreEqual(receiver.X, 0);
            Assert.AreEqual(receiver.Y, 1);
            Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.WEST);
            Assert.AreEqual(receiver.IsValid, true);
        }

        [TestMethod]
        public void ShouldDoNothingWhenReachTheTop()
        {
            var map = new TableTop(5, 5);
            var receiver = new Robot();

            var command1 = new PlaceCommand(receiver, map, 1, 4, ENUMERATIONS.DIRECTIONS.NORTH);
            command1.Execute();

            var command2 = new MoveCommand(receiver);
            command2.Execute();
            command2.Execute();

            Assert.AreEqual(receiver.Map, map);
            Assert.AreEqual(receiver.X, 1);
            Assert.AreEqual(receiver.Y, 5);
            Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.NORTH);
            Assert.AreEqual(receiver.IsValid, true);
        }

        [TestMethod]
        public void ShouldDoNothingWhenReachTheBottom()
        {
            var map = new TableTop(5, 5);
            var receiver = new Robot();

            var command1 = new PlaceCommand(receiver, map, 1, 1, ENUMERATIONS.DIRECTIONS.SOUTH);
            command1.Execute();

            var command2 = new MoveCommand(receiver);
            command2.Execute();
            command2.Execute();

            Assert.AreEqual(receiver.Map, map);
            Assert.AreEqual(receiver.X, 1);
            Assert.AreEqual(receiver.Y, 0);
            Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.SOUTH);
            Assert.AreEqual(receiver.IsValid, true);
        }        

        [TestMethod]
        public void ShouldDoNothingWhenReachTheEastCorner()
        {
            var map = new TableTop(5, 5);
            var receiver = new Robot();

            var command1 = new PlaceCommand(receiver, map, 4, 1, ENUMERATIONS.DIRECTIONS.EAST);
            command1.Execute();

            var command2 = new MoveCommand(receiver);
            command2.Execute();
            command2.Execute();

            Assert.AreEqual(receiver.Map, map);
            Assert.AreEqual(receiver.X, 5);
            Assert.AreEqual(receiver.Y, 1);
            Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.EAST);
            Assert.AreEqual(receiver.IsValid, true);
        }

        [TestMethod]
        public void ShouldDoNothingWhenReachTheWestCorner()
        {
            var map = new TableTop(5, 5);
            var receiver = new Robot();

            var command1 = new PlaceCommand(receiver, map, 1, 1, ENUMERATIONS.DIRECTIONS.WEST);
            command1.Execute();

            var command2 = new MoveCommand(receiver);
            command2.Execute();
            command2.Execute();

            Assert.AreEqual(receiver.Map, map);
            Assert.AreEqual(receiver.X, 0);
            Assert.AreEqual(receiver.Y, 1);
            Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.WEST);
            Assert.AreEqual(receiver.IsValid, true);
        }
    }
}
