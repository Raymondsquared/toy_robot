using System;
using ToyRobot.Core.Abstractions;
using ToyRobot.Infrastructure.Abstractions;
using ToyRobot.Infrastructure.Helpers;
using ToyRobot.Infrastructure.Loggers;

namespace ToyRobot.Core.Commands.Implementations
{
    ///<summary>
    /// Concrete implementation of ICommand interface for Command Pattern
    ///</summary>
    ///<remarks>
    /// Handling all reporting commmands, send the command to the receiver to do some actions
    /// REPORT will announce the X,Y and F of the robot. This can be in any form, but standard output is sufficient.
    ///</remarks>
    public class ReportCommand : Command
    {
        private readonly Receiver _receiver;

        public ReportCommand(Receiver receiver)
        {
            _receiver = receiver;
        }

        public override void Execute()
        {
            if (_receiver.IsValid)
            {
                var report = $"Reporting from : {_receiver.X},{_receiver.Y},{_receiver.Direction}";
                LoggerHelper.Info(report);
                Console.WriteLine(report);
            }
        }
    }
}

