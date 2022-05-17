using SimulateTheWorld.World.System.Instances;

namespace SimulateTheWorld.World.System.Generation;

public class CatalogCollection
{
    private readonly NoiseGenerator _noiseGenerator;

    public float[]? TerrainHeights { get; private set; }
    
    public CatalogCollection()
    {
        _noiseGenerator = new NoiseGenerator();
    }

    public void CreateCatalog()
    {
        TerrainHeights = new float[STWTerrain.TerrainSize * STWTerrain.TerrainSize];
        
        for (int x = 0; x < STWTerrain.TerrainSize; x++) 
            for (int z = 0; z < STWTerrain.TerrainSize; z++) 
                TerrainHeights[x * STWTerrain.TerrainSize + z] = _noiseGenerator.CalculateHeight(x, z);
    }
}