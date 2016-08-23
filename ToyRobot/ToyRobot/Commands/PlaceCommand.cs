using System;
using ToyRobot.Abstractions;

namespace ToyRobot.Commands
{
    ///<summary>
    /// Concrete implementation of ICommand interface for Command Pattern
    ///</summary>
    ///<remarks>
    /// Handling all move commmands, send the command to the receiver to do some actions
    ///</remarks>
    public class PlaceCommand : ICommand
    {
        private IReveicer _receiver;

        public PlaceCommand(IReveicer receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}

