using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Core.Abstractions;
using ToyRobot.Core.Commands.Implementations;
using ToyRobot.Core.Models;
using ToyRobot.Infrastructure;
using ToyRobot.Infrastructure.Exceptions;
using ToyRobot.UnitTest.Models;

namespace ToyRobot.UnitTest
{
    [TestClass]
    public class PlaceCommandTest
    {
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        //[ExpectedException(typeof(InvalidReceiverException), "can't place receiver in null")]
        public void ShouldFailWhenMapIsNull()
        {
            var receivers = new List<Receiver>() { new Robot() };

            var command = new PlaceCommand(receivers, null, 0, 0, ENUMERATIONS.DIRECTIONS.NORTH);
            command.Execute();
            foreach (var receiver in receivers)
            {
                Assert.IsNull(receiver.Map);
                Assert.AreEqual(receiver.X, 0);
                Assert.AreEqual(receiver.Y, 0);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.UNKNOWN);
                Assert.AreEqual(receiver.IsValid, false);
            }
        }

        [TestMethod]
        public void ShouldDoNothingWhenPlaceWithNegativeValues()
        {
            var map = new TableTop(5, 5);
            var receivers = new List<Receiver>() { new Robot() };

            var command1 = new PlaceCommand(receivers, map, -1, 1, ENUMERATIONS.DIRECTIONS.NORTH);
            command1.Execute();

            foreach (var receiver in receivers)
            {
                Assert.IsNull(receiver.Map);
                Assert.AreEqual(receiver.X, 0);
                Assert.AreEqual(receiver.Y, 0);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.UNKNOWN);
                Assert.AreEqual(receiver.IsValid, false);
            }
            
            var command2 = new PlaceCommand(receivers, map, 2, -2, ENUMERATIONS.DIRECTIONS.NORTH);
            command2.Execute();

            foreach (var receiver in receivers)
            {
                Assert.IsNull(receiver.Map);
                Assert.AreEqual(receiver.X, 0);
                Assert.AreEqual(receiver.Y, 0);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.UNKNOWN);
                Assert.AreEqual(receiver.IsValid, false);
            }
        }


        [TestMethod]
        public void ShouldDoNothingWhenPlaceWithValuesGreaterThanMap()
        {
            var map = new TableTop(5, 5);
            var receivers = new List<Receiver>() { new Robot() };

            var command1 = new PlaceCommand(receivers, map, 7, 1, ENUMERATIONS.DIRECTIONS.NORTH);
            command1.Execute();
            
            foreach (var receiver in receivers)
            {
                Assert.IsNull(receiver.Map);
                Assert.AreEqual(receiver.X, 0);
                Assert.AreEqual(receiver.Y, 0);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.UNKNOWN);
                Assert.AreEqual(receiver.IsValid, false);
            }
            
            var command2 = new PlaceCommand(receivers, map, 2, 8, ENUMERATIONS.DIRECTIONS.NORTH);
            command2.Execute();

            foreach (var receiver in receivers)
            {
                Assert.IsNull(receiver.Map);
                Assert.AreEqual(receiver.X, 0);
                Assert.AreEqual(receiver.Y, 0);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.UNKNOWN);
                Assert.AreEqual(receiver.IsValid, false);
            }
        }

        [TestMethod]
        public void ShouldPlaceMapWithValidData()
        {
            var map = new TableTop(5, 5);
            var receivers = new List<Receiver>() { new Robot() };

            var command1 = new PlaceCommand(receivers, map, 1, 1, ENUMERATIONS.DIRECTIONS.NORTH);
            command1.Execute();

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
        public void ShouldOverideTheFirstPlaceMapWithNewPlace()
        {
            var map = new TableTop(5, 5);
            var receivers = new List<Receiver>() { new Robot() };

            var command1 = new PlaceCommand(receivers, map, 1, 1, ENUMERATIONS.DIRECTIONS.NORTH);
            command1.Execute();

            var command2 = new PlaceCommand(receivers, map, 4, 4, ENUMERATIONS.DIRECTIONS.WEST);
            command2.Execute();

            foreach (var receiver in receivers)
            {
                Assert.AreEqual(receiver.Map, map);
                Assert.AreEqual(receiver.X, 4);
                Assert.AreEqual(receiver.Y, 4);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.WEST);
                Assert.AreEqual(receiver.IsValid, true);
            }
        }

        [TestMethod]
        public void OneReceiversExceptionShouldntBreakOtherReceiver()
        {
            var map = new TableTop(5, 5);
            var robot = new Robot();
            var brokenRobot = new BrokenRobot();
            var receivers = new List<Receiver>() { robot, brokenRobot };

            var command1 = new PlaceCommand(receivers, map, 1, 1, ENUMERATIONS.DIRECTIONS.WEST);
            command1.Execute();            

            Assert.AreEqual(robot.Map, map);
            Assert.AreEqual(robot.X, 1);
            Assert.AreEqual(robot.Y, 1);
            Assert.AreEqual(robot.Direction, ENUMERATIONS.DIRECTIONS.WEST);
            Assert.IsTrue(robot.IsValid);
            
            Assert.IsNull(brokenRobot.Map);
            Assert.AreEqual(brokenRobot.X, 0);
            Assert.AreEqual(brokenRobot.Y, 0);
            Assert.AreEqual(brokenRobot.Direction, ENUMERATIONS.DIRECTIONS.UNKNOWN);
            Assert.IsFalse(brokenRobot.IsValid);
        }
    }
}
