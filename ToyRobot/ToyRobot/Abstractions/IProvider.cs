namespace ToyRobot.Abstractions
{
    ///<summary>
    /// IApplicationService Interface for Application Service
    ///</summary>
    public interface IProvider<out T>
    {
        T Provide();
    }
}

