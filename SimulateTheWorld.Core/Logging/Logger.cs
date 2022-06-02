using System;

namespace SimulateTheWorld.Core.Logging;

public static class Logger
{
    public static event Action<LoggerMessage>? LogMessage;

    public static void Debug(object sender, string message, string details = null)
    {
        var msg = new LoggerMessage(
            MessageType.Debug,
            GetSender(sender),
            message,
            details);

        LogMessage?.Invoke(msg);
    }

    public static void Warning(object sender, string message, string details = null)
    {
        var msg = new LoggerMessage(
            MessageType.Warning,
            GetSender(sender),
            message,
            details);

        LogMessage?.Invoke(msg);
    }

    public static void Error(object sender, string message, string details = null)
    {
        var msg = new LoggerMessage(
            MessageType.Error,
            GetSender(sender),
            message,
            details);

        LogMessage?.Invoke(msg);
    }

    public static void Info(object sender, string message, string details = null)
    {
        var msg = new LoggerMessage(
            MessageType.Info,
            GetSender(sender),
            message,
            details);

        LogMessage?.Invoke(msg);
    }

    private static string GetSender(object sender)
    {
        if (sender == null)
            return "(unknown)";

        if (sender is Type type)
            return type.Name;

        if (sender is string s)
            return s;

        return sender.GetType().Name;
    }
}