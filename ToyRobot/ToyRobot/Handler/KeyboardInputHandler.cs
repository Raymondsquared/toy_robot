using System;
using ToyRobot.Abstractions;
using ToyRobot.Infrastructure;

namespace ToyRobot.Handler
{
    ///<summary>
    /// handle keyboard inputs, pass the logic to application service layer
    ///</summary>    
    ///<remarks>
    /// command : -f "filename.txt" 
    ///</remarks>
    public class KeyboardInputHandler : IConsoleApplicationHandler
    {
        public void Handle(string[] input, IApplicationService applicationService)
        {
            var success = false;

            string userInput;
            do
            {
                if (!success)
                    Console.WriteLine(CONSTANTS.TEXTS.WELCOME);

                userInput = Console.ReadLine();
                success = applicationService.Process(userInput);

            } while (!string.Equals(userInput, CONSTANTS.TEXTS.COMMAND_EXIT));
        }
    }
}
