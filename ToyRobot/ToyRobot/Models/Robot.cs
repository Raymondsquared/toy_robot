using System;
using ToyRobot.Abstractions;

namespace ToyRobot.Models
{
    ///<summary>
    /// Concrete implementation of IReceiver interface for Command Pattern
    ///</summary>
    public class Robot : IReveicer
    {
        private int? _x;
        private int? _y;
        private ENUMERATIONS.DIRECTIONS? _direction;

        private IMap _map;    

        public Robot(IMap map)
        {
            //_x = 0;
            //_y = 0;
            //_direction = ENUMERATIONS.DIRECTIONS.NORTH;

            _map = map;
        }

        public void Place()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }
        public void Turn()
        {
            throw new NotImplementedException();
        }

        public void Report()
        {
            throw new NotImplementedException();
        }
    }
}

