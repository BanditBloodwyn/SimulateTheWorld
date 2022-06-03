using System.Windows.Controls;
using SimulateTheWorld.GUI.ViewModels.ViewModels.SidePanel.Panels.MarkedTile;

namespace SimulateTheWorld.GUI.Controls.Controls.MainPanels.SidePanel;

/// <summary>
/// Interaktionslogik für STWSidePanel.xaml
/// </summary>
public partial class STWSidePanel : UserControl
{
    public STWSidePanel()
    {
        InitializeComponent();
    }

    public void SetTile(int tileID)
    {
        (_ctrl_markedTile.DataContext as MarkedTileViewModel)?.SetTile(tileID);
    }
}