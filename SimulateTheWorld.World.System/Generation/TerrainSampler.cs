using SimulateTheWorld.World.Data.Data.Enums;

namespace SimulateTheWorld.World.System.Generation;

public static class TerrainSampler
{
    public static TileType GeTileTypeByHeight(float height) => height <= 10 
        ? TileType.Water 
        : TileType.Land;

    public static TerrainType GeTerrainTypeByHeight(float height)
    {
        if(height <= 10)
            return TerrainType.Water;
        if (height <= 20)
            return TerrainType.Plain;
        if (height <= 50)
            return TerrainType.Hills;
        if (height <= 100)
            return TerrainType.Mountains;

        return TerrainType.Water;
    }
}