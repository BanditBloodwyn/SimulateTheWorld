using SimulateTheWorld.World.Data.Data;
using SimulateTheWorld.World.Data.Types.Classes;
using SimulateTheWorld.World.Systems.Generation;
using SimulateTheWorld.World.Systems.Helper;

namespace SimulateTheWorld.World.Systems.Instances;

public class STWTerrain
{
    private readonly WorldGenerator _worldGenerator;
    
    public TerrainTile[] Tiles { get; }

    public TileMarker TileMarker { get; }

    public STWTerrain()
    {
        Tiles = new TerrainTile[WorldProperties.Instance.WorldSize * WorldProperties.Instance.WorldSize];
        
        TileMarker = new TileMarker();
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
