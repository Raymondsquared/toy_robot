using System.Collections.Generic;
using ToyRobot.Abstractions;

namespace ToyRobot.Providers
{
    ///<summary>
    /// Controller that create new instance of robot for Command Pattern
    ///</summary>
    public class CommandProvider : IProvider<IEnumerable<string>>
    {
        public IEnumerable<string> Provide()
        {
            return new List<string>()
            {
                "PLACE",
                "MOVE",
                "LEFT",
                "RIGHT",
                "REPORT"
            };
        }
    }
}