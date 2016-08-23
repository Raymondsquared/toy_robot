using ToyRobot.Abstractions;

namespace ToyRobot.Models
{
    ///<summary>
    /// Concrete implementation of IMap interface
    ///</summary>
    public class TableTop : IMap
    {
        private readonly int _width;
        private readonly int _length;

        public TableTop(int width, int length)
        {
            _width = width;
            _length = length;
        }

        public int GetWidth()
        {
            return _width;
        }
        public int GetLength()
        {
            return _length;
        }
    }
}
