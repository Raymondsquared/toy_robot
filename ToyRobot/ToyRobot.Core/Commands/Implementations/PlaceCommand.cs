using System;
using ToyRobot.Core.Abstractions;
using ToyRobot.Infrastructure;
using ToyRobot.Infrastructure.Abstractions;
using ToyRobot.Infrastructure.Exceptions;
using ToyRobot.Infrastructure.Helpers;
using ToyRobot.Infrastructure.Loggers;

namespace ToyRobot.Core.Commands.Implementations
{
    ///<summary>
    /// Concrete implementation of ICommand interface for Command Pattern
    ///</summary>
    ///<remarks>
    /// Handling all place commmands, send the command to the receiver to do some actions
    /// PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST.
    /// The origin (0,0) can be considered to be the SOUTH WEST most corner.
    ///</remarks>
    public class PlaceCommand : Command
    {
        private readonly Receiver _receiver;
        private readonly Map _map;
        private readonly int _x;
        private readonly int _y;
        private readonly ENUMERATIONS.DIRECTIONS _direction;

        public PlaceCommand(Receiver receiver, Map map, int x, int y, ENUMERATIONS.DIRECTIONS direction)
        {
            _receiver = receiver;
            _map = map;
            _x = x;
            _y = y;
            _direction = direction;
        }

        /*
         * The first valid command to the robot is a PLACE command, after that, any sequence of commands may be issued, in any order, including another PLACE command. The application should discard all commands in the sequence until a valid PLACE command has been executed.
         * A robot that is not on the table can choose the ignore the MOVE, LEFT, RIGHT and REPORT commands.
         */
        public override void Execute()
        {
            var isValid = true;

            try
            {
                //validate map
                if (_map == null)
                {
                    isValid = false;
                    var ire = new InvalidReceiverException("can't place receiver in nothing");
                    LoggerHelper.Error(ire, "no map available");
                    throw ire;
                }

                //check location for negative values
                if (_x < 0 || _y < 0)
                {
                    isValid = false;
                    LoggerHelper.Warn("x or y is less than 0");
                }

                //check location for outbound values
                if (_x > _map?.Width || _y > _map?.Length)
                {
                    LoggerHelper.Warn("x or y is larger than the map");
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

                    LoggerHelper.Info("object has been placed and is valid is true");
                }
            }            

        }
    }
}

