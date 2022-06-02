namespace SimulateTheWorld.Core.Logging;

public class LoggerMessage
{
    public MessageType MessageType { get; }
    public string Sender { get; }
    public string Message { get; }
    public string Details { get; }

    public LoggerMessage(MessageType messageType, string sender, string message, string details)
    {
        MessageType = messageType;
        Sender = sender;
        Message = message;
        Details = details;
    }
}