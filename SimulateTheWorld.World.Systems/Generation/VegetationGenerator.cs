using System.Numerics;
using SimulateTheWorld.Core.Extentions;
using SimulateTheWorld.Core.Math;
using SimulateTheWorld.Core.Math.Noise.Filters;
using SimulateTheWorld.World.Data.Data;
using SimulateTheWorld.World.Data.Types.Enums;
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
        if (tile.TileType == TileType.Water || 
            tile.VegetationType is VegetationType.Subnivale or VegetationType.Nivale)
            return;

        tile.FloraValues.DeciduousTrees = _standardNoiseFilter.Calculate(
            tile.Location?.Coordinate,
            MathSci.Bump(tile.TerrainValues.Height, 100, 20, 20, 5),
            Vector3.Zero,
            4, 0, 72);
        tile.FloraValues.EvergreenTrees = _standardNoiseFilter.Calculate(
            tile.Location?.Coordinate,
            MathSci.Bump(tile.TerrainValues.Height, 100, 15, 50, 5),
            new Vector3(0, 0, WorldProperties.Instance.WorldSize / 2f),
            4, 0, 72);
        tile.FloraValues.Vegetables = _standardNoiseFilter.Calculate(
            tile.Location?.Coordinate,
            MathSci.Bump(tile.TerrainValues.Height, 50, 45, 10, 5),
            Vector3.Zero,
            2, 0.5f, 200);
        tile.FloraValues.Fruits = _standardNoiseFilter.Calculate(
            tile.Location?.Coordinate,
            MathSci.Bump(tile.TerrainValues.Height, 30, 25, 10, 5),
            new Vector3(0, WorldProperties.Instance.WorldSize / 2f, 0),
            2, 0.5f, 200);
    }
}