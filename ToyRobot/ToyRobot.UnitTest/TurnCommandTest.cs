using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Core.Abstractions;
using ToyRobot.Core.Commands.Implementations;
using ToyRobot.Core.Models;
using ToyRobot.Infrastructure;

namespace ToyRobot.UnitTest
{
    [TestClass]
    public class TurnCommandTest
    {

        [TestMethod]
        public void ShouldTurnLeftWithValidDataFromNorth()
        {
            var map = new TableTop(5, 5);
            var receivers = new List<Receiver>() { new Robot() };

            var command1 = new PlaceCommand(receivers, map, 1, 1, ENUMERATIONS.DIRECTIONS.NORTH);
            command1.Execute();

            var command2 = new TurnCommand(receivers, ENUMERATIONS.TURNS.LEFT);
            command2.Execute();

            foreach (var receiver in receivers)
            {
                Assert.AreEqual(receiver.Map, map);
                Assert.AreEqual(receiver.X, 1);
                Assert.AreEqual(receiver.Y, 1);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.WEST);
                Assert.AreEqual(receiver.IsValid, true);
            }
        }

        [TestMethod]
        public void ShouldTurnLeftWithValidDataFromEast()
        {
            var map = new TableTop(5, 5);
            var receivers = new List<Receiver>() { new Robot()};

            var command1 = new PlaceCommand(receivers, map, 1, 1, ENUMERATIONS.DIRECTIONS.EAST);
            command1.Execute();

            var command2 = new TurnCommand(receivers, ENUMERATIONS.TURNS.LEFT);
            command2.Execute();

            foreach (var receiver in receivers)
            {
                Assert.AreEqual(receiver.Map, map);
                Assert.AreEqual(receiver.X, 1);
                Assert.AreEqual(receiver.Y, 1);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.NORTH);
                Assert.AreEqual(receiver.IsValid, true);
            }
        }

        [TestMethod]
        public void ShouldTurnLeftWithValidDataFromSouth()
        {
            var map = new TableTop(5, 5);
            var receivers = new List<Receiver>() { new Robot() };

            var command1 = new PlaceCommand(receivers, map, 1, 1, ENUMERATIONS.DIRECTIONS.SOUTH);
            command1.Execute();

            var command2 = new TurnCommand(receivers, ENUMERATIONS.TURNS.LEFT);
            command2.Execute();

            foreach (var receiver in receivers)
            {
                Assert.AreEqual(receiver.Map, map);
                Assert.AreEqual(receiver.X, 1);
                Assert.AreEqual(receiver.Y, 1);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.EAST);
                Assert.AreEqual(receiver.IsValid, true);
            }
        }

        [TestMethod]
        public void ShouldTurnLeftWithValidDataFromWest()
        {
            var map = new TableTop(5, 5);
            var receivers = new List<Receiver>() { new Robot() };

            var command1 = new PlaceCommand(receivers, map, 1, 1, ENUMERATIONS.DIRECTIONS.WEST);
            command1.Execute();

            var command2 = new TurnCommand(receivers, ENUMERATIONS.TURNS.LEFT);
            command2.Execute();

            foreach (var receiver in receivers)
            {
                Assert.AreEqual(receiver.Map, map);
                Assert.AreEqual(receiver.X, 1);
                Assert.AreEqual(receiver.Y, 1);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.SOUTH);
                Assert.AreEqual(receiver.IsValid, true);
            }
        }

        [TestMethod]
        public void ShouldTurnRightWithValidDataFromNorth()
        {
            var map = new TableTop(5, 5);
            var receivers = new List<Receiver>() { new Robot() };

            var command1 = new PlaceCommand(receivers, map, 1, 1, ENUMERATIONS.DIRECTIONS.NORTH);
            command1.Execute();

            var command2 = new TurnCommand(receivers, ENUMERATIONS.TURNS.RIGHT);
            command2.Execute();

            foreach (var receiver in receivers)
            {
                Assert.AreEqual(receiver.Map, map);
                Assert.AreEqual(receiver.X, 1);
                Assert.AreEqual(receiver.Y, 1);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.EAST);
                Assert.AreEqual(receiver.IsValid, true);
            }
        }

        [TestMethod]
        public void ShouldTurnRightWithValidDataFromEast()
        {
            var map = new TableTop(5, 5);
            var receivers = new List<Receiver>() { new Robot() };

            var command1 = new PlaceCommand(receivers, map, 1, 1, ENUMERATIONS.DIRECTIONS.EAST);
            command1.Execute();

            var command2 = new TurnCommand(receivers, ENUMERATIONS.TURNS.RIGHT);
            command2.Execute();

            foreach (var receiver in receivers)
            {
                Assert.AreEqual(receiver.Map, map);
                Assert.AreEqual(receiver.X, 1);
                Assert.AreEqual(receiver.Y, 1);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.SOUTH);
                Assert.AreEqual(receiver.IsValid, true);
            }
        }

        [TestMethod]
        public void ShouldTurnRightWithValidDataFromSouth()
        {
            var map = new TableTop(5, 5);
            var receivers = new List<Receiver>() { new Robot() };

            var command1 = new PlaceCommand(receivers, map, 1, 1, ENUMERATIONS.DIRECTIONS.SOUTH);
            command1.Execute();

            var command2 = new TurnCommand(receivers, ENUMERATIONS.TURNS.RIGHT);
            command2.Execute();

            foreach (var receiver in receivers)
            {
                Assert.AreEqual(receiver.Map, map);
                Assert.AreEqual(receiver.X, 1);
                Assert.AreEqual(receiver.Y, 1);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.WEST);
                Assert.AreEqual(receiver.IsValid, true);
            }
        }

        [TestMethod]
        public void ShouldTurnRightWithValidDataFromWest()
        {
            var map = new TableTop(5, 5);
            var receivers = new List<Receiver>() { new Robot() };

            var command1 = new PlaceCommand(receivers, map, 1, 1, ENUMERATIONS.DIRECTIONS.WEST);
            command1.Execute();

            var command2 = new TurnCommand(receivers, ENUMERATIONS.TURNS.RIGHT);
            command2.Execute();

            foreach (var receiver in receivers)
            {
                Assert.AreEqual(receiver.Map, map);
                Assert.AreEqual(receiver.X, 1);
                Assert.AreEqual(receiver.Y, 1);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.NORTH);
                Assert.AreEqual(receiver.IsValid, true);
            }
        }

        [TestMethod]
        public void ShouldReturnToOriginalWhereTurnFourTimes()
        {
            var map = new TableTop(5, 5);
            var receivers = new List<Receiver>(){ new Robot()};

            var command1 = new PlaceCommand(receivers, map, 1, 1, ENUMERATIONS.DIRECTIONS.NORTH);
            command1.Execute();

            var command2 = new TurnCommand(receivers, ENUMERATIONS.TURNS.RIGHT);
            command2.Execute();
            command2.Execute();
            command2.Execute();
            command2.Execute();

            foreach (var receiver in receivers)
            {
                Assert.AreEqual(receiver.Map, map);
                Assert.AreEqual(receiver.X, 1);
                Assert.AreEqual(receiver.Y, 1);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.NORTH);
                Assert.AreEqual(receiver.IsValid, true);
            }
            
            var command3 = new TurnCommand(receivers, ENUMERATIONS.TURNS.LEFT);
            command3.Execute();
            command3.Execute();
            command3.Execute();
            command3.Execute();

            foreach (var receiver in receivers)
            {
                Assert.AreEqual(receiver.Map, map);
                Assert.AreEqual(receiver.X, 1);
                Assert.AreEqual(receiver.Y, 1);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.NORTH);
                Assert.AreEqual(receiver.IsValid, true);
            }
        }
    }
}
