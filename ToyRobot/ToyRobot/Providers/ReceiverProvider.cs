using ToyRobot.Core.Abstractions;
using ToyRobot.Infrastructure.Abstractions;

namespace ToyRobot.Providers
{
    ///<summary>
    /// Controller that create new instance of robot for Command Pattern
    ///</summary>
    public class ReceiverProvider : IProvider<Receiver>
    {
        public Receiver Provide()
        {
            return new Core.Models.Robot();
        }
    }
}