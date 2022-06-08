using SimulateTheWorld.Core.GUI.MVVM;
using SimulateTheWorld.GUI.Mediators.Mediators;
using SimulateTheWorld.GUI.Mediators.Messages;
using SimulateTheWorld.World.Systems.Instances;

namespace SimulateTheWorld.GUI.Dialogs.ContextMenus;

public class TileContextMenuViewModel : ObservableObject
{
    private TerrainTile? _tile;

    public string Description => $"Tile ID: {_tile?.ID}";

    public TerrainTile Tile
    {
        get => _tile;
        set
        {
            _tile = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Description));
        }
    }

    public void PinTile()
    {
        LocationMediator.Instance.Publish(new LocationMessage { Location = Tile.Location, ID = Tile.ID });
    }
}