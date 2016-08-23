using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ToyRobot.Abstractions;
using ToyRobot.Commands;
using ToyRobot.Models;
using ToyRobot.Services;

namespace ToyRobot
{
    ///<summary>
    /// Entry point of the application
    ///</summary>    
    public class Program
    {
        private static Map _map = new TableTop(CONSTANTS.NUMBERS.TABLETOP_WIDTH, CONSTANTS.NUMBERS.TABLETOP_LENGTH);
        private static Receiver _receiver = Controller.GetReceiver();

        public static void Main(string[] args)
        {
            IApplicationService applicationService = new ApplicationService(_map, _receiver);
            var success = false;

            /*
             * handle file & keyboard input differently
             */
            if (string.Equals(args[0], CONSTANTS.TEXTS.ARGUMENT_FILE))
            {
                var file = args[1];

                Console.WriteLine("Reading file from : " + file);
                try
                {
                    string[] lines = System.IO.File.ReadAllLines(file);

                    foreach (string line in lines)
                    {
                        applicationService.Process(line);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error when reading file: " + ex.Message);
                }
            }
            else
            {
                string input;
                do
                {
                    if (!success)
                        Console.WriteLine(CONSTANTS.TEXTS.WELCOME);

                    input = Console.ReadLine();
                    success = applicationService.Process(input);

                } while (!string.Equals(input, CONSTANTS.TEXTS.COMMAND_EXIT));
            }
        }
    }
}
