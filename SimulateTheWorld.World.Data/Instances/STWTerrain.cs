using System;
using System.Diagnostics;
using SimulateTheWorld.World.Data.Data.Enums;

namespace SimulateTheWorld.World.Data.Instances;

public class STWTerrain
{
    public const int TerrainSize = 2000;
    public const float TileSize = 0.1f;

    public TerrainTile[] Tiles { get; }

    public STWTerrain()
    {
        Tiles = new TerrainTile[TerrainSize * TerrainSize];

        CreateTerrain();
    }

    private void CreateTerrain()
    {
        for (int x = 0; x < TerrainSize; x++)
        {
            for (int y = 0; y < TerrainSize; y++)
            {
                Tiles[x * TerrainSize + y] = CreateTerrainTile(x * TerrainSize + y);
            }
        }
    }

    private TerrainTile CreateTerrainTile(int tileID)
    {
        Random random = new();

        return new TerrainTile
        {
            ID = tileID,
            TileType = (TileType)random.Next(0, 2),
            TerrainType = (TerrainType)random.Next(0, 3)
        };
    }

    public void RandomizeTiles()
    {
        int updatedTilesCount = 0;

        foreach (TerrainTile terrainTile in Tiles)
        {
            try
            {
                terrainTile.Randomize();
                updatedTilesCount++;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Tile randomization failed: {e}");
                throw;
            }
        }

        Debug.WriteLine($"\tUpdated tiles: {updatedTilesCount}");
    }
}