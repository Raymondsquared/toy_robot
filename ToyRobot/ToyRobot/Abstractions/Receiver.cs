namespace ToyRobot.Abstractions
{
    ///<summary>
    /// Receiver Abstract class for Command Pattern
    ///</summary>
    public abstract class Receiver
    {
        public Map Map { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public ENUMERATIONS.DIRECTIONS Direction { get; set; }
        public bool IsValid { get; set; }
    }
}

