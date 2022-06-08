using SimulateTheWorld.Core.GUI.MVVM;
using SimulateTheWorld.GUI.Mediators.Mediators;
using SimulateTheWorld.GUI.Mediators.Messages;
using SimulateTheWorld.World.Systems.Instances;

namespace SimulateTheWorld.GUI.Dialogs.ContextMenus;

public class TileContextMenuViewModel : ObservableObject
{
    private TerrainTile? _tile;

    public string Description => $"Tile ID: {_tile?.ID}";

    public string PinText => _tile != null && _tile.Pinned 
        ? "Lösen" 
        : "Anpinnen";

    public TerrainTile? Tile
    {
        get => _tile;
        set
        {
            _tile = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(PinText));
        }
    }

    public void PinTile()
    {
        if (_tile == null) 
            return;

        _tile.Pinned = !_tile.Pinned;
        LocationMediator.Instance.Publish(new LocationMessage { Location = _tile.Location, ID = _tile.ID });
    }
}