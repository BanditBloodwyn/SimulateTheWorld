using SimulateTheWorld.Core.Logging;

namespace SimulateTheWorld.Start;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();

        FileLogger fileLogger = new FileLogger();
        Logger.LogMessage += fileLogger.Log;
    }
}