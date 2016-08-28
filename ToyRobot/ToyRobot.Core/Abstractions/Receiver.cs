using ToyRobot.Infrastructure;

namespace ToyRobot.Core.Abstractions
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

        public abstract void Place(Map map, int x, int y, ENUMERATIONS.DIRECTIONS direction);
        public abstract void Move();
        public abstract void Turn(ENUMERATIONS.TURNS turn);
        public abstract void Report();
    }
}

