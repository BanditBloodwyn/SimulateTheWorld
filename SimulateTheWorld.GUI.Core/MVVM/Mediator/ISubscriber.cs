namespace SimulateTheWorld.GUI.Core.MVVM.Mediator;

public interface ISubscriber<in T> where T : IMessage
{
    public void Handle(T message);
}