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
    /// Handling all move commmands, send the command to the receiver to do some actions
    /// MOVE will move the toy robot one unit forward in the direction it is currently facing.
    ///</remarks>
    public class MoveCommand : Command
    {
        private readonly IEnumerable<Receiver> _receivers;

        public MoveCommand(IEnumerable<Receiver> receivers)
        {
            _receivers = receivers;
        }

        public override void Execute()
        {
            foreach (var receiver in _receivers)
            {
                try
                {
                    receiver.Move();
                }
                catch (Exception ex)
                {
                    LoggerHelper.Error(ex, "Receiver {0} throws an exception on move command", receiver.GetType().Name);
                    //throw;
                }
            }
            LoggerHelper.Info("receiver's move method has been triggered");
        }
    }
}

