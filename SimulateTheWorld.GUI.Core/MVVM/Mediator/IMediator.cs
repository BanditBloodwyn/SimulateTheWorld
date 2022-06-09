namespace SimulateTheWorld.GUI.Core.MVVM.Mediator;

public interface IMediator
{
    public void Publish(IMessage message);
    public void Subscribe(ISubscriber<IMessage> subscriber);
}