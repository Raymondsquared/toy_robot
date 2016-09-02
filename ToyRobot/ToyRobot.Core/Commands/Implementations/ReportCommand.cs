using System;
using System.Collections.Generic;
using ToyRobot.Core.Abstractions;
using ToyRobot.Infrastructure.Abstractions;
using ToyRobot.Infrastructure.Helpers;

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
        private readonly IEnumerable<Receiver> _receivers;

        public ReportCommand(IEnumerable<Receiver> receivers)
        {
            _receivers = receivers;
        }

        public override void Execute()
        {
            foreach (var receiver in _receivers)
            {
                try
                {
                    receiver.Report();
                }
                catch (Exception ex)
                {
                    LoggerHelper.Error(ex, "Receiver {0} throws an exception on report command", receiver.GetType().Name);
                    //throw;
                }
            }
            LoggerHelper.Info("receiver's report method has been triggered");
        }
    }
}

