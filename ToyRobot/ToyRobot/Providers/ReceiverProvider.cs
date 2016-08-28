using System.Collections.Generic;
using ToyRobot.Core.Abstractions;
using ToyRobot.Infrastructure.Abstractions;

namespace ToyRobot.Providers
{
    ///<summary>
    /// Controller that create new instance of robot for Command Pattern
    ///</summary>
    public class ReceiverProvider : IProvider<Receiver>
    {
        public IEnumerable<Receiver> Provide()
        {
            return new List<Receiver>()
            {
                new Core.Models.Robot()
            };

        }
    }
}