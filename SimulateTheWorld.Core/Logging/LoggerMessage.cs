using System;

namespace SimulateTheWorld.Core.Logging;

public class LoggerMessage
{
    public DateTime Timestamp { get; }
    public MessageType MessageType { get; }
    public string Sender { get; }
    public string Message { get; }
    public string Details { get; }

    public LoggerMessage(MessageType messageType, string sender, string message, string details)
    {
        Timestamp = DateTime.Now;

        MessageType = messageType;
        Sender = sender;
        Message = message;
        Details = details;
    }

    public LoggerMessage(MessageType messageType, string group)
    {
        Timestamp = DateTime.Now;

        MessageType = messageType;
        Message = group;
    }

    public override string ToString()
    {
        if (MessageType == MessageType.Group)
            return $"{Timestamp} - ================== {Message} ==================";

        string message = $"{Timestamp} - {MessageType} - {Sender}:\t\t{Message}";
        if (!string.IsNullOrEmpty(Details))
            message += $"\n\t\t{Details}";

        return message;
    }
}