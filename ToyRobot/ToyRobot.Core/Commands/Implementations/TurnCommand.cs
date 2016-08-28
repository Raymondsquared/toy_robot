using System;
using System.Collections.Generic;
using ToyRobot.Core.Abstractions;
using ToyRobot.Infrastructure;
using ToyRobot.Infrastructure.Abstractions;
using ToyRobot.Infrastructure.Helpers;

namespace ToyRobot.Core.Commands.Implementations
{
    ///<summary>
    /// Concrete implementation of ICommand interface for Command Pattern
    ///</summary>
    ///<remarks>
    /// Handling all turning commmands (left / right), send the command to the receiver to do some actions
    /// LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot.
    ///</remarks>
    public class TurnCommand : Command
    {
        private readonly IEnumerable<Receiver> _receivers;
        private readonly ENUMERATIONS.TURNS _turn;

        public TurnCommand(IEnumerable<Receiver> receivers, ENUMERATIONS.TURNS turn)
        {
            _receivers = receivers;
            _turn = turn;
        }

        public override void Execute()
        {
            foreach (var receiver in _receivers)
            {
                try
                {
                    receiver.Turn(_turn);
                }
                catch (Exception ex)
                {
                    LoggerHelper.Error(ex, "Receiver {0} throws an exception on turn command", receiver.GetType().Name);
                    throw;
                }
            }
            LoggerHelper.Info("receiver's turn method has been triggered");
        }
    }
}

