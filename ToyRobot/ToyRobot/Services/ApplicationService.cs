using System;
using System.Linq;
using ToyRobot.Abstractions;
using ToyRobot.Commands;
using ToyRobot.Commands.Implementations;
using ToyRobot.Helpers;
using ToyRobot.Models;

namespace ToyRobot.Services
{
    ///<summary>
    /// Application Service for processing input and invoke the method on to business logic layer
    ///</summary>
    public class ApplicationService : IApplicationService
    {
        private readonly Map _map;
        private readonly Receiver _receiver;

        public ApplicationService(Map map, Receiver receiver)
        {
            _map = map;
            _receiver = receiver;
        }

        public bool Process(string input)
        {
            var result = false;
            ICommand command = null;

            try
            {
                if (!string.IsNullOrEmpty(input))
                {                    
                    var inputArray = input.Split(' ');

                    if (CONSTANTS.COLLECTIONS.COMMANDS.Contains(inputArray.FirstOrDefault()))
                    {
                        if (string.Equals(inputArray.FirstOrDefault(), CONSTANTS.TEXTS.COMMAND_PLACE))
                        {
                            var inputParams = inputArray[1].Split(',');
                            if (inputParams.Length == 3)
                            {
                                var direction = DirectionHelpers.Convert(inputParams[2]);

                                if (direction == ENUMERATIONS.DIRECTIONS.UNKNOWN)
                                    throw new ArgumentException("invalid direction");

                                command = new PlaceCommand(_receiver, _map, Convert.ToInt32(inputParams[0]), Convert.ToInt32(inputParams[1]), DirectionHelpers.Convert(inputParams[2]));
                            }
                        }
                        else
                        {
                            switch (input)
                            {
                                case CONSTANTS.TEXTS.COMMAND_MOVE:
                                    command = new MoveCommand(_receiver);
                                    break;
                                case CONSTANTS.TEXTS.COMMAND_LEFT:
                                    command = new TurnCommand(_receiver, ENUMERATIONS.TURNS.LEFT);
                                    break;
                                case CONSTANTS.TEXTS.COMMAND_RIGHT:
                                    command = new TurnCommand(_receiver, ENUMERATIONS.TURNS.RIGHT);
                                    break;
                                case CONSTANTS.TEXTS.COMMAND_REPORT:
                                    command = new ReportCommand(_receiver);
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                result = false;
            }

            if (command != null)
            {
                result = true;
                IInvoker invoker = new Invoker(command);
                invoker.Invoke();
            }

            return result;
        }
    }
}