using SimulateTheWorld.Core.GUI.MVVM.Mediator;
using SimulateTheWorld.World.Data.Types.Classes;

namespace SimulateTheWorld.GUI.ViewModels.Mediation.Messages;

public class LocationMessage : IMessage
{
    public Location? Location { get; init; }
    public int ID { get; init; }
}