using SimulateTheWorld.Core.GUI.MVVM.Mediator;
using SimulateTheWorld.World.Data.Types.Classes;

namespace SimulateTheWorld.GUI.Models.Mediators;

public class LocationMessage : IMessage
{
    public Location? Location { get; init; }
}