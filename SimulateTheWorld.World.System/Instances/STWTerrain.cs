using System;
using System.Diagnostics;
using SimulateTheWorld.Core.Types;
using SimulateTheWorld.World.Data.Data.Types;
using SimulateTheWorld.World.System.Generation;

namespace SimulateTheWorld.World.System.Instances;

public class STWTerrain
{
    public const int TerrainSize = 2000;
    public const float TileSize = 0.1f;

    private readonly TileMarker _tileMarker;
    private readonly WorldGenerator _worldGenerator;
   
    public TerrainTile[] Tiles { get; }

    public STWTerrain()
    {
        Tiles = new TerrainTile[TerrainSize * TerrainSize];
        
        _tileMarker = new TileMarker();
        _worldGenerator = new WorldGenerator();

        CreateCatalog();
        CreateTerrain();
    }

    private void CreateCatalog()
    {
        _worldGenerator.CreateCatalog();
    }

    private void CreateTerrain()
    {
        for (int x = 0; x < TerrainSize; x++)
            for (int y = 0; y < TerrainSize; y++)
                Tiles[x * TerrainSize + y] = CreateTerrainTile(x, y);
    }

    private TerrainTile CreateTerrainTile(int x, int y)
    {
        int tileID = x * TerrainSize + y;

        TerrainTile tile = new();

        tile.ID = tileID;
        tile.Location = new Location($"Tile {tileID}", new Coordinate(y, x));

        if (_worldGenerator.CatalogCollection.TerrainHeights == null)
            return tile;

        tile.TerrainValues.Height = _worldGenerator.CatalogCollection.TerrainHeights[tileID];
        tile.TileType = TerrainSampler.GeTileTypeByHeight(_worldGenerator.CatalogCollection.TerrainHeights[tileID]);
        tile.TerrainType = TerrainSampler.GeTerrainTypeByHeight(_worldGenerator.CatalogCollection.TerrainHeights[tileID]);

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