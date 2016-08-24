using ToyRobot.Infrastructure;namespace ToyRobot.Models
{
    ///<summary>
    /// Concrete implementation of IReceiver interface for Command Pattern
    ///</summary>
    public class CommandParameters
    {
        public CommandParameters(){}
        public CommandParameters(string inputCommand)
        {
            Command = inputCommand;
        }

        public string Command { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public ENUMERATIONS.DIRECTIONS F { get; set; }
    }
}

