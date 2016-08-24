using System;
using ToyRobot.Abstractions;

namespace ToyRobot.Handler
{
    ///<summary>
    /// handle file input, pass the logic to application service layer
    ///</summary>    
    public class FileInputHandler : IConsoleApplicationHandler
    {
        public void Handle(string[] args, IApplicationService applicationService)
        {
            var file = args[1];

            Console.WriteLine("Reading file from : " + file + "\n");
            try
            {
                var lines = System.IO.File.ReadAllLines(file);

                foreach (var line in lines)
                {
                    applicationService.Process(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error when reading file: " + ex.Message);
            }
        }
    }
}
