using SimulateTheWorld.Core.GUI.MVVM.Mediator;

namespace SimulateTheWorld.GUI.Models.Mediators.CameraMover;

public class CameraMoverMessage : IMessage
{
    public float X { get; set; }
    public float Y { get; set; }
}