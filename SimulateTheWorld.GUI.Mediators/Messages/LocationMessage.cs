using SimulateTheWorld.Core.GUI.MVVM.Mediator;
using SimulateTheWorld.World.Data.Types.Classes;

namespace SimulateTheWorld.GUI.Mediators.Messages;

public class LocationMessage : IMessage
{
    public Location? Location { get; init; }
    public int ID { get; init; }
}