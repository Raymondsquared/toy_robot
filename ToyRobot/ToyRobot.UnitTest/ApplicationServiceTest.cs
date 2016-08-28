using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Core.Abstractions;
using ToyRobot.Core.Models;
using ToyRobot.Infrastructure;
using ToyRobot.Providers;
using ToyRobot.Services;

namespace ToyRobot.UnitTest
{
    [TestClass]
    public class ApplicationServiceTest
    {
        private static readonly Map _map = new TableTop(CONSTANTS.NUMBERS.TABLETOP_WIDTH, CONSTANTS.NUMBERS.TABLETOP_LENGTH);        

        [TestMethod]
        public void ShouldReturnFalseWithInvalidInput()
        {
            var receiver = new ReceiverProvider().Provide();
            var applicationService = new ApplicationService(_map, receiver);
            Assert.IsFalse(applicationService.Process("ABC"));
        }

        [TestMethod]
        public void ShouldReturnFalseWithEmptyInput()
        {
            var receiver = new ReceiverProvider().Provide();
            var applicationService = new ApplicationService(_map, receiver);
            Assert.IsFalse(applicationService.Process(""));
        }

        [TestMethod]
        public void ShouldReturnFalseWithInvalidPlace()
        {
            var receiver = new ReceiverProvider().Provide();
            var applicationService = new ApplicationService(_map, receiver);
            Assert.IsFalse(applicationService.Process("PLACE"));
            Assert.IsFalse(applicationService.Process("PLACE 1"));
            Assert.IsFalse(applicationService.Process("PLACE 1,2"));
            Assert.IsFalse(applicationService.Process("PLACE 1,2,3"));
            Assert.IsFalse(applicationService.Process("PLACE 1,2,ABC"));
        }

        [TestMethod]
        public void ShouldReturnTrueWithValidPlace()
        {
            var receivers = new ReceiverProvider().Provide();
            var applicationService = new ApplicationService(_map, receivers);
            Assert.IsTrue(applicationService.Process("PLACE 1,2,NORTH"));

            foreach (var receiver in receivers)
            {
                Assert.AreEqual(receiver.Map, _map);
                Assert.AreEqual(receiver.X, 1);
                Assert.AreEqual(receiver.Y, 2);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.NORTH);
                Assert.AreEqual(receiver.IsValid, true);
            }
        }

        public void ShouldReturnFalseWithExtraOnOtherMethods()
        {
            var receiver = new ReceiverProvider().Provide();
            var applicationService = new ApplicationService(_map, receiver);
            Assert.IsFalse(applicationService.Process("MOVE 1"));
            Assert.IsFalse(applicationService.Process("LEFT 2"));
            Assert.IsFalse(applicationService.Process("RIGHT LEFT"));
            Assert.IsFalse(applicationService.Process("REPORT 123"));
        }


        [TestMethod]
        public void ShouldReturnTrueWithValidMove()
        {
            var receivers = new ReceiverProvider().Provide();
            var applicationService = new ApplicationService(_map, receivers);
            
            Assert.IsTrue(applicationService.Process("PLACE 1,2,NORTH"));
            Assert.IsTrue(applicationService.Process("MOVE"));

            foreach (var receiver in receivers)
            {
                Assert.AreEqual(receiver.Map, _map);
                Assert.AreEqual(receiver.X, 1);
                Assert.AreEqual(receiver.Y, 3);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.NORTH);
                Assert.AreEqual(receiver.IsValid, true);
            }
        }


        [TestMethod]
        public void ShouldIgnoreCommandsBeforePlace()
        {
            var receivers = new ReceiverProvider().Provide();
            var applicationService = new ApplicationService(_map, receivers);
            Assert.IsTrue(applicationService.Process("MOVE"));
            Assert.IsTrue(applicationService.Process("LEFT"));
            Assert.IsTrue(applicationService.Process("MOVE"));
            Assert.IsTrue(applicationService.Process("RIGHT"));

            foreach (var receiver in receivers)
            {
                Assert.IsNull(receiver.Map);
                Assert.AreEqual(receiver.X, 0);
                Assert.AreEqual(receiver.Y, 0);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.UNKNOWN);
                Assert.AreEqual(receiver.IsValid, false);
            }

            Assert.IsTrue(applicationService.Process("PLACE 1,1,NORTH"));
            Assert.IsTrue(applicationService.Process("MOVE"));
            Assert.IsTrue(applicationService.Process("RIGHT"));


            foreach (var receiver in receivers)
            {
                Assert.AreEqual(receiver.Map, _map);
                Assert.AreEqual(receiver.X, 1);
                Assert.AreEqual(receiver.Y, 2);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.EAST);
                Assert.AreEqual(receiver.IsValid, true);
            }
        }


        [TestMethod]
        public void ShouldReturnTrueWithValidLeft()
        {
            var receivers = new ReceiverProvider().Provide();
            var applicationService = new ApplicationService(_map, receivers);
            Assert.IsTrue(applicationService.Process("PLACE 1,2,NORTH"));
            Assert.IsTrue(applicationService.Process("LEFT"));

            foreach (var receiver in receivers)
            {
                Assert.AreEqual(receiver.Map, _map);
                Assert.AreEqual(receiver.X, 1);
                Assert.AreEqual(receiver.Y, 2);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.WEST);
                Assert.AreEqual(receiver.IsValid, true);
            }
        }

        [TestMethod]
        public void ShouldReturnTrueWithValidRight()
        {
            var receivers = new ReceiverProvider().Provide();
            var applicationService = new ApplicationService(_map, receivers);
            Assert.IsTrue(applicationService.Process("PLACE 1,2,NORTH"));
            Assert.IsTrue(applicationService.Process("RIGHT"));

            foreach (var receiver in receivers)
            {
                Assert.AreEqual(receiver.Map, _map);
                Assert.AreEqual(receiver.X, 1);
                Assert.AreEqual(receiver.Y, 2);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.EAST);
                Assert.AreEqual(receiver.IsValid, true);
            }
        }

        [TestMethod]
        public void ShouldReturnTrueWithValidReport()
        {
            var receiver = new ReceiverProvider().Provide();
            var applicationService = new ApplicationService(_map, receiver);
            Assert.IsTrue(applicationService.Process("REPORT"));
        }


        [TestMethod]
        public void ShouldIgnoreAllCommandBeforePlace()
        {
            var receivers = new ReceiverProvider().Provide();
            var applicationService = new ApplicationService(_map, receivers);
            Assert.IsTrue(applicationService.Process("MOVE"));
            Assert.IsTrue(applicationService.Process("LEFT"));
            Assert.IsTrue(applicationService.Process("LEFT"));
            Assert.IsTrue(applicationService.Process("PLACE 1,2,NORTH"));
            Assert.IsTrue(applicationService.Process("LEFT"));

            foreach (var receiver in receivers)
            {
                Assert.AreEqual(receiver.X, 1);
                Assert.AreEqual(receiver.Y, 2);
                Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.WEST);
            }
        }
    }
}
