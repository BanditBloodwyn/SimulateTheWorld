using SimulateTheWorld.World.Core.Generation;
using SimulateTheWorld.World.Data.Data;
using SimulateTheWorld.World.Data.Types.Classes;
using SimulateTheWorld.World.Data.Types.Interfaces;

namespace SimulateTheWorld.World.Core;

public class STWTerrain : ITerrain
{
    private readonly WorldGenerator _worldGenerator;
    
    public TerrainTile[] Tiles { get; }

    public STWTerrain()
    {
        Tiles = new TerrainTile[WorldProperties.Instance.WorldSize * WorldProperties.Instance.WorldSize];
        
        _worldGenerator = new WorldGenerator();
        _worldGenerator.CreateCatalog();
       
        CreateTiles();
    }

    private void CreateTiles()
    {
        for (int x = 0; x < WorldProperties.Instance.WorldSize; x++)
            for (int y = 0; y < WorldProperties.Instance.WorldSize; y++)
                Tiles[x * WorldProperties.Instance.WorldSize + y] = _worldGenerator.CreateTerrainTile(x, y);
    }
}
