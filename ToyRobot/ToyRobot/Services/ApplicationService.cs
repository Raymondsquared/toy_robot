using System;
using System.Collections.Generic;
using System.Linq;
using ToyRobot.Abstractions;
using ToyRobot.Commands;
using ToyRobot.Commands.Implementations;
using ToyRobot.Helpers;
using ToyRobot.Providers;

namespace ToyRobot.Services
{
    ///<summary>
    /// Application Service for processing input and invoke the method in business logic / domain layer
    ///</summary>
    public class ApplicationService : IApplicationService
    {
        private readonly IProvider<IEnumerable<string>> _commandProvider;
        private readonly Map _map;
        private readonly Receiver _receiver;

        public ApplicationService(Map map, Receiver receiver)
        {
            _commandProvider = new CommandProvider();
            _map = map;
            _receiver = receiver;
        }

        /* 
         * Process inputs to command handler :
         * 
         * accepted commands:
         * PLACE X,Y,F
         * MOVE
         * LEFT
         * RIGHT
         * REPORT
         */
        public bool Process(string input)
        {
            var result = false;
            ICommand command = null;

            try
            {
                if (!string.IsNullOrEmpty(input))
                {
                    var inputArray = input.Split(CONSTANTS.TEXTS.SPACE);

                    if (_commandProvider.Provide().Contains(inputArray.FirstOrDefault()))
                    {
                        //validate and create handle PLACE X,Y,F - command
                        if (string.Equals(inputArray.FirstOrDefault(), CONSTANTS.TEXTS.COMMAND_PLACE))
                        {
                            var inputParams = inputArray[1].Split(',');
                            if (inputParams.Length == 3)
                            {
                                var direction = DirectionHelper.Convert(inputParams[2]);

                                if (direction == ENUMERATIONS.DIRECTIONS.UNKNOWN)
                                    throw new ArgumentException("invalid direction!");

                                command = new PlaceCommand(_receiver, _map, 
                                    Convert.ToInt32(inputParams[0]),
                                    Convert.ToInt32(inputParams[1]), 
                                    DirectionHelper.Convert(inputParams[2]));
                            }
                        }
                        else
                        {
                            //handle MOVE, LEFT, RIGHT, REPORT
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
            finally
            {
                // invoke command in business logic / domain layer
                if (command != null)
                {
                    result = true;
                    IInvoker invoker = new Invoker(command);
                    invoker.Invoke();
                }
            }            

            return result;
        }
    }
}