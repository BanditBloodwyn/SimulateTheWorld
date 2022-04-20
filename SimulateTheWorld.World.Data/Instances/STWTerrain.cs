﻿namespace SimulateTheWorld.World.Data.Instances;

public class STWTerrain
{
    public const int TerrainSize = 30;

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
                Tiles[x * TerrainSize + y] = new TerrainTile();
            }
        }
    }
}