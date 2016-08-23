using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Abstractions;
using ToyRobot.Commands;
using ToyRobot.Commands.Implementations;
using ToyRobot.Models;
using ToyRobot.Services;

namespace ToyRobot.UnitTest
{
    [TestClass]
    public class ApplicationServiceTest
    {
        private static Map _map = new TableTop(CONSTANTS.NUMBERS.TABLETOP_WIDTH, CONSTANTS.NUMBERS.TABLETOP_LENGTH);
        private static Receiver _receiver = Controller.GetReceiver();

        IApplicationService _applicationService = new ApplicationService(_map, _receiver);

        [TestMethod]
        public void ShouldReturnFalseWithInvalidInput()
        {
            Assert.IsFalse(_applicationService.Process("ABC"));
        }

        [TestMethod]
        public void ShouldReturnFalseWithEmptyInput()
        {
            Assert.IsFalse(_applicationService.Process(""));
        }

        [TestMethod]
        public void ShouldReturnFalseWithInvalidPlace()
        {
            Assert.IsFalse(_applicationService.Process("PLACE"));
            Assert.IsFalse(_applicationService.Process("PLACE 1"));
            Assert.IsFalse(_applicationService.Process("PLACE 1,2"));
            Assert.IsFalse(_applicationService.Process("PLACE 1,2,3"));
            Assert.IsFalse(_applicationService.Process("PLACE 1,2,ABC"));
        }

        [TestMethod]
        public void ShouldReturnTrueWithValidPlace()
        {
            Assert.IsTrue(_applicationService.Process("PLACE 1,2,NORTH"));
            Assert.AreEqual(_receiver.Map, _map);
            Assert.AreEqual(_receiver.X, 1);
            Assert.AreEqual(_receiver.Y, 2);
            Assert.AreEqual(_receiver.Direction, ENUMERATIONS.DIRECTIONS.NORTH);
            Assert.AreEqual(_receiver.IsValid, true);
        }

        public void ShouldReturnFalseWithExtraOnOtherMethods()
        {
            Assert.IsFalse(_applicationService.Process("MOVE 1"));
            Assert.IsFalse(_applicationService.Process("LFET 2"));
            Assert.IsFalse(_applicationService.Process("RIGHT LEFT"));
            Assert.IsFalse(_applicationService.Process("REPORT 123"));
        }


        [TestMethod]
        public void ShouldReturnTrueWithValidMove()
        {
            Assert.IsTrue(_applicationService.Process("PLACE 1,2,NORTH"));
            Assert.IsTrue(_applicationService.Process("MOVE"));
            Assert.AreEqual(_receiver.Map, _map);
            Assert.AreEqual(_receiver.X, 1);
            Assert.AreEqual(_receiver.Y, 3);
            Assert.AreEqual(_receiver.Direction, ENUMERATIONS.DIRECTIONS.NORTH);
            Assert.AreEqual(_receiver.IsValid, true);
        }

        [TestMethod]
        public void ShouldReturnTrueWithValidLeft()
        {            
            Assert.IsTrue(_applicationService.Process("PLACE 1,2,NORTH"));
            Assert.IsTrue(_applicationService.Process("LEFT"));
            Assert.AreEqual(_receiver.Map, _map);
            Assert.AreEqual(_receiver.X, 1);
            Assert.AreEqual(_receiver.Y, 2);
            Assert.AreEqual(_receiver.Direction, ENUMERATIONS.DIRECTIONS.WEST);
            Assert.AreEqual(_receiver.IsValid, true);
        }

        [TestMethod]
        public void ShouldReturnTrueWithValidRight()
        {
            Assert.IsTrue(_applicationService.Process("PLACE 1,2,NORTH"));
            Assert.IsTrue(_applicationService.Process("RIGHT"));
            Assert.AreEqual(_receiver.Map, _map);
            Assert.AreEqual(_receiver.X, 1);
            Assert.AreEqual(_receiver.Y, 2);
            Assert.AreEqual(_receiver.Direction, ENUMERATIONS.DIRECTIONS.EAST);
            Assert.AreEqual(_receiver.IsValid, true);
        }

        [TestMethod]
        public void ShouldReturnTrueWithValidReport()
        {
            Assert.IsTrue(_applicationService.Process("REPORT"));
        }
    }
}
