namespace ToyRobot.Abstractions
{
    ///<summary>
    /// Map Interface for where the receiver is going to be placed
    ///</summary>
    public interface IMap
    {
        int GetWidth();
        int GetLength();

    }
}