namespace SimulateTheWorld.World.Data;

public class STWTerrain
{
    private const int _terrainSize = 10;

    public TerrainTile[,] Tiles { get; }

    public STWTerrain()
    {
        Tiles = new TerrainTile[_terrainSize, _terrainSize];

        CreateTerrain();
    }

    private void CreateTerrain()
    {
        for (int x = 0; x < _terrainSize; x++)
        {
            for (int y = 0; y < _terrainSize; y++)
            {
                Tiles[x,y] = new TerrainTile();
            }
        }
    }
}