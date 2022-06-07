using System;
using System.IO;
using System.Reflection;
using SimulateTheWorld.Core.GUI.MVVM;

namespace SimulateTheWorld.GUI.Dialogs.Popups.Toolbar;

public class AboutControlViewModel : ObservableObject
{
    public string? Version => Assembly.GetEntryAssembly()?.GetName().Version?.ToString();

    public string BuildDate
    {
        get
        {
            string? path = Assembly.GetEntryAssembly()?.Location;
            if (path == null)
                return string.Empty;

            DateTime datetime = File.GetCreationTime(path);
            return $"{datetime.ToLongDateString()}, {datetime.ToLongTimeString()}";
        }
    }
}
    