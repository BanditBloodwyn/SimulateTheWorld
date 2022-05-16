using System;
using System.Collections.ObjectModel;
using SimulateTheWorld.Core.GUI.MVVM;
using SimulateTheWorld.Core.GUI.MVVM.Mediator;
using SimulateTheWorld.Core.Types;

namespace SimulateTheWorld.GUI.ViewModels.ViewModels.SidePanel.Panels.PinnedLocations;

public class PinnedLocationsViewModel : ObservableObject, ISubscriber<>
{
    public ObservableCollection<Location> Locations { get; set; }

    public PinnedLocationsViewModel()
    {
        Locations = new ObservableCollection<Location>();
        InitializeLocations();
    }

    private void InitializeLocations()
    {
        Locations.Add(new Location("test", new Coordinate(Random.Shared.Next(0, 90), Random.Shared.Next(-180, 180))));
        Locations.Add(new Location("test1", new Coordinate(Random.Shared.Next(0, 90), Random.Shared.Next(-180, 180))));
        Locations.Add(new Location("test2", new Coordinate(Random.Shared.Next(0, 90), Random.Shared.Next(-180, 180))));
        Locations.Add(new Location("test3", new Coordinate(Random.Shared.Next(0, 90), Random.Shared.Next(-180, 180))));
        Locations.Add(new Location("test4", new Coordinate(Random.Shared.Next(0, 90), Random.Shared.Next(-180, 180))));
    }

    public void Handle()
    {
        throw new NotImplementedException();
    }
}