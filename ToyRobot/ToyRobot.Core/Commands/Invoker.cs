using ToyRobot.Infrastructure.Abstractions;

namespace ToyRobot.Core.Commands
{
    ///<summary>
    /// Concrete implementation of IInvoker interface for Command Pattern
    ///</summary>
    public class Invoker : IInvoker
    {
        private readonly Command _command;

        public Invoker(Command command)
        {
            _command = command;
        }

        public void Invoke()
        {
            _command.Execute();
        }
    }
}

