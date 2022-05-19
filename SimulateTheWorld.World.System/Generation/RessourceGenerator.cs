using System.Numerics;
using SimulateTheWorld.Core.Math.Noise.Filters;
using SimulateTheWorld.World.System.Instances;

namespace SimulateTheWorld.World.System.Generation;

public class RessourceGenerator
{
    private readonly StandardNoiseFilter _standardNoiseFilter;

    public RessourceGenerator()
    {
        _standardNoiseFilter = new StandardNoiseFilter(10, 80, 0.4f, 10f, 0.002f, 0.1f, Vector3.Zero);
    }

    public void GenerateRessources(TerrainTile tile)
    {
        tile.TerrainValues.Coal = CalculateRessource(tile, 100);
        tile.TerrainValues.IronOre = CalculateRessource(tile, 100);
        tile.TerrainValues.GoldOre = CalculateRessource(tile, 100);
        tile.TerrainValues.Oil = CalculateRessource(tile, 100);
        tile.TerrainValues.Gas = CalculateRessource(tile, 100);
    }

    private float CalculateRessource(TerrainTile tile, float frequency)
    {
        if (tile.Location == null)
            return 0;

        int x = tile.Location.Coordinate.X;
        int z = tile.Location.Coordinate.Y;

        float value = _standardNoiseFilter.Evaluate(new Vector3(x, 0, z));
        return value * frequency / 100;
    }
}