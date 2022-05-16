namespace SimulateTheWorld.Core.GUI.MVVM.Mediator;

public interface ISubscriber<T> where T : IMessage
{
    public void Handle(T message);
}