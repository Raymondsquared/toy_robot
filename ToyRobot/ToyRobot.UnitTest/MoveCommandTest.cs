﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Core.Abstractions;
using ToyRobot.Core.Commands.Implementations;
using ToyRobot.Core.Models;
using ToyRobot.Infrastructure;
using ToyRobot.UnitTest.Models;

namespace ToyRobot.UnitTest
{
    [TestClass]
    public class MoveCommandTest
    {
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public void ShouldMoveNorthWithValidData()
        {
            var map = new TableTop(5, 5);
            var receivers = new List<Receiver>() { new Robot() };
            
            var command1 = new PlaceCommand(receivers, map, 1, 1, ENUMERATIONS.DIRECTIONS.NORTH);
            command1.Execute();

            var command2 = new MoveCommand(receivers);
            command2.Execute();

            foreach (var receiver in receivers)
            {
                Assert.AreEqual(receiver.Map, map);
                Assert.AreEqual(receiver.X, 1);
                Assert.AreEqual(receiver.Y, 2);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.NORTH);
                Assert.AreEqual(receiver.IsValid, true);
            }
        }

        [TestMethod]
        public void ShouldMoveEastWithValidData()
        {
            var map = new TableTop(5, 5);
            var receivers = new List<Receiver>() { new Robot() };

            var command1 = new PlaceCommand(receivers, map, 1, 1, ENUMERATIONS.DIRECTIONS.EAST);
            command1.Execute();

            var command2 = new MoveCommand(receivers);
            command2.Execute();

            foreach (var receiver in receivers)
            {
                Assert.AreEqual(receiver.Map, map);
                Assert.AreEqual(receiver.X, 2);
                Assert.AreEqual(receiver.Y, 1);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.EAST);
                Assert.AreEqual(receiver.IsValid, true);
            }
        }

        [TestMethod]
        public void ShouldMoveSouthWithValidData()
        {
            var map = new TableTop(5, 5);
            var receivers = new List<Receiver>() { new Robot() };

            var command1 = new PlaceCommand(receivers, map, 1, 1, ENUMERATIONS.DIRECTIONS.SOUTH);
            command1.Execute();

            var command2 = new MoveCommand(receivers);
            command2.Execute();

            foreach (var receiver in receivers)
            {
                Assert.AreEqual(receiver.Map, map);
                Assert.AreEqual(receiver.X, 1);
                Assert.AreEqual(receiver.Y, 0);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.SOUTH);
                Assert.AreEqual(receiver.IsValid, true);
            }
        }

        [TestMethod]
        public void ShouldMoveWestWithValidData()
        {
            var map = new TableTop(5, 5);
            var receivers = new List<Receiver>() { new Robot() };

            var command1 = new PlaceCommand(receivers, map, 1, 1, ENUMERATIONS.DIRECTIONS.WEST);
            command1.Execute();

            var command2 = new MoveCommand(receivers);
            command2.Execute();

            foreach (var receiver in receivers)
            {
                Assert.AreEqual(receiver.Map, map);
                Assert.AreEqual(receiver.X, 0);
                Assert.AreEqual(receiver.Y, 1);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.WEST);
                Assert.AreEqual(receiver.IsValid, true);
            }
        }

        [TestMethod]
        public void ShouldDoNothingWhenReachTheTop()
        {
            var map = new TableTop(5, 5);
            var receivers = new List<Receiver>() { new Robot() };

            var command1 = new PlaceCommand(receivers, map, 1, 4, ENUMERATIONS.DIRECTIONS.NORTH);
            command1.Execute();

            var command2 = new MoveCommand(receivers);
            command2.Execute();
            command2.Execute();

            foreach (var receiver in receivers)
            {
                Assert.AreEqual(receiver.Map, map);
                Assert.AreEqual(receiver.X, 1);
                Assert.AreEqual(receiver.Y, 5);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.NORTH);
                Assert.AreEqual(receiver.IsValid, true);
            }
        }

        [TestMethod]
        public void ShouldDoNothingWhenReachTheBottom()
        {
            var map = new TableTop(5, 5);
            var receivers = new List<Receiver>() { new Robot() };

            var command1 = new PlaceCommand(receivers, map, 1, 1, ENUMERATIONS.DIRECTIONS.SOUTH);
            command1.Execute();

            var command2 = new MoveCommand(receivers);
            command2.Execute();
            command2.Execute();

            foreach (var receiver in receivers)
            {
                Assert.AreEqual(receiver.Map, map);
                Assert.AreEqual(receiver.X, 1);
                Assert.AreEqual(receiver.Y, 0);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.SOUTH);
                Assert.AreEqual(receiver.IsValid, true);
            }
        }        

        [TestMethod]
        public void ShouldDoNothingWhenReachTheEastCorner()
        {
            var map = new TableTop(5, 5);
            var receivers = new List<Receiver>() { new Robot() };

            var command1 = new PlaceCommand(receivers, map, 4, 1, ENUMERATIONS.DIRECTIONS.EAST);
            command1.Execute();

            var command2 = new MoveCommand(receivers);
            command2.Execute();
            command2.Execute();

            foreach (var receiver in receivers)
            {
                Assert.AreEqual(receiver.Map, map);
                Assert.AreEqual(receiver.X, 5);
                Assert.AreEqual(receiver.Y, 1);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.EAST);
                Assert.AreEqual(receiver.IsValid, true);
            }
        }

        [TestMethod]
        public void ShouldDoNothingWhenReachTheWestCorner()
        {
            var map = new TableTop(5, 5);
            var receivers = new List<Receiver>() { new Robot() };

            var command1 = new PlaceCommand(receivers, map, 1, 1, ENUMERATIONS.DIRECTIONS.WEST);
            command1.Execute();

            var command2 = new MoveCommand(receivers);
            command2.Execute();
            command2.Execute();

            foreach (var receiver in receivers)
            {
                Assert.AreEqual(receiver.Map, map);
                Assert.AreEqual(receiver.X, 0);
                Assert.AreEqual(receiver.Y, 1);
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

            var command2 = new MoveCommand(receivers);
            command2.Execute();
            command2.Execute();

            Assert.AreEqual(robot.Map, map);
            Assert.AreEqual(robot.X, 0);
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
