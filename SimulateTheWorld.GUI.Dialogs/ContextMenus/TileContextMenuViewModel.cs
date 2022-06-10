using SimulateTheWorld.GUI.Core.MVVM;
using SimulateTheWorld.GUI.Core.MVVM.Commands;
using SimulateTheWorld.GUI.Dialogs.Popups.PinTile;
using SimulateTheWorld.GUI.Mediators.Mediators;
using SimulateTheWorld.GUI.Mediators.Messages;
using SimulateTheWorld.World.Systems.Instances;

namespace SimulateTheWorld.GUI.Dialogs.ContextMenus;

public class TileContextMenuViewModel : ObservableObject
{
    private TerrainTile? _tile;

    public string Description => $"Tile ID: {_tile?.ID} - {_tile?.Location?.Coordinate}";

    public string PinText => _tile != null && _tile.Pinned 
        ? "Lösen" 
        : "Anpinnen";

    public OpenPopupCommand? OpenPinTileControlCommand { get; private set; }
    public DelegateCommand PinTileCommand { get; }

    public TerrainTile? Tile
    {
        get => _tile;
        set
        {
            _tile = value;

            if (_tile == null)
                return;
            OpenPinTileControlCommand = new OpenPopupCommand { OpenControl = new PinTileControl(_tile) };
                
            OnPropertyChanged();
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(PinText));
        }
    }

    public TileContextMenuViewModel()
    {
        PinTileCommand = new DelegateCommand(_ =>
        {
            if (_tile == null)
                return;

            _tile.Pinned = !_tile.Pinned;
            LocationMediator.Instance.Publish(new LocationMessage { LocationName = null, Location = _tile.Location, ID = _tile.ID });
        });
    }
}