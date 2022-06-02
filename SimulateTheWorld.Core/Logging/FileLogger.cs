using System.IO;

namespace SimulateTheWorld.Core.Logging;

public class FileLogger
{
    private readonly StreamWriter writer;

    public FileLogger()
    {
        string path = "Log";
        string fileName = "Log.log";
        string fullPath = path + "\\" + fileName;

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        
        writer = File.CreateText(fullPath);
        writer.AutoFlush = true;
    }

    public void Log(LoggerMessage message)
    {
        writer.WriteLine(message.Message);
    }
}