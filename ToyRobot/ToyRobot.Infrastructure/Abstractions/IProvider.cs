using System.Collections.Generic;

namespace ToyRobot.Infrastructure.Abstractions
{
    ///<summary>
    /// IApplicationService Interface for Application Service
    ///</summary>
    public interface IProvider<out T>
    {
        IEnumerable<T> Provide();
    }
}

