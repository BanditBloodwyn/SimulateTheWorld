using System.Collections.Generic;
using SimulateTheWorld.Core.GUI.MVVM.Mediator;

namespace SimulateTheWorld.GUI.ViewModels.Mediation.Mediators;

public class LocationMediator : IMediator
{
    private static IMediator? _instance;

    private readonly List<ISubscriber<IMessage>> _subscribers = new();

    private LocationMediator() { }

    public static IMediator Instance => _instance ??= new LocationMediator();

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