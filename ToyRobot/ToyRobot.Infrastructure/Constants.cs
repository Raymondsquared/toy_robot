namespace ToyRobot.Infrastructure
{
    ///<summary>
    /// Collection of constants
    ///</summary>
    public static class CONSTANTS
    {
        public static class TEXTS
        {
            public const string WELCOME = "\nALLOWED COMMANDS : PLACE X,Y,F & MOVE & LEFT & RIGHT & REPORT & EXIT\nplease enter your input : \n";

            public const string CONFIG_MAP_WIDTH = "Map.Width";
            public const string CONFIG_MAP_LENGTH = "Map.Length";

            public const string ARGUMENT_FILE = "-f";

            public const string COMMAND_PLACE = "PLACE";
            public const string COMMAND_MOVE = "MOVE";
            public const string COMMAND_LEFT = "LEFT";
            public const string COMMAND_RIGHT = "RIGHT";
            public const string COMMAND_REPORT = "REPORT";
            public const string COMMAND_EXIT = "EXIT";

            public const char SPACE = ' ';
        }
        public static class NUMBERS
        {
            public const int TABLETOP_WIDTH = 5;
            public const int TABLETOP_LENGTH = 5;
        }
    }
}
