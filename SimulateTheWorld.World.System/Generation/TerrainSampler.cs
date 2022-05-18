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
        if (height <= 30)
            return TerrainType.Kolline;
        if (height <= 50)
            return TerrainType.Montane;
        if (height <= 60)
            return TerrainType.Subalpine;
        if (height <= 70)
            return TerrainType.Alpine_Trees;
        if (height <= 80)
            return TerrainType.Alpine_Bushes;
        if (height <= 90)
            return TerrainType.Subnivale;
        if (height > 90)
            return TerrainType.Nivale;

        return TerrainType.Water;
    }
}