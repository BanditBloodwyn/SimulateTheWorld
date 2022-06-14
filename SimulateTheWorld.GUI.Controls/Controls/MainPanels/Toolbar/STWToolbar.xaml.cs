using System.Windows;
using SimulateTheWorld.GUI.Controls.Dialogs;
using SimulateTheWorld.GUI.Core.Helper;

namespace SimulateTheWorld.GUI.Controls.Controls.MainPanels.Toolbar;

/// <summary>
/// Interaktionslogik für STWToolbar.xaml
/// </summary>
public partial class STWToolbar
{
    public STWToolbar()
    {
        InitializeComponent();
    }

    private void MenuItem_OnClick(object sender, RoutedEventArgs e)
    {
        DialogOpener.Open(new AboutControl(), WindowStyle.ToolWindow);
    }
}