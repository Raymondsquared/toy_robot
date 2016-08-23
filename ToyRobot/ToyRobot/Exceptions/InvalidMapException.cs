using System;

namespace ToyRobot.Exceptions
{
    ///<summary>
    /// Exception when the map is invalid
    ///</summary>
    public class InvalidMapException : Exception
    {
        public InvalidMapException() { }

        public InvalidMapException(string message) : base(message) { }

        public InvalidMapException(string message, Exception inner) : base(message, inner) { }
    }
}

