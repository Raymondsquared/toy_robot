using System;
using ToyRobot.Infrastructure.Abstractions;
using ToyRobot.Infrastructure.Loggers;

namespace ToyRobot.Infrastructure.Helpers
{
    public static class LoggerHelper
    {
        private static readonly ILogger Logger = new InMemoryLogger();
        
        public static void Debug(string message, params object[] p)
        {
            Logger.Debug(message, p);
        }
        public static void Info(string message, params object[] p)
        {
            Logger.Info(message, p);
        }
        public static void Warn(string message, params object[] p)
        {
            Logger.Warn(message, p);
        }
        public static void Error(Exception ex, string message, params object[] p)
        {
            Logger.Error(ex, message, p);
        }
        public static string GetLogs()
        {
            return Logger.GetLogs();
        }
    }
}