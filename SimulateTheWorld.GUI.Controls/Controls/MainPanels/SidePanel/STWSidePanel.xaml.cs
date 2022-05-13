using System.Windows.Controls;

namespace SimulateTheWorld.GUI.Controls.Controls.MainPanels.SidePanel
{
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
            _ctrl_markedTile.SetTile(tileID);
        }
    }
}
