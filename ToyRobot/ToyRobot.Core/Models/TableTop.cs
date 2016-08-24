using ToyRobot.Core.Abstractions;
using ToyRobot.Infrastructure.Exceptions;

namespace ToyRobot.Core.Models
{
    ///<summary>
    /// Concrete implementation of IMap interface
    ///</summary>
    public class TableTop : Map
    {
        public TableTop(int width, int length)
        {
            if (width < 1 || length < 1)
                throw new InvalidMapException("Table top size has to be bigger than 0");

            Width = width;
            Length = length;
        }
    }
}
