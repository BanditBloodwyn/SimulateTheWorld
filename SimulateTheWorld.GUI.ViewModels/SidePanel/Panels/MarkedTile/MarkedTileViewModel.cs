using SimulateTheWorld.GUI.Core.MVVM;
using SimulateTheWorld.World.Core;
using SimulateTheWorld.World.Data.Types.Classes;

namespace SimulateTheWorld.GUI.ViewModels.SidePanel.Panels.MarkedTile;

public class MarkedTileViewModel : ObservableObject
{
    public TerrainTile Tile { get; private set; } = null!;

    public void SetTile(int tileID)
    {
        if (tileID > STWWorld.Instance.Terrain.Tiles.Length - 1)
            return;

        Tile = STWWorld.Instance.Terrain.Tiles[tileID];

        OnPropertyChanged(nameof(Tile));
    }
}