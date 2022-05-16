using SimulateTheWorld.Core.Types;

namespace SimulateTheWorld.GUI.ViewModels.ViewModels.SidePanel.Panels.PinnedLocations;

public class Location
{
    public string Name { get; set; }

    public Coordinate Location { get; set; }

    public Location(string name, Coordinate location)
    {
        Name = name;
        Location = location;
    }
}