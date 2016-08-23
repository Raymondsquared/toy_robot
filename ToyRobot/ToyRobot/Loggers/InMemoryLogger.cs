using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Abstractions;

namespace ToyRobot.Loggers
{
    public class InMemoryLogger : ILogger
    {
        private static IList<string> _repository;

        public InMemoryLogger()
        {
            _repository = new List<string>();
        }

        public void Debug(string message, params object[] p)
        {
            _repository.Add($"{ENUMERATIONS.LOG_LEVEL.DEBUG} @ {DateTime.UtcNow} : {message}");
        }
        public void Info(string message, params object[] p)
        {
            _repository.Add($"{ENUMERATIONS.LOG_LEVEL.INFO} @ {DateTime.UtcNow} : {message}");
        }
        public void Warn(string message, params object[] p)
        {
            _repository.Add($"{ENUMERATIONS.LOG_LEVEL.WARN} @ {DateTime.UtcNow} : {message}");
        }
        public void Error(Exception ex, string message, params object[] p)
        {
            _repository.Add($"{ENUMERATIONS.LOG_LEVEL.ERROR} @ {DateTime.UtcNow} : {message}");
        }

        public string GetLogs()
        {
            var qb = new StringBuilder();
            foreach (var log in _repository)
            {
                qb.Append(log);
            }
            return qb.ToString();
        }
    }
}
