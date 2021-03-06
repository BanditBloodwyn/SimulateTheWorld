using System;
using System.IO;
using System.Reflection;
using SimulateTheWorld.GUI.Core.MVVM;

namespace SimulateTheWorld.GUI.ViewModels.Dialogs;

public class AboutControlViewModel : ObservableObject
{
    public static string? Version => Assembly.GetEntryAssembly()?.GetName().Version?.ToString();

    public static string BuildDate
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

    public static string Intention => Resources.Localization.Locals_German.toolbar_help_about_intention;
}
    