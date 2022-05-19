using SimulateTheWorld.World.System.Generation;

namespace SimulateTheWorld.World.System.Instances;

public class STWTerrain
{
    private readonly TileMarker _tileMarker;
    private readonly WorldGenerator _worldGenerator;
   
    public TerrainTile[] Tiles { get; }

    public STWTerrain()
    {
        Tiles = new TerrainTile[STWWorld.TerrainSize * STWWorld.TerrainSize];
        
        _tileMarker = new TileMarker();
        _worldGenerator = new WorldGenerator();
        _worldGenerator.CreateCatalog();
       
        CreateTiles();
    }

    private void CreateTiles()
    {
        for (int x = 0; x < STWWorld.TerrainSize; x++)
            for (int y = 0; y < STWWorld.TerrainSize; y++)
                Tiles[x * STWWorld.TerrainSize + y] = _worldGenerator.CreateTerrainTile(x, y);
    }
    
    public void MarkTile(int tileID)
    {
        _tileMarker.MarkTile(tileID, true);
    }
}
