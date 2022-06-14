using System.Windows;
using System.Windows.Controls;
using SimulateTheWorld.Core.Logging;

namespace SimulateTheWorld.GUI.Core.Helper;

public static class DialogOpener
{
    public static void Open(UserControl control, WindowStyle windowStyle = WindowStyle.None, Point? position = null)
    {
        Logger.Debug(typeof(DialogOpener), "Execute DialogOpener - Open");

        Window popup = new Window
        {
            Topmost = true,
            WindowStyle = windowStyle,
            ShowInTaskbar = false,
            ResizeMode = ResizeMode.NoResize,
            SizeToContent = SizeToContent.WidthAndHeight,
            Content = control
        };

        if (position != null)
        {
            popup.WindowStartupLocation = WindowStartupLocation.Manual;
            popup.Top = position.Value.Y;
            popup.Left = position.Value.X;
        }
        else
            popup.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        popup.Show();
    }
}