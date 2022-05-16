using SimulateTheWorld.Core.GUI.MVVM.Mediator;
using SimulateTheWorld.World.Data.Data.Types;

namespace SimulateTheWorld.GUI.Models.Mediators;

public class LocationMessage : IMessage
{
    public Location? Location { get; init; }
}