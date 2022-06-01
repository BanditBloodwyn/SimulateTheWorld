using System.Numerics;
using SimulateTheWorld.Core.Extentions;
using SimulateTheWorld.Core.Math.Noise.Filters;
using SimulateTheWorld.World.Data.Data;
using SimulateTheWorld.World.Systems.Instances;

namespace SimulateTheWorld.World.Systems.Generation;

public class RessourceGenerator
{
    private readonly StandardNoiseFilter _standardNoiseFilter;

    public RessourceGenerator()
    {
        _standardNoiseFilter = new StandardNoiseFilter(4, 72, 0, 5f, 0.002f, 0.3f, Vector3.Zero);
    }

    public void GenerateRessources(TerrainTile tile)
    {
        tile.TerrainValues.Coal = _standardNoiseFilter.Calculate(
            tile.Location?.Coordinate, 
            tile.TerrainValues.Height, 
            Vector3.Zero, 
            4, 0, 72);
        tile.TerrainValues.IronOre = _standardNoiseFilter.Calculate(
            tile.Location?.Coordinate, 
            tile.TerrainValues.Height, 
            new Vector3(0, 0, WorldProperties.Instance.WorldSize / 2f), 
            4, 0, 72);
        tile.TerrainValues.GoldOre = _standardNoiseFilter.Calculate(
            tile.Location?.Coordinate, 
            tile.TerrainValues.Height, 
            new Vector3(0, WorldProperties.Instance.WorldSize / 2f, 0), 
            4, 0, 72);
        tile.TerrainValues.Oil = _standardNoiseFilter.Calculate(
            tile.Location?.Coordinate, 
            100, 
            Vector3.Zero, 
            2, 1f, 700);
        tile.TerrainValues.Gas = _standardNoiseFilter.Calculate(
            tile.Location?.Coordinate, 
            100, 
            new Vector3(WorldProperties.Instance.WorldSize / 2f, 0, 0), 
            2, 1, 700);
    }
}