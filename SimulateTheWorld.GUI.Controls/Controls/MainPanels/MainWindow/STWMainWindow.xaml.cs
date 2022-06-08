using System.Windows.Controls;
using SimulateTheWorld.GUI.ViewModels.SidePanel;

namespace SimulateTheWorld.GUI.Controls.Controls.MainPanels.MainWindow;

/// <summary>
/// Interaktionslogik für STWMainWindow.xaml
/// </summary>
public partial class STWMainWindow : UserControl
{
    public STWMainWindow()
    {
        InitializeComponent();

        if (v_SidePanel.DataContext is SidePanelViewModel spViewModel)
            spViewModel.SetUpdateWorldRendering(v_RenderView.UpdateWorldRendering);

        v_RenderView.OnTileSelected += OnTileSelected;
    }

    private void OnTileSelected(int tileID)
    {
        v_SidePanel.SetTile(tileID);
    }
}