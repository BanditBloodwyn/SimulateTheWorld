using System;
using System.Windows;
using SimulateTheWorld.Core.Logging;

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
        Environment.Exit(0);
    }
}