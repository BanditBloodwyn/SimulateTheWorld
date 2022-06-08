using System.Collections.Generic;
using SimulateTheWorld.Core.GUI.MVVM.Mediator;

namespace SimulateTheWorld.GUI.Mediators.Mediators;

public class CameraMoverMediator : IMediator
{
    private static IMediator? _instance;

    private readonly List<ISubscriber<IMessage>> _subscribers = new();

    private CameraMoverMediator() { }

    public static IMediator Instance => _instance ??= new CameraMoverMediator();

    public void Publish(IMessage message)
    {
        foreach (ISubscriber<IMessage> subscriber in _subscribers)
            subscriber.Handle(message);
    }

    public void Subscribe(ISubscriber<IMessage> subscriber)
    {
        _subscribers.Add(subscriber);
    }
}