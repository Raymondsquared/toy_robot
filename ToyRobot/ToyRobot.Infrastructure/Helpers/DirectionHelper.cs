using System;

namespace ToyRobot.Infrastructure.Helpers
{
    public static class DirectionHelper
    {
        public static ENUMERATIONS.DIRECTIONS Convert(string input)
        {
            var result = ENUMERATIONS.DIRECTIONS.UNKNOWN;
            try
            {
                switch (input)
                {
                    case "NORTH":
                        result = ENUMERATIONS.DIRECTIONS.NORTH;
                        break;
                    case "EAST":
                        result = ENUMERATIONS.DIRECTIONS.EAST;
                        break;
                    case "SOUTH":
                        result = ENUMERATIONS.DIRECTIONS.SOUTH;
                        break;
                    case "WEST":
                        result = ENUMERATIONS.DIRECTIONS.WEST;
                        break;
                }
            }
            catch (Exception)
            {
                //ignored
            }

            return result;
        }
    }
}
