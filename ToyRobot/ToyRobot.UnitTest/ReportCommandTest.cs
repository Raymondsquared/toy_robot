using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Core.Commands.Implementations;
using ToyRobot.Core.Models;
using ToyRobot.Infrastructure;

namespace ToyRobot.UnitTest
{
    [TestClass]
    public class ReportCommandTest
    {

        [TestMethod]
        public void ShouldReturnWithValidDataForReportCommand()
        {
            var map = new TableTop(5, 5);
            var receiver = new Robot();

            var command1 = new PlaceCommand(receiver, map, 1, 1, ENUMERATIONS.DIRECTIONS.NORTH);
            command1.Execute();

            var command2 = new ReportCommand(receiver);
            command2.Execute();

            Assert.AreEqual(receiver.Map, map);
            Assert.AreEqual(receiver.X, 1);
            Assert.AreEqual(receiver.Y, 1);
            Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.NORTH);
            Assert.AreEqual(receiver.IsValid, true);
        }


        [TestMethod]
        public void ShouldReturnWithInvalidDataForReportCommand()
        {
            var map = new TableTop(5, 5);
            var receiver = new Robot();
            var command1 = new ReportCommand(receiver);
            command1.Execute();
            Assert.IsNull(receiver.Map);
            Assert.AreEqual(receiver.X, 0);
            Assert.AreEqual(receiver.Y, 0);
            Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.UNKNOWN);
            Assert.AreEqual(receiver.IsValid, false);
            var command2 = new ReportCommand(receiver);
            command2.Execute();
            Assert.IsNull(receiver.Map);
            Assert.AreEqual(receiver.X, 0);
            Assert.AreEqual(receiver.Y, 0);
            Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.UNKNOWN);
            Assert.AreEqual(receiver.IsValid, false);
            var command3 = new PlaceCommand(receiver, map, 1, 1, ENUMERATIONS.DIRECTIONS.NORTH);
            command3.Execute();      
            Assert.AreEqual(receiver.Map, map);
            Assert.AreEqual(receiver.X, 1);
            Assert.AreEqual(receiver.Y, 1);
            Assert.AreEqual(receiver.Direction, ENUMERATIONS.DIRECTIONS.NORTH);
            Assert.AreEqual(receiver.IsValid, true);
        }
    }
}
