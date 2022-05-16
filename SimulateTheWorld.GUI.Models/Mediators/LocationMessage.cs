using SimulateTheWorld.Core.GUI.MVVM.Mediator;
using SimulateTheWorld.World.Data.Data.Types;

namespace SimulateTheWorld.Models.Mediators;

public class LocationMessage : IMessage
{
    public Location Location { get; set; }
    public bool Pin { get; set; }
}