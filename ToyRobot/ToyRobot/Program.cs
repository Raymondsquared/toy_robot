using Autofac;
using ToyRobot.Abstractions;
using ToyRobot.Core.Abstractions;
using ToyRobot.Infrastructure;
using ToyRobot.Infrastructure.Abstractions;
using ToyRobot.IoC;
using ToyRobot.Services;

namespace ToyRobot
{
    ///<summary>
    /// Entry point of the application
    ///</summary>
    ///<remarks>
    /// The application is a simulation of a toy robot moving on a square tabletop, of dimensions 5 units x 5 units.
    /// There are no other obstructions on the table surface.
    /// The robot is free to roam around the surface of the table, but must be prevented from falling to destruction.Any movement that would result in the robot falling from the table must be prevented, however further valid movement commands must still be allowed.
    ///</remarks>
    public class Program
    {
        private static IApplicationService _applicationService;
        
        public static void Main(string[] args)
        {
            /* Autofac DI Container */
            var builder = new ContainerBuilder();
            builder.RegisterModule<BindingModule>();
            var container = builder.Build();
            
            var map = container.Resolve<Map>();
            var receiverProvider = container.Resolve<IProvider<Receiver>>();

            _applicationService = new ApplicationService(map, receiverProvider.Provide());

            /*
             * handle file & keyboard input differently
             * Input can be from a file, or from standard input, as the developer chooses.
             */
            IConsoleApplicationHandler handler;

            if (args.Length > 0 && string.Equals(args[0], CONSTANTS.TEXTS.ARGUMENT_FILE))
            {
                handler = container.ResolveKeyed<IConsoleApplicationHandler>("file");
            }
            else
            {
                handler = container.ResolveKeyed<IConsoleApplicationHandler>("keyboard");
            }
            
            handler.Handle(args, _applicationService);
        }
    }
}
