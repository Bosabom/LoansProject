using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Core.Logger
{
    public class Logger : ILogger
    {
        private readonly string filePath;
        private readonly object _lock;
        public Logger(string path)
        {
            filePath = path;
            _lock = new object();
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter == null)
            {
                return;
            }
            lock (_lock)
            {
                File.AppendAllText(filePath, formatter(state, exception) + Environment.NewLine);
            }
        }
    }
}
