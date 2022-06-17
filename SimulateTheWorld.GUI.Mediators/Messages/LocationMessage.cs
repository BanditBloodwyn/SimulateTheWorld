using SimulateTheWorld.Core.Types;
using SimulateTheWorld.GUI.Core.MVVM.Mediator;

namespace SimulateTheWorld.GUI.Mediators.Messages;

public class LocationMessage : IMessage
{
    public string? LocationName { get; init; }
    public Location? Location { get; init; }
    public int ID { get; init; }
}