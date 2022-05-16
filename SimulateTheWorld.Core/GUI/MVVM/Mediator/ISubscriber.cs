namespace SimulateTheWorld.Core.GUI.MVVM.Mediator;

public interface ISubscriber<T> where T : IMediator
{
    public void Handle(T message);
}