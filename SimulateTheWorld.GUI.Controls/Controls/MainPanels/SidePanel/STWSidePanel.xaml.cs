using SimulateTheWorld.GUI.ViewModels.SidePanel.Panels.MarkedTile;

namespace SimulateTheWorld.GUI.Controls.Controls.MainPanels.SidePanel;

/// <summary>
/// Interaktionslogik für STWSidePanel.xaml
/// </summary>
public partial class STWSidePanel
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