using System.Windows;
using SimulateTheWorld.Core.Logging;

namespace SimulateTheWorld.Start
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FileLogger fileLogger = new FileLogger();
            Logger.LogMessage += fileLogger.Log;
        }
    }
}
