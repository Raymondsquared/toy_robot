using System.Collections.Generic;
using ToyRobot.Core.Abstractions;
using ToyRobot.Core.Commands.Implementations;
using ToyRobot.Infrastructure;
using ToyRobot.Infrastructure.Abstractions;
using ToyRobot.Models;

namespace ToyRobot.Factories
{
    public class CommandFactory
    {
        public static Command Create(CommandParameters commandParams, IEnumerable<Receiver> inputReceivers, Map inputMap)
        {
            Command command = null;
            
            switch (commandParams.Command)
            {
                case CONSTANTS.TEXTS.COMMAND_PLACE:
                    command = new PlaceCommand(inputReceivers, inputMap, commandParams.X, commandParams.Y, commandParams.F);
                    break;
                case CONSTANTS.TEXTS.COMMAND_MOVE:
                    command = new MoveCommand(inputReceivers);
                    break;
                case CONSTANTS.TEXTS.COMMAND_LEFT:
                    command = new TurnCommand(inputReceivers, ENUMERATIONS.TURNS.LEFT);
                    break;
                case CONSTANTS.TEXTS.COMMAND_RIGHT:
                    command = new TurnCommand(inputReceivers, ENUMERATIONS.TURNS.RIGHT);
                    break;
                case CONSTANTS.TEXTS.COMMAND_REPORT:
                    command = new ReportCommand(inputReceivers);
                    break;
            }

            return command;
        }        
    }
}
