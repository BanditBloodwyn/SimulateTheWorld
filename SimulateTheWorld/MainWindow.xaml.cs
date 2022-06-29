using System;
using System.Windows;
using SimulateTheWorld.Core.Logging;
using SimulateTheWorld.World.Core;

namespace SimulateTheWorld.Start;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    public MainWindow()
    {
        FileLogger fileLogger = new FileLogger();
        Logger.LogMessage += fileLogger.Log;

        InitializeComponent();
    }

    private void MainWindow_OnUnloaded(object sender, RoutedEventArgs e)
    {
        STWWorld.Instance.Terminate();
        Environment.Exit(0);
    }
}