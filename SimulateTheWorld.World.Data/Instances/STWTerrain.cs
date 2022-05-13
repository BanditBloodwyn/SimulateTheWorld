using System;
using System.Diagnostics;
using SimulateTheWorld.Core.Extentions;
using SimulateTheWorld.World.Data.Data.Enums;

namespace SimulateTheWorld.World.Data.Instances;

public class STWTerrain
{
    public const int TerrainSize = 20;
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
            for (int y = 0; y < TerrainSize; y++)
                Tiles[x * TerrainSize + y] = CreateTerrainTile(x * TerrainSize + y);
    }

    private TerrainTile CreateTerrainTile(int tileID)
    {
        TerrainTile tile = new();

        tile.ID = tileID;
        tile.TileType = EnumExtentions.RandomOf<TileType>();
        tile.TerrainType = EnumExtentions.RandomOf<TerrainType>();

        return tile;
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