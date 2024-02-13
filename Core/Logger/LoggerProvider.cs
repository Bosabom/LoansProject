using Microsoft.Extensions.Logging;

namespace Core.Logger
{
    public class LoggerProvider : ILoggerProvider
    {
        private string path;
        public LoggerProvider(string _path)
        {
            path = _path;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new Logger(path);
        }

        public void Dispose()
        {
        }
    }
}
