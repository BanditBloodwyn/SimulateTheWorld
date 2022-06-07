using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SimulateTheWorld.Core.Logging;

namespace SimulateTheWorld.GUI.ViewModels.Commands.Base;

public abstract class OpenPopupCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;

    protected abstract UserControl? OpenControl { get; }

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
            ResizeMode = ResizeMode.NoResize,
            SizeToContent = SizeToContent.WidthAndHeight,
            WindowStartupLocation = WindowStartupLocation.CenterScreen,
            Content = OpenControl,
        };
        popup.Show();
    }

    public void OnCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}