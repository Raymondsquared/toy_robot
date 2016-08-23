using ToyRobot.Abstractions;
using ToyRobot.Models;

namespace ToyRobot.Providers
{
    ///<summary>
    /// Controller that create new instance of robot for Command Pattern
    ///</summary>
    public class ReceiverProvider : IProvider<Receiver>
    {
        public Receiver Provide()
        {
            return new Robot();
        }
    }
}