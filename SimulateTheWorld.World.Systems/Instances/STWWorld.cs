﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using SimulateTheWorld.World.Systems.WorldSystems;

namespace SimulateTheWorld.World.Systems.Instances;

public class STWWorld
{
    public const int TerrainSize = 2000;
    public const float TileSize = 0.1f;

    private List<IWorldSystem> _worldSystems = new List<IWorldSystem>();

    public STWTerrain Terrain { get; }

    private static STWWorld? _instance;

    public static STWWorld Instance
    {
        get { return _instance ??= new STWWorld(); } 
    }

    private STWWorld()
    {
        Terrain = new STWTerrain();

        _worldSystems = new List<IWorldSystem>();

        GetWorldSystems();
    }

    public void Update()
    {
        foreach (IWorldSystem system in _worldSystems)
        {
            Debug.WriteLine($"Trigger system {system.GetType().Name}");
            system.Trigger();
        }
    }

    private void GetWorldSystems()
    {
        foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
        {
            if (!typeof(IWorldSystem).IsAssignableFrom(type) || type.IsInterface) 
                continue;

            ConstructorInfo? constructorInfo = type.GetConstructor(Array.Empty<Type>());
            if (constructorInfo == null)
                continue;

            _worldSystems.Add((IWorldSystem) constructorInfo.Invoke(null));
        }
    }
}