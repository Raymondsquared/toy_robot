using ToyRobot.Abstractions;
using ToyRobot.Commands;
using ToyRobot.Models;

namespace ToyRobot
{
    ///<summary>
    /// Entry point of the application
    ///</summary>    
    public class Program
    {
        public static void Main(string[] args)
        {
            Map map = new TableTop(CONSTANTS.NUMBERS.TABLETOP_WIDTH, CONSTANTS.NUMBERS.TABLETOP_LENGTH);
            Receiver receiver = Controller.GetReceiver();

            /*
             * Bind receivers to the commands
             */
            ICommand placeCommand = new PlaceCommand(receiver, map, 1, 2, ENUMERATIONS.DIRECTIONS.NORTH);
            ICommand moveCommand = new MoveCommand(receiver);
            ICommand turnCommand = new TurnCommand(receiver, ENUMERATIONS.TURNS.LEFT);
            ICommand reportCommand = new ReportCommand(receiver);

            /*
             * Bind commands to the invokers
             */
            IInvoker onPlaceInvoked = new Invoker(placeCommand);
            IInvoker onMoveInvoked = new Invoker(moveCommand);
            IInvoker onTurnInvoked = new Invoker(turnCommand);
            IInvoker onReportInvoked = new Invoker(reportCommand);

            onPlaceInvoked.Invoke();
            onMoveInvoked.Invoke();
            onTurnInvoked.Invoke();
            onReportInvoked.Invoke();
        }        
    }
}
