using System.Collections.Generic;
using SimulateTheWorld.Core.Logging;
using SimulateTheWorld.GUI.Core.MVVM.Mediator;

namespace SimulateTheWorld.GUI.Mediators.Mediators;

public class CameraMoverMediator : IMediator
{
    private static IMediator? _instance;

    private readonly List<ISubscriber<IMessage>> _subscribers = new();

    private CameraMoverMediator() { }

    public static IMediator Instance => _instance ??= new CameraMoverMediator();

    public void Publish(IMessage message)
    {
        Logger.Debug(this, $"Publish: {message}");

        foreach (ISubscriber<IMessage> subscriber in _subscribers)
            subscriber.Handle(message);
    }

    public void Subscribe(ISubscriber<IMessage> subscriber)
    {
        Logger.Debug(this, $"Subscribe: {subscriber}");

        _subscribers.Add(subscriber);
    }
}