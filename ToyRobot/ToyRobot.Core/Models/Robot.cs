using System;
using ToyRobot.Core.Abstractions;
using ToyRobot.Infrastructure;
using ToyRobot.Infrastructure.Exceptions;
using ToyRobot.Infrastructure.Helpers;

namespace ToyRobot.Core.Models
{
    ///<summary>
    /// Concrete implementation of IReceiver interface for Command Pattern
    ///</summary>
    public class Robot : Receiver
    {
        ///<summary>
        /// Handling all place commmands, send the command to the receiver to do some actions
        /// PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST.
        /// The origin (0,0) can be considered to be the SOUTH WEST most corner.
        ///</summary>
        public override void Place(Map map, int x, int y, ENUMERATIONS.DIRECTIONS direction)
        {
            var isValid = true;

            try
            {
                //validate map
                if (map == null)
                {
                    isValid = false;
                    var ire = new InvalidReceiverException("can't place receiver in nothing");
                    LoggerHelper.Error(ire, "no map available");
                    throw ire;
                }

                //check location for negative values
                if (x < 0 || y < 0)
                {
                    isValid = false;
                    LoggerHelper.Warn("x or y is less than 0");
                }

                //check location for outbound values
                if (x > map?.Width || y > map?.Length)
                {
                    LoggerHelper.Warn("x or y is larger than the map");
                    isValid = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                IsValid = isValid;

                if (isValid)
                {
                    Map = map;
                    X = x;
                    Y = y;
                    Direction = direction;
                    LoggerHelper.Info("object has been placed");
                }
            }
        }

        ///<summary>
        /// Handling all move commmands, send the command to the receiver to do some actions
        /// MOVE will move the toy robot one unit forward in the direction it is currently facing.
        ///</summary>
        public override void Move()
        {
            if (IsValid)
            {
                switch (Direction)
                {
                    case ENUMERATIONS.DIRECTIONS.NORTH:
                        if (Y < Map.Width) Y++;
                        break;
                    case ENUMERATIONS.DIRECTIONS.EAST:
                        if (X < Map.Length) X++;
                        break;
                    case ENUMERATIONS.DIRECTIONS.SOUTH:
                        if (Y > 0) Y--;
                        break;
                    case ENUMERATIONS.DIRECTIONS.WEST:
                        if (X > 0) X--;
                        break;
                    case ENUMERATIONS.DIRECTIONS.UNKNOWN:
                        LoggerHelper.Warn("Unknown direction!");
                        break;
                    default:
                        break;
                }
            }
        }

        ///<summary>
        /// Handling all turning commmands (left / right), send the command to the receiver to do some actions
        /// LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot.
        ///</summary>
        public override void Turn(ENUMERATIONS.TURNS turn)
        {
            if (IsValid)
            {

                switch (Direction)
                {
                    case ENUMERATIONS.DIRECTIONS.NORTH:
                        if (turn == ENUMERATIONS.TURNS.LEFT) Direction = ENUMERATIONS.DIRECTIONS.WEST;
                        if (turn == ENUMERATIONS.TURNS.RIGHT) Direction = ENUMERATIONS.DIRECTIONS.EAST;
                        break;
                    case ENUMERATIONS.DIRECTIONS.EAST:
                        if (turn == ENUMERATIONS.TURNS.LEFT) Direction = ENUMERATIONS.DIRECTIONS.NORTH;
                        if (turn == ENUMERATIONS.TURNS.RIGHT) Direction = ENUMERATIONS.DIRECTIONS.SOUTH;
                        break;
                    case ENUMERATIONS.DIRECTIONS.SOUTH:
                        if (turn == ENUMERATIONS.TURNS.LEFT) Direction = ENUMERATIONS.DIRECTIONS.EAST;
                        if (turn == ENUMERATIONS.TURNS.RIGHT) Direction = ENUMERATIONS.DIRECTIONS.WEST;
                        break;
                    case ENUMERATIONS.DIRECTIONS.WEST:
                        if (turn == ENUMERATIONS.TURNS.LEFT) Direction = ENUMERATIONS.DIRECTIONS.SOUTH;
                        if (turn == ENUMERATIONS.TURNS.RIGHT) Direction = ENUMERATIONS.DIRECTIONS.NORTH;
                        break;
                    case ENUMERATIONS.DIRECTIONS.UNKNOWN:
                        LoggerHelper.Warn($"invalid direction");
                        break;
                }
            }
        }

        ///<summary>
        /// Handling all reporting commmands, send the command to the receiver to do some actions
        /// REPORT will announce the X,Y and F of the robot. This can be in any form, but standard output is sufficient.
        ///</summary>
        public override void Report()
        {
            if (IsValid)
            {
                var report = $"Reporting from : {X},{Y},{Direction}";
                LoggerHelper.Info(report);
                Console.WriteLine(report);
            }
        }
    }
}

