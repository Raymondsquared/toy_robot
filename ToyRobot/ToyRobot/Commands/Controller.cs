using ToyRobot.Abstractions;
using ToyRobot.Models;

namespace ToyRobot.Commands
{
    ///<summary>
    /// Controller that create new instance of robot for Command Pattern
    ///</summary>
    public class Controller
    {
        public static Receiver GetReceiver()
        {
            return new Robot();
        }
    }
}