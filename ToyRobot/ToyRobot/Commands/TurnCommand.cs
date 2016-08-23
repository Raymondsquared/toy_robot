using ToyRobot.Abstractions;

namespace ToyRobot.Commands
{
    ///<summary>
    /// Concrete implementation of ICommand interface for Command Pattern
    ///</summary>
    ///<remarks>
    /// Handling all turning commmands (left / right), send the command to the receiver to do some actions
    ///</remarks>
    public class TurnCommand : ICommand
    {
        private Receiver _receiver;
        private ENUMERATIONS.TURNS _turn;

        public TurnCommand(Receiver receiver, ENUMERATIONS.TURNS turn)
        {
            _receiver = receiver;
            _turn = turn;
        }

        public void Execute()
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
                }
            }
        }
    }
}

