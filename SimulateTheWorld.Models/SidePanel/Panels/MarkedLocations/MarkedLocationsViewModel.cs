using System;
using System.Collections.ObjectModel;
using SimulateTheWorld.Core.Types;
using SimulateTheWorld.Models.Core;

namespace SimulateTheWorld.Models.SidePanel.Panels.MarkedLocations;

public class MarkedLocationsViewModel : BaseViewModel
{
    public ObservableCollection<MarkedLocation> Locations { get; set; }

    public MarkedLocationsViewModel()
    {
        Locations = new ObservableCollection<MarkedLocation>();
        InitializeLocations();
    }

    private void InitializeLocations()
    {
        Locations.Add(new MarkedLocation("test", new Coordinate(Random.Shared.Next(0, 90), Random.Shared.Next(-180, 180))));
        Locations.Add(new MarkedLocation("test1", new Coordinate(Random.Shared.Next(0, 90), Random.Shared.Next(-180, 180))));
        Locations.Add(new MarkedLocation("test2", new Coordinate(Random.Shared.Next(0, 90), Random.Shared.Next(-180, 180))));
        Locations.Add(new MarkedLocation("test3", new Coordinate(Random.Shared.Next(0, 90), Random.Shared.Next(-180, 180))));
    }
}