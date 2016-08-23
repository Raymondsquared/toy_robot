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
            IMap map = new TableTop(5, 5);
            IReveicer reveicer = Controller.GetReceiver(map);

            /*
             * Bind receivers to the commands
             */
            ICommand placeCommand = new PlaceCommand(reveicer);
            ICommand moveCommand = new MoveCommand(reveicer);
            ICommand turnCommand = new TurnCommand(reveicer);
            ICommand reportCommand = new ReportCommand(reveicer);

            /*
             * Bind commands to the invokers
             */
            IInvoker onPlaceInvoked = new Invoker(placeCommand);
            IInvoker onMoveInvoked = new Invoker(moveCommand);
            IInvoker onTurnInvoked = new Invoker(turnCommand);
            IInvoker onReportInvoked = new Invoker(reportCommand);

            //onPlaceInvoked.Invoke();
            //onMoveInvoked.Invoke();
            //onTurnInvoked.Invoke();
            //onReportInvoked.Invoke();
        }        
    }
}
