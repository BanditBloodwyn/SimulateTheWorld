using System;
using System.Threading.Tasks;
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

        Task.Factory.StartNew(static () =>
        {
            while (true) 
                STWWorld.Instance.Update();
        });

    }

    private void MainWindow_OnUnloaded(object sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
    }
}