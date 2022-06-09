using SimulateTheWorld.GUI.Core.MVVM.Mediator;

namespace SimulateTheWorld.GUI.Mediators.Messages;

public class CameraMoverMessage : IMessage
{
    public float X { get; init; }
    public float Y { get; init; }
}