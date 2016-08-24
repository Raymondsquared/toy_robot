namespace ToyRobot.Core.Abstractions
{
    ///<summary>
    /// Map Abstract Class where the receiver is going to be placed
    ///</summary>
    public abstract class Map
    {
        public int Width { get; set; }
        public int Length { get; set; }
    }
}