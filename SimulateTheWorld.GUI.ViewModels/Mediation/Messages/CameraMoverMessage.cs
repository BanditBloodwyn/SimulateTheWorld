using SimulateTheWorld.Core.GUI.MVVM.Mediator;

namespace SimulateTheWorld.GUI.ViewModels.Mediation.Messages;

public class CameraMoverMessage : IMessage
{
    public float X { get; init; }
    public float Y { get; init; }
}