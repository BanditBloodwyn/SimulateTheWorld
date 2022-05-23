using SimulateTheWorld.World.Data.Data.Enums;

namespace SimulateTheWorld.World.Systems.Generation;

public static class TerrainSampler
{
    public static TileType GeTileTypeByHeight(float height) => height <= 10 
        ? TileType.Water 
        : TileType.Land;

    public static VegetationType GetVegetationTypeByHeight(float height)
    {
        if(height <= 10)
            return VegetationType.Water;
        if (height <= 30)
            return VegetationType.Kolline;
        if (height <= 50)
            return VegetationType.Montane;
        if (height <= 60)
            return VegetationType.Subalpine;
        if (height <= 70)
            return VegetationType.Alpine_Trees;
        if (height <= 80)
            return VegetationType.Alpine_Bushes;
        if (height <= 90)
            return VegetationType.Subnivale;
        if (height > 90)
            return VegetationType.Nivale;

        return VegetationType.Water;
    }
}