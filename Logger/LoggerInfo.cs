namespace API.Logger;

public enum LoggerAction
{
    Add,
    Update,
    Delete,
}

public class LoggerInfo
{
    public LoggerAction Action { get; set; }
    public string Message { get; set; }
}