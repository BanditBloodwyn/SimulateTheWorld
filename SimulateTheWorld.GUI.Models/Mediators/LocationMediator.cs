using System.Collections.Generic;
using System.Windows.Documents;
using SimulateTheWorld.Core.GUI.MVVM.Mediator;
using SimulateTheWorld.World.Data.Data.Types;

namespace SimulateTheWorld.Models.Mediators;

public class LocationMediator : IMediator
{
    private static IMediator? _instance = null;

    private List<ISubscriber<IMessage>> _subscribers = new List<ISubscriber<IMessage>>();

    private LocationMediator() {}

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