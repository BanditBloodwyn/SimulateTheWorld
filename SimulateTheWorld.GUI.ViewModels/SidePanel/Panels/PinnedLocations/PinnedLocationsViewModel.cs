using System;
using System.Collections.ObjectModel;
using System.Linq;
using SimulateTheWorld.Core.Types;
using SimulateTheWorld.GUI.Core.MVVM;
using SimulateTheWorld.GUI.Core.MVVM.Commands;
using SimulateTheWorld.GUI.Core.MVVM.Mediator;
using SimulateTheWorld.GUI.Mediators.Mediators;
using SimulateTheWorld.GUI.Mediators.Messages;
using SimulateTheWorld.World.Data.Data;
using SimulateTheWorld.World.Systems.Instances;

namespace SimulateTheWorld.GUI.ViewModels.SidePanel.Panels.PinnedLocations;

public class PinnedLocationsViewModel : ObservableObject, ISubscriber<IMessage>
{
    public ObservableCollection<Tuple<string?, Location?, int>> Locations { get; }

    public DelegateCommand MoveToPinnedLocationCommand { get; }

    public PinnedLocationsViewModel()
    {
        LocationMediator.Instance.Subscribe(this);

        Locations = new ObservableCollection<Tuple<string?, Location?, int>>();

        MoveToPinnedLocationCommand = new DelegateCommand(static o =>
        {
            if (o is not Tuple<string?, Location?, int> location) 
                return;

            STWWorld.Instance.Terrain.TileMarker.MarkTile(location.Item3, true);

            if (location.Item2 == null)
                return;

            CameraMoverMediator.Instance.Publish(new CameraMoverMessage
            {
                X = location.Item2.Coordinate.X * WorldProperties.Instance.TileTotalSize,
                Y = location.Item2.Coordinate.Y * WorldProperties.Instance.TileTotalSize
            });
        });
    }

    public void Handle(IMessage message)
    {
        if (message is not LocationMessage locationMessage) 
            return;

        if (locationMessage.Location == null)
            return;

        if (Locations.Any(loc => loc.Item2?.Name == locationMessage.Location.Name))
            Locations.Remove(Locations.First(loc => loc.Item2?.Name == locationMessage.Location.Name));
        else
            Locations.Add( new Tuple<string?, Location?, int>(locationMessage.LocationName, locationMessage.Location, locationMessage.ID ));
    }
}