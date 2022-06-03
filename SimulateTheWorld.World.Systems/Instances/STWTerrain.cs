using System;
using SimulateTheWorld.World.Data.Data;
using SimulateTheWorld.World.Systems.Generation;

namespace SimulateTheWorld.World.Systems.Instances;

public class STWTerrain
{
    private readonly WorldGenerator _worldGenerator;
    
    public event Action? OnUpdateVertexData;

    public TerrainTile[] Tiles { get; }

    public TileMarker TileMarker { get; }

    public STWTerrain()
    {
        Tiles = new TerrainTile[WorldProperties.Instance.WorldSize * WorldProperties.Instance.WorldSize];
        
        TileMarker = new TileMarker();
        TileMarker.OnUpdateVertexData += UpdateVertexData;
        _worldGenerator = new WorldGenerator();
        _worldGenerator.CreateCatalog();
       
        CreateTiles();
    }

    private void UpdateVertexData()
    {
        OnUpdateVertexData?.Invoke();
    }

    private void CreateTiles()
    {
        for (int x = 0; x < WorldProperties.Instance.WorldSize; x++)
            for (int y = 0; y < WorldProperties.Instance.WorldSize; y++)
                Tiles[x * WorldProperties.Instance.WorldSize + y] = _worldGenerator.CreateTerrainTile(x, y);
    }
}
