namespace API.Logger;

public interface ILoggerManager
{
    void LogInfo(LoggerInfo info);
    void LogWarn(string message);
    void LogDebug(string message);
    void LogError(string message);
}