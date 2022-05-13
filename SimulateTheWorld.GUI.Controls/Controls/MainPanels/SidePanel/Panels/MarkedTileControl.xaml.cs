using System.Windows.Controls;
using SimulateTheWorld.World.System.Instances;

namespace SimulateTheWorld.GUI.Controls.Controls.MainPanels.SidePanel.Panels
{
    /// <summary>
    /// Interaktionslogik für MarkedTileControl.xaml
    /// </summary>
    public partial class MarkedTileControl : UserControl
    {
        public MarkedTileControl()
        {
            InitializeComponent();
        }

        public void SetTile(int tileID)
        {
            _lbl_ID.Content = $"Marked tile: {tileID}";

            if (tileID > STWWorld.Instance.Terrain.Tiles.Length)
            {
                _lbl_TileType.Content = $"Type:";
                _lbl_TerrainType.Content = $"Terrain:";
                return;
            }

            TerrainTile tile = STWWorld.Instance.Terrain.Tiles[tileID];

            _lbl_TileType.Content = $"Type: {tile.TileType}";
            _lbl_TerrainType.Content = $"Terrain: {tile.TerrainType}";
        }
    }
}
