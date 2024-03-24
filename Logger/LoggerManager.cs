using NLog;
using ILogger = NLog.ILogger;

namespace API.Logger;

public class LoggerManager:ILoggerManager
{
    private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
    public void LogDebug(string message) => _logger.Debug(message);
    public void LogError(string message) => _logger.Error(message);
    public void LogInfo(LoggerInfo info) => _logger.Info(info.Action+info.Message);
    public void LogWarn(string message) => _logger.Warn(message);
}