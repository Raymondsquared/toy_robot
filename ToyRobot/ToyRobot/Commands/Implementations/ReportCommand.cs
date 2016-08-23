using System;
using ToyRobot.Abstractions;

namespace ToyRobot.Commands.Implementations
{
    ///<summary>
    /// Concrete implementation of ICommand interface for Command Pattern
    ///</summary>
    ///<remarks>
    /// Handling all reporting commmands, send the command to the receiver to do some actions
    ///</remarks>
    public class ReportCommand : ICommand
    {
        private Receiver _receiver;

        public ReportCommand(Receiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            if (_receiver.IsValid)
            {
                Console.WriteLine($"{_receiver.X},{_receiver.Y},{_receiver.Direction}");
            }
        }
    }
}

