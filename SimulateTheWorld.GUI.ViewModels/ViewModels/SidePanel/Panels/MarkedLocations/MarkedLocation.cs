using SimulateTheWorld.Core.Types;

namespace SimulateTheWorld.GUI.ViewModels.ViewModels.SidePanel.Panels.MarkedLocations;

public class MarkedLocation
{
    public string Name { get; set; }

    public Coordinate Location { get; set; }

    public MarkedLocation(string name, Coordinate location)
    {
        Name = name;
        Location = location;
    }
}