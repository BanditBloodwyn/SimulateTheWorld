namespace SimulateTheWorld.GUI.Core.MVVM.Mediator;

public interface ISubscriber<T> where T : IMessage
{
    public void Handle(T message);
}