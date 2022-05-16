using SimulateTheWorld.Core.GUI.MVVM;
using SimulateTheWorld.World.System.Instances;

namespace SimulateTheWorld.GUI.ViewModels.ViewModels.SidePanel.Panels.MarkedTile;

public class MarkedTileViewModel : ObservableObject
{
    public TerrainTile? Tile { get; private set; }

    public string TileMarkedTest
    {
        get
        {
            if (Tile == null)
                return string.Empty;

            return Tile.Pinned 
                ? "Demark" 
                : "Mark";
        }
    } 

    public void SetTile(int tileID)
    {
        if (tileID > STWWorld.Instance.Terrain.Tiles.Length - 1)
            return;

        Tile = STWWorld.Instance.Terrain.Tiles[tileID];
        OnPropertyChanged(nameof(Tile));
        OnPropertyChanged(nameof(TileMarkedTest));
    }
}