using System;

namespace SimulateTheWorld.Core.Logging;

public class LoggerMessage
{
    private readonly DateTime _timestamp;
    private readonly MessageType _messageType;
    private readonly string _message;
    private readonly string? _sender;
    private readonly string? _details;

    public LoggerMessage(MessageType messageType, string sender, string message, string? details)
    {
        _timestamp = DateTime.Now;

        _messageType = messageType;
        _sender = sender;
        _message = message;
        _details = details;
    }

    public LoggerMessage(MessageType messageType, string group)
    {
        _timestamp = DateTime.Now;

        _messageType = messageType;
        _message = group;
    }

    public override string ToString()
    {
        if (_messageType == MessageType.Group)
            return $"{_timestamp} - ================== {_message} ==================";

        string message = $"{_timestamp} - {_messageType} - {_sender}:\t\t{_message}";
        if (!string.IsNullOrEmpty(_details))
            message += $"\n\t\t{_details}";

        return message;
    }
}