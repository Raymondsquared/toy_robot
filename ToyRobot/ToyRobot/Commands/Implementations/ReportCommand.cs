using System;
using ToyRobot.Abstractions;
using ToyRobot.Loggers;

namespace ToyRobot.Commands.Implementations
{
    ///<summary>
    /// Concrete implementation of ICommand interface for Command Pattern
    ///</summary>
    ///<remarks>
    /// Handling all reporting commmands, send the command to the receiver to do some actions
    /// REPORT will announce the X,Y and F of the robot. This can be in any form, but standard output is sufficient.
    ///</remarks>
    public class ReportCommand : ICommand
    {
        private readonly Receiver _receiver;
        private readonly ILogger _logger;

        public ReportCommand(Receiver receiver)
        {
            _receiver = receiver;
            _logger = new InMemoryLogger();
        }

        public void Execute()
        {
            if (_receiver.IsValid)
            {
                var report = $"Reporting from : {_receiver.X},{_receiver.Y},{_receiver.Direction}";
                _logger.Info(report);
                Console.WriteLine(report);
            }
        }
    }
}

