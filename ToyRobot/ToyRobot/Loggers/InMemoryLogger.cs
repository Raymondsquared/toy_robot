using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Abstractions;

namespace ToyRobot.Loggers
{
    public class InMemoryLogger : ILogger
    {
        private static IList<KeyValuePair<ENUMERATIONS.LOG_LEVEL, string>> _repository;

        public InMemoryLogger()
        {
            _repository = new List<KeyValuePair<ENUMERATIONS.LOG_LEVEL, string>>();
        }

        public void Debug(string message, params object[] p)
        {
            _repository.Add(new KeyValuePair<ENUMERATIONS.LOG_LEVEL, string>(ENUMERATIONS.LOG_LEVEL.DEBUG, message));
        }
        public void Info(string message, params object[] p)
        {
            _repository.Add(new KeyValuePair<ENUMERATIONS.LOG_LEVEL, string>(ENUMERATIONS.LOG_LEVEL.INFO, message));
        }
        public void Warn(string message, params object[] p)
        {
            _repository.Add(new KeyValuePair<ENUMERATIONS.LOG_LEVEL, string>(ENUMERATIONS.LOG_LEVEL.WARN, message));
        }
        public void Error(Exception ex, string message, params object[] p)
        {
            _repository.Add(new KeyValuePair<ENUMERATIONS.LOG_LEVEL, string>(ENUMERATIONS.LOG_LEVEL.ERROR, message));
        }

        public string GetLogs()
        {
            StringBuilder qb = new StringBuilder();
            foreach (var log in _repository)
            {
                qb.Append(log.Key);
                qb.Append(" : ");
                qb.Append(log.Value);
                qb.Append(Environment.NewLine);
            }
            return qb.ToString();
        }
    }
}
