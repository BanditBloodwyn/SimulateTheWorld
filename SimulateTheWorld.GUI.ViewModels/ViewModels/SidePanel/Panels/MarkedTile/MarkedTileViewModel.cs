using SimulateTheWorld.Core.GUI.MVVM;
using SimulateTheWorld.Core.GUI.MVVM.Mediator;
using SimulateTheWorld.GUI.Models.Mediators;
using SimulateTheWorld.World.System.Instances;

namespace SimulateTheWorld.GUI.ViewModels.ViewModels.SidePanel.Panels.MarkedTile;

public class MarkedTileViewModel : ObservableObject, ISubscriber<LocationMessage>
{
    public TerrainTile? Tile { get; private set; }
    
    public DelegateCommand PinnLocationCommand { get; }

    public string TileMarkedTest => Tile == null 
        ? string.Empty 
        : "Pin";

    public MarkedTileViewModel()
    {
        PinnLocationCommand = new DelegateCommand(
            _ =>
            {
                if (Tile == null)
                    return;

                LocationMediator.Instance.Publish(new LocationMessage { Location = Tile.Location });
              
                OnPropertyChanged(nameof(TileMarkedTest));
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