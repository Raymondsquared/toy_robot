using ToyRobot.Core.Abstractions;
using ToyRobot.Core.Commands.Implementations;
using ToyRobot.Infrastructure;
using ToyRobot.Infrastructure.Abstractions;
using ToyRobot.Models;

namespace ToyRobot.Factories
{
    public class CommandFactory
    {
        public static Command Create(CommandParameters commandParams, Receiver inputReceiver, Map inputMap)
        {
            Command command = null;
            
            switch (commandParams.Command)
            {
                case CONSTANTS.TEXTS.COMMAND_PLACE:
                    command = new PlaceCommand(inputReceiver, inputMap, commandParams.X, commandParams.Y, commandParams.F);
                    break;
                case CONSTANTS.TEXTS.COMMAND_MOVE:
                    command = new MoveCommand(inputReceiver);
                    break;
                case CONSTANTS.TEXTS.COMMAND_LEFT:
                    command = new TurnCommand(inputReceiver, ENUMERATIONS.TURNS.LEFT);
                    break;
                case CONSTANTS.TEXTS.COMMAND_RIGHT:
                    command = new TurnCommand(inputReceiver, ENUMERATIONS.TURNS.RIGHT);
                    break;
                case CONSTANTS.TEXTS.COMMAND_REPORT:
                    command = new ReportCommand(inputReceiver);
                    break;
            }

            return command;
        }        
    }
}
