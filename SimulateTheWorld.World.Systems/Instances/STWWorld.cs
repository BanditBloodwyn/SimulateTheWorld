using System;
using System.Collections.Generic;
using System.Reflection;
using SimulateTheWorld.Core.Logging;
using SimulateTheWorld.World.Systems.WorldSystems.Base;

namespace SimulateTheWorld.World.Systems.Instances;

public class STWWorld
{
    private static STWWorld? _instance;
   
    private readonly List<IWorldSystem> _worldSystems;

    public STWTerrain Terrain { get; }

    public event Action? OnUpdateVertexData;

    public static STWWorld Instance
    {
        get { return _instance ??= new STWWorld(); } 
    }

    private STWWorld()
    {
        Terrain = new STWTerrain();
        Terrain.OnUpdateVertexData += UpdateVertexData;
        _worldSystems = new List<IWorldSystem>();

        GetWorldSystems();
        SystemsInitialTrigger();
    }

    private void UpdateVertexData()
    {
        OnUpdateVertexData?.Invoke();
    }

    public void Update()
    {
        foreach (IWorldSystem system in _worldSystems)
        {
            Logger.Info(this, $"Trigger system {system.GetType().Name}");
            system.Trigger();
        }
    }

    private void SystemsInitialTrigger()
    {
        foreach (IWorldSystem system in _worldSystems)
        {
            Logger.Info(this, $"InitialTrigger system {system.GetType().Name}");
            system.InitialTrigger();
        }
    }

    private void GetWorldSystems()
    {
        foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
        {
            if (!typeof(IWorldSystem).IsAssignableFrom(type) || type.IsInterface || type.IsAbstract) 
                continue;

            ConstructorInfo? constructorInfo = type.GetConstructor(Array.Empty<Type>());
            if (constructorInfo == null)
                continue;

            _worldSystems.Add((IWorldSystem) constructorInfo.Invoke(null));
        }
    }
}