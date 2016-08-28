using System;
using System.Collections.Generic;
using System.Linq;
using ToyRobot.Abstractions;
using ToyRobot.Core.Abstractions;
using ToyRobot.Core.Commands;
using ToyRobot.Factories;
using ToyRobot.Infrastructure;
using ToyRobot.Infrastructure.Abstractions;
using ToyRobot.Infrastructure.Helpers;
using ToyRobot.Models;
using ToyRobot.Providers;

namespace ToyRobot.Services
{
    ///<summary>
    /// Application Service for processing input and invoke the method in business logic / domain layer
    ///</summary>
    public class ApplicationService : IApplicationService
    {
        private readonly IProvider<string> _commandProvider;
        private readonly Map _map;
        private readonly IEnumerable<Receiver> _receivers;

        public ApplicationService(Map map, IEnumerable<Receiver> receivers)
        {
            _commandProvider = new CommandProvider();
            _map = map;
            _receivers = receivers;
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
            Command command = null;

            try
            {
                var cmdParams = GetValidRobotParams(input);

                // create command Object from factory method pattern
                if (cmdParams != null)
                    command = CommandFactory.Create(cmdParams, _receivers, _map);
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

        public CommandParameters GetValidRobotParams(string input)
        {
            CommandParameters cmdParams = null;

            if (!string.IsNullOrEmpty(input))
            {
                var inputArray = input.Split(CONSTANTS.TEXTS.SPACE);

                if (_commandProvider.Provide().Contains(inputArray.FirstOrDefault()))
                {
                    //validate and create command for PLACE X,Y,F
                    if (string.Equals(inputArray.FirstOrDefault(), CONSTANTS.TEXTS.COMMAND_PLACE))
                    {
                        var inputParams = inputArray[1].Split(',');

                        //if X,Y,F are supplied
                        if (inputParams.Length == 3)
                        {
                            var direction = DirectionHelper.Convert(inputParams[2]);

                            if (direction == ENUMERATIONS.DIRECTIONS.UNKNOWN)
                                throw new ArgumentException("invalid direction!");

                            cmdParams = new CommandParameters()
                            {
                                Command = CONSTANTS.TEXTS.COMMAND_PLACE,
                                X = Convert.ToInt32(inputParams[0]),
                                Y = Convert.ToInt32(inputParams[1]),
                                F = DirectionHelper.Convert(inputParams[2])
                            };
                        }
                    }
                    //handle MOVE, LEFT, RIGHT, REPORT
                    else
                    {
                        cmdParams = new CommandParameters(input);
                    }
                }
            }

            return cmdParams;
        }
    }
}