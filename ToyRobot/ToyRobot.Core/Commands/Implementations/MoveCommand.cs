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
    /// Handling all move commmands, send the command to the receiver to do some actions
    /// MOVE will move the toy robot one unit forward in the direction it is currently facing.
    ///</remarks>
    public class MoveCommand : Command
    {
        private readonly Receiver _receiver;

        public MoveCommand(Receiver receiver)
        {
            _receiver = receiver;
        }

        public override void Execute()
        {
            if (_receiver.IsValid)
            {
                switch (_receiver.Direction)
                {
                    case ENUMERATIONS.DIRECTIONS.NORTH:
                        if (_receiver.Y < _receiver.Map.Width) _receiver.Y++;
                        break;
                    case ENUMERATIONS.DIRECTIONS.EAST:
                        if (_receiver.X < _receiver.Map.Length) _receiver.X++;
                        break;
                    case ENUMERATIONS.DIRECTIONS.SOUTH:
                        if (_receiver.Y > 0) _receiver.Y--;
                        break;
                    case ENUMERATIONS.DIRECTIONS.WEST:
                        if (_receiver.X > 0) _receiver.X--;
                        break;
                    case ENUMERATIONS.DIRECTIONS.UNKNOWN:
                        LoggerHelper.Warn("Unknown direction!");
                        break;
                }
            }
        }
    }
}

