using NLog;
using TaskManagement.Business.Interfaces;

namespace TaskManagement.Business.CustomLogger
{
    public class NLogLogger : ICustomLogger
    {
        public void LogError(string message)
        {
            var logger = LogManager.GetLogger("loggerFile");
            logger.Log(LogLevel.Error,message);
        }
    }
}
