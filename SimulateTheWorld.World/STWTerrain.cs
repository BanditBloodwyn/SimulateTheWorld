namespace SimulateTheWorld.World;

public class STWTerrain
{
    public TerrainTile[,] Tiles { get; }

    public STWTerrain()
    {
        Tiles = new TerrainTile[10, 10];

        CreateTerrain();
    }

    private void CreateTerrain()
    {
        throw new System.NotImplementedException();
    }
}