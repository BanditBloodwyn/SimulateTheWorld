﻿using System;
using System.Numerics;
using SimulateTheWorld.Core.Math.Noise.Filters;
using SimulateTheWorld.World.Systems.Instances;

namespace SimulateTheWorld.World.Systems.Generation;

public class VegetationGenerator
{
    private readonly StandardNoiseFilter _standardNoiseFilter;

    public VegetationGenerator()
    {
        _standardNoiseFilter = new StandardNoiseFilter(4, 72, 0, 5f, 0.002f, 0.3f, Vector3.Zero);
    }

    public void GenerateVegetation(TerrainTile tile)
    {
        tile.FloraValues.DeciduousTrees = CalculateVegetation(tile, tile.TerrainValues.Height, Vector3.Zero);
        tile.FloraValues.EvergreenTrees = CalculateVegetation(tile, tile.TerrainValues.Height, new Vector3(0, 0, STWWorld.TerrainSize / 2f));
        tile.FloraValues.Fruits = CalculateVegetation(tile, tile.TerrainValues.Height, new Vector3(0, STWWorld.TerrainSize / 2f, 0));
        tile.FloraValues.Vegetables = CalculateVegetation(tile, 100, Vector3.Zero, 2, 1f, 700);
    }

    private float CalculateVegetation(TerrainTile tile, float frequency, Vector3 offset, int layers = 4, float minValue = 0, float strength = 72)
    {
        if (tile.Location == null)
            return 0;

        int x = tile.Location.Coordinate.X;
        int z = tile.Location.Coordinate.Y;

        _standardNoiseFilter.NumberOfLayers = layers;
        _standardNoiseFilter.Center = offset;
        _standardNoiseFilter.MinValue = minValue;
        _standardNoiseFilter.Strength = strength;
        float value = MathF.Min(_standardNoiseFilter.Evaluate(new Vector3(x, 0, z)), 100);

        return value * frequency / 100;
    }

}