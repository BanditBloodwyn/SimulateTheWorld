using SimulateTheWorld.GUI.Core.MVVM;
using SimulateTheWorld.GUI.Core.MVVM.Commands;
using SimulateTheWorld.GUI.Mediators.Mediators;
using SimulateTheWorld.GUI.Mediators.Messages;
using SimulateTheWorld.World.Data.Types.Classes;

namespace SimulateTheWorld.GUI.ViewModels.Dialogs;

public class PinTileControlViewModel : ObservableObject
{
    private TerrainTile? _tile;
    private string? _locationName;

    public TerrainTile? Tile
    {
        set
        {
            _tile = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(PinButtonContent));
        }
    }

    public string PinButtonContent
    {
        get
        {
            if (_tile == null || _tile.Pinned)
                return "Lösen";
            return "Anpinnen";
        }
    }

    public DelegateCommand PinTileCommand { get; }

    public string? LocationName
    {
        get => _locationName;
        set
        {
            _locationName = value;
            OnPropertyChanged();
        }
    }

    public PinTileControlViewModel()
    {
        PinTileCommand = new DelegateCommand(_ =>
        {
            if (_tile == null)
                return;

            _tile.Pinned = !_tile.Pinned;
            LocationMediator.Instance.Publish(new LocationMessage
            {
                LocationName = string.IsNullOrEmpty(LocationName) ? "-" : LocationName, 
                Location = _tile.Location, 
                ID = _tile.ID
            });
        });
    }
}