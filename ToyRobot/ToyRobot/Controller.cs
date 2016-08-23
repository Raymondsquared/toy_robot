using ToyRobot.Abstractions;
using ToyRobot.Models;

namespace ToyRobot
{
    ///<summary>
    /// Controller that create new instance of robot for Command Pattern
    ///</summary>
    public class Controller
    {
        public static IReveicer GetReceiver(IMap input)
        {
            return new Robot(input);
        }
    }
}