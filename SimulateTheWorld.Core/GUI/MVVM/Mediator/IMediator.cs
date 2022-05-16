namespace SimulateTheWorld.Core.GUI.MVVM.Mediator;

public interface IMediator
{
    public void Publish(IMessage message);
    public void Subscribe(ISubscriber subscriber);
}