using SimulateTheWorld.Core.Types;

namespace SimulateTheWorld.GUI.ViewModels.ViewModels.SidePanel.Panels.PinnedLocations;

public class PinnedLocation
{
    public string Name { get; set; }

    public Coordinate Location { get; set; }

    public PinnedLocation(string name, Coordinate location)
    {
        Name = name;
        Location = location;
    }
}