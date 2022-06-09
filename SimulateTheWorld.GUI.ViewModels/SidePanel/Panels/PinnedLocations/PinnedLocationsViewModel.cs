using System;
using System.Collections.ObjectModel;
using System.Linq;
using SimulateTheWorld.GUI.Core.MVVM;
using SimulateTheWorld.GUI.Core.MVVM.Commands;
using SimulateTheWorld.GUI.Core.MVVM.Mediator;
using SimulateTheWorld.GUI.Mediators.Mediators;
using SimulateTheWorld.GUI.Mediators.Messages;
using SimulateTheWorld.World.Data.Data;
using SimulateTheWorld.World.Data.Types.Classes;
using SimulateTheWorld.World.Systems.Instances;

namespace SimulateTheWorld.GUI.ViewModels.SidePanel.Panels.PinnedLocations;

public class PinnedLocationsViewModel : ObservableObject, ISubscriber<IMessage>
{
    public ObservableCollection<Tuple<Location?, int>> Locations { get; }

    public DelegateCommand MoveToPinnedLocationCommand { get; }

    public PinnedLocationsViewModel()
    {
        LocationMediator.Instance.Subscribe(this);

        Locations = new ObservableCollection<Tuple<Location?, int>>();

        MoveToPinnedLocationCommand = new DelegateCommand(static o =>
        {
            if (o is not Tuple<Location?, int> location) 
                return;

            STWWorld.Instance.Terrain.TileMarker.MarkTile(location.Item2, true);

            if (location.Item1 == null)
                return;

            CameraMoverMediator.Instance.Publish(new CameraMoverMessage
            {
                X = location.Item1.Coordinate.X * WorldProperties.Instance.TileTotalSize,
                Y = location.Item1.Coordinate.Y * WorldProperties.Instance.TileTotalSize
            });
        });
    }


    public void Handle(IMessage message)
    {
        if (message is not LocationMessage locationMessage) 
            return;

        if (locationMessage.Location == null)
            return;

        if (Locations.Any(loc => loc.Item1?.Name == locationMessage.Location.Name))
            Locations.Remove(Locations.First(loc => loc.Item1?.Name == locationMessage.Location.Name));
        else
            Locations.Add( new Tuple<Location?, int>(locationMessage.Location, locationMessage.ID ));
    }
}