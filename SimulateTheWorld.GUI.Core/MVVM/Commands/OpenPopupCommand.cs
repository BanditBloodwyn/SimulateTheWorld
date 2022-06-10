using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SimulateTheWorld.Core.Logging;

namespace SimulateTheWorld.GUI.Core.MVVM.Commands;

public class OpenPopupCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;

    public UserControl? OpenControl { get; init; }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        Logger.Debug(this, "Execute OpenPopupCommand");
        
        if (OpenControl == null)
        {
            Logger.Error(this, "OpenControl not set!");
            return;
        }

        Window popup = new Window
        {
            Topmost = true,
            WindowStyle = WindowStyle.None,
            ShowInTaskbar = false,
            ResizeMode = ResizeMode.NoResize,
            SizeToContent = SizeToContent.WidthAndHeight,
            Content = OpenControl
        };

        if (parameter is Point mousePosition)
        {
            popup.WindowStartupLocation = WindowStartupLocation.Manual;
            popup.Top = mousePosition.Y;
            popup.Left = mousePosition.X;
        }
        else
            popup.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        popup.Show();
    }

    public void OnCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}