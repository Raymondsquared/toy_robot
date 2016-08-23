﻿using System;

namespace ToyRobot.Abstractions
{
    public interface ILogger
    {
        void Debug(string message, params object[] p);
        void Info(string message, params object[] p);
        void Warn(string message, params object[] p);
        void Error(Exception ex, string message, params object[] p);
        string GetLogs();
    }
}
