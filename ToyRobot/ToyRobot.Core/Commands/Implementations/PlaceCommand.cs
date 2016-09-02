using System;
using System.Collections.Generic;
using ToyRobot.Core.Abstractions;
using ToyRobot.Infrastructure;
using ToyRobot.Infrastructure.Abstractions;
using ToyRobot.Infrastructure.Helpers;

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
        private readonly IEnumerable<Receiver> _receivers;
        private readonly Map _map;
        private readonly int _x;
        private readonly int _y;
        private readonly ENUMERATIONS.DIRECTIONS _direction;

        public PlaceCommand(IEnumerable<Receiver> receivers, Map map, int x, int y, ENUMERATIONS.DIRECTIONS direction)
        {
            _receivers = receivers;
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
            foreach (var receiver in _receivers)
            {
                try
                {
                    receiver.Place(_map, _x, _y, _direction);
                }
                catch (Exception ex)
                {
                    LoggerHelper.Error(ex, "Receiver {0} throws an exception on place command", receiver.GetType().Name);
                    //throw;
                }
            }
            LoggerHelper.Info("receiver's place method has been triggered");
        }
    }
}

