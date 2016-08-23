using ToyRobot.Abstractions;

namespace ToyRobot.Commands
{
    ///<summary>
    /// Concrete implementation of IInvoker interface for Command Pattern
    ///</summary>
    public class Invoker : IInvoker
    {
        private ICommand _command;

        public Invoker(ICommand command)
        {
            _command = command;
        }

        public void Invoke()
        {
            _command.Execute();
        }
    }
}

