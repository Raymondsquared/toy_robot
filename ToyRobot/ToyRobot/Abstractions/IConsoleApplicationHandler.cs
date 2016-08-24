using ToyRobot.Infrastructure.Abstractions;

namespace ToyRobot.Abstractions
{
    ///<summary>
    /// handle file input, pass the logic to application service layer
    ///</summary>    
    public interface IConsoleApplicationHandler : IHandler
    {
        void Handle(string[] args, IApplicationService applicationService);
    }
}
