using System;
using ToyRobot.Abstractions;
using ToyRobot.Exceptions;

namespace ToyRobot.Commands
{
    ///<summary>
    /// Concrete implementation of ICommand interface for Command Pattern
    ///</summary>
    ///<remarks>
    /// Handling all place commmands, send the command to the receiver to do some actions
    ///</remarks>
    public class PlaceCommand : ICommand
    {
        private Receiver _receiver;
        private Map _map;
        private int _x;
        private int _y;
        private ENUMERATIONS.DIRECTIONS _direction;

        public PlaceCommand(Receiver receiver, Map map, int x, int y, ENUMERATIONS.DIRECTIONS direction)
        {
            _receiver = receiver;
            _map = map;
            _x = x;
            _y = y;
            _direction = direction;
        }

        public void Execute()
        {
            var isValid = true;

            try
            {
                //validate map
                if (_map == null)
                {
                    isValid = false;
                    throw new InvalidReceiverException("can't place receiver in nothing");
                }

                //check location for negative values
                if (_x < 0 || _y < 0)
                {
                    isValid = false;
                }

                //check location for outbound values
                if (_x > _map.Width || _y > _map.Length)
                {
                    isValid = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _receiver.IsValid = isValid;

                if (isValid)
                {
                    _receiver.Map = _map;
                    _receiver.X = _x;
                    _receiver.Y = _y;
                    _receiver.Direction = _direction;
                }
            }            

        }
    }
}

