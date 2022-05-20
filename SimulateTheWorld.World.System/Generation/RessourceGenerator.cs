using System;
using System.Numerics;
using System.Windows.Media.Media3D;
using SimulateTheWorld.Core.Math.Noise.Filters;
using SimulateTheWorld.World.System.Instances;

namespace SimulateTheWorld.World.System.Generation;

public class RessourceGenerator
{
    private readonly StandardNoiseFilter _standardNoiseFilter;

    public RessourceGenerator()
    {
        _standardNoiseFilter = new StandardNoiseFilter(4, 72, 0, 5f, 0.002f, 0.3f, Vector3.Zero);
    }

    public void GenerateRessources(TerrainTile tile)
    {
        tile.TerrainValues.Coal = CalculateRessource(tile, tile.TerrainValues.Height, Vector3.Zero);
        tile.TerrainValues.IronOre = CalculateRessource(tile, tile.TerrainValues.Height, new Vector3(0, 0, STWWorld.TerrainSize / 2f));
        tile.TerrainValues.GoldOre = CalculateRessource(tile, tile.TerrainValues.Height, new Vector3(0, STWWorld.TerrainSize / 2f, 0));
        tile.TerrainValues.Oil = CalculateRessource(tile, 100, Vector3.Zero, 2, 1f, 700);
        tile.TerrainValues.Gas = CalculateRessource(tile, 100, new Vector3(STWWorld.TerrainSize / 2f, 0, 0), 2, 1f, 700);
    }

    private float CalculateRessource(TerrainTile tile, float frequency, Vector3 offset, int layers = 4, float minValue = 0, float strength = 72)
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