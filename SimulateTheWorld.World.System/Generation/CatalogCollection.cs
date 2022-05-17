using System.Numerics;
using SimulateTheWorld.Core.Math.Noise.Filters;
using SimulateTheWorld.World.System.Instances;

namespace SimulateTheWorld.World.System.Generation;

public class CatalogCollection
{
    public float[]? TerrainHeights { get; set; }

    private readonly StandardNoiseFilter _standardNoiseFilter;

    public CatalogCollection()
    {
        _standardNoiseFilter = new StandardNoiseFilter(10, 100, 0.4f, 10f, 0.003f, 0.1f, Vector3.Zero);
    }

    public void CreateCatalog()
    {
        TerrainHeights = new float[STWTerrain.TerrainSize * STWTerrain.TerrainSize];
        
        for (int x = 0; x < STWTerrain.TerrainSize; x++) 
            for (int z = 0; z < STWTerrain.TerrainSize; z++) 
                TerrainHeights[x * STWTerrain.TerrainSize + z] = _standardNoiseFilter.Evaluate(new Vector3(x, 0, z));
    }
}