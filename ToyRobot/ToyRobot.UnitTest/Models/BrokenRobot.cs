using System;
using ToyRobot.Core.Abstractions;
using ToyRobot.Infrastructure;

namespace ToyRobot.UnitTest.Models
{
    public class BrokenRobot : Receiver
    {
        public override void Place(Map map, int x, int y, ENUMERATIONS.DIRECTIONS direction)
        {
            throw new Exception("Broken Robot");
        }

        public override void Move()
        {
            throw new Exception("Broken Robot");
        }

        public override void Turn(ENUMERATIONS.TURNS turn)
        {
            throw new Exception("Broken Robot");
        }

        public override void Report()
        {
            throw new Exception("Broken Robot");
        }
    }
}
