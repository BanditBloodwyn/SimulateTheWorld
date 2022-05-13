using System;
using System.Diagnostics;
using SimulateTheWorld.Core.Extentions;
using SimulateTheWorld.World.Data.Data.Enums;

namespace SimulateTheWorld.World.System.Instances;

public class STWTerrain
{
    public const int TerrainSize = 200;
    public const float TileSize = 0.1f;

    private readonly TileMarker _tileMarker;
   
    public TerrainTile[] Tiles { get; }
    
    public STWTerrain()
    {
        Tiles = new TerrainTile[TerrainSize * TerrainSize];
        
        _tileMarker = new TileMarker();

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
        if (tile.TileType == TileType.Water)
            tile.TerrainType = TerrainType.Water;
        else
            tile.TerrainType = EnumExtentions.RandomOf<TerrainType>(1);

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

    public void MarkTile(int tileID)
    {
        _tileMarker.MarkTile(tileID, true);
    }
}