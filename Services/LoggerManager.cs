using NLog;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LoggerManager : ILoggerService
    {
        public interface ILoggerService
        {
            private static ILogger logger = LogManager.GetCurrentClassLogger();

            void LogInfo(string message) => logger.Info(message);
            void LogWarning(string message) => logger.Warn(message);
            void LogError(string message) => logger.Error(message);
            void LogDebug(string message) => logger.Debug(message);
        }
    }
}
