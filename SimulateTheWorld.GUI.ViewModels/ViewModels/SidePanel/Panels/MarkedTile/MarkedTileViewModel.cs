using SimulateTheWorld.Core.GUI.MVVM;
using SimulateTheWorld.Core.GUI.MVVM.Mediator;
using SimulateTheWorld.Core.Types;
using SimulateTheWorld.Models.Mediators;
using SimulateTheWorld.World.Data.Data.Types;
using SimulateTheWorld.World.System.Instances;

namespace SimulateTheWorld.GUI.ViewModels.ViewModels.SidePanel.Panels.MarkedTile;

public class MarkedTileViewModel : ObservableObject, ISubscriber<LocationMessage>
{
    private readonly IMediator _locationMediator;

    public TerrainTile? Tile { get; private set; }
    
    public DelegateCommand PinnLocationCommand { get; }

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

    public MarkedTileViewModel()
    {
        _locationMediator = LocationMediator.Instance;

        PinnLocationCommand = new DelegateCommand(
            _ =>
            {
                if (Tile == null)
                    return;

                Location location = new Location($"Tile: {Tile.ID}", new Coordinate());
                _locationMediator.Publish(new LocationMessage { Location = location, Pin = !Tile.Pinned });
              
                Tile.Pinned = !Tile.Pinned;
            });
    }

    public void SetTile(int tileID)
    {
        if (tileID > STWWorld.Instance.Terrain.Tiles.Length - 1)
            return;

        Tile = STWWorld.Instance.Terrain.Tiles[tileID];
        OnPropertyChanged(nameof(Tile));
        OnPropertyChanged(nameof(TileMarkedTest));
    }

    public void Handle(LocationMessage message) { }
}