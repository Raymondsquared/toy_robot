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
    /// Handling all turning commmands (left / right), send the command to the receiver to do some actions
    /// LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot.
    ///</remarks>
    public class TurnCommand : Command
    {
        private readonly Receiver _receiver;
        private readonly ENUMERATIONS.TURNS _turn;

        public TurnCommand(Receiver receiver, ENUMERATIONS.TURNS turn)
        {
            _receiver = receiver;
            _turn = turn;
        }

        public override void Execute()
        {
            if (_receiver.IsValid)
            {
                switch (_receiver.Direction)
                {
                    case ENUMERATIONS.DIRECTIONS.NORTH:
                        if (_turn == ENUMERATIONS.TURNS.LEFT) _receiver.Direction = ENUMERATIONS.DIRECTIONS.WEST;
                        if (_turn == ENUMERATIONS.TURNS.RIGHT) _receiver.Direction = ENUMERATIONS.DIRECTIONS.EAST;
                        break;
                    case ENUMERATIONS.DIRECTIONS.EAST:
                        if (_turn == ENUMERATIONS.TURNS.LEFT) _receiver.Direction = ENUMERATIONS.DIRECTIONS.NORTH;
                        if (_turn == ENUMERATIONS.TURNS.RIGHT) _receiver.Direction = ENUMERATIONS.DIRECTIONS.SOUTH;
                        break;
                    case ENUMERATIONS.DIRECTIONS.SOUTH:
                        if (_turn == ENUMERATIONS.TURNS.LEFT) _receiver.Direction = ENUMERATIONS.DIRECTIONS.EAST;
                        if (_turn == ENUMERATIONS.TURNS.RIGHT) _receiver.Direction = ENUMERATIONS.DIRECTIONS.WEST;
                        break;
                    case ENUMERATIONS.DIRECTIONS.WEST:
                        if (_turn == ENUMERATIONS.TURNS.LEFT) _receiver.Direction = ENUMERATIONS.DIRECTIONS.SOUTH;
                        if (_turn == ENUMERATIONS.TURNS.RIGHT) _receiver.Direction = ENUMERATIONS.DIRECTIONS.NORTH;
                        break;
                    case ENUMERATIONS.DIRECTIONS.UNKNOWN:
                        LoggerHelper.Warn($"invalid direction");
                        break;
                }
            }
        }
    }
}

