namespace ToyRobot.Abstractions
{
    ///<summary>
    /// Receiver Interface for Command Pattern
    ///</summary>    
    ///<remarks>
    /// includes 4 dictinct operations it's going to perform
    /// * place
    /// * move
    /// * turn
    /// * report
    ///</remarks>
    public interface IReveicer
    {
        void Place();
        void Move();
        void Turn(); 
        void Report();
    }
}

