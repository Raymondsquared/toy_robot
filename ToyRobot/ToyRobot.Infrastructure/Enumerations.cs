namespace ToyRobot.Infrastructure
{
    ///<summary>
    /// collections of enumerations
    ///</summary>
    public static class ENUMERATIONS
    {
        public enum DIRECTIONS
        {
            UNKNOWN,
            NORTH,
            EAST,
            SOUTH,
            WEST
        }

        public enum TURNS
        {
            LEFT,
            RIGHT,
        }

        public enum LOG_LEVEL
        {
            DEBUG,
            INFO,
            WARN,
            ERROR
        }
    }
}
