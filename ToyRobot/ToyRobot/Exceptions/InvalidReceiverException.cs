using System;

namespace ToyRobot.Exceptions
{
    ///<summary>
    /// Exception when the map is invalid
    ///</summary>
    public class InvalidReceiverException : Exception
    {
        public InvalidReceiverException() { }

        public InvalidReceiverException(string message) : base(message) { }

        public InvalidReceiverException(string message, Exception inner) : base(message, inner) { }
    }
}

