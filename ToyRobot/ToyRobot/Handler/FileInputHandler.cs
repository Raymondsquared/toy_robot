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
            try
            {
                var file = args[1];

                Console.WriteLine("Reading file from : " + file + "\n");

                var lines = System.IO.File.ReadAllLines(file);

                foreach (var line in lines)
                {
                    applicationService.Process(line);
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("error please specify file name.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("error when reading file: " + ex.Message);
            }
        }
    }
}
