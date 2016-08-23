using System;
using ToyRobot.Abstractions;

namespace ToyRobot.Commands
{
    ///<summary>
    /// Concrete implementation of ICommand interface for Command Pattern
    ///</summary>
    ///<remarks>
    /// Handling all turning commmands (left / right), send the command to the receiver to do some actions
    ///</remarks>
    public class TurnCommand : ICommand
    {
        private IReveicer _receiver;

        public TurnCommand(IReveicer receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}

