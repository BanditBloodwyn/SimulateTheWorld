using System;
using System.Collections.ObjectModel;
using SimulateTheWorld.Core.GUI.MVVM;
using SimulateTheWorld.Core.Types;

namespace SimulateTheWorld.GUI.ViewModels.ViewModels.SidePanel.Panels.PinnedLocations;

public class PinnedLocationsViewModel : ObservableObject
{
    public ObservableCollection<PinnedLocation> Locations { get; set; }

    public PinnedLocationsViewModel()
    {
        Locations = new ObservableCollection<PinnedLocation>();
        InitializeLocations();
    }

    private void InitializeLocations()
    {
        Locations.Add(new PinnedLocation("test", new Coordinate(Random.Shared.Next(0, 90), Random.Shared.Next(-180, 180))));
        Locations.Add(new PinnedLocation("test1", new Coordinate(Random.Shared.Next(0, 90), Random.Shared.Next(-180, 180))));
        Locations.Add(new PinnedLocation("test2", new Coordinate(Random.Shared.Next(0, 90), Random.Shared.Next(-180, 180))));
        Locations.Add(new PinnedLocation("test3", new Coordinate(Random.Shared.Next(0, 90), Random.Shared.Next(-180, 180))));
        Locations.Add(new PinnedLocation("test4", new Coordinate(Random.Shared.Next(0, 90), Random.Shared.Next(-180, 180))));
    }
}