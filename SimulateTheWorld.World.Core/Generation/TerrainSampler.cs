using SimulateTheWorld.World.Data.Types.Enums;

namespace SimulateTheWorld.World.Core.Generation;

public static class TerrainSampler
{
    public static TileType GeTileTypeByHeight(float height) => height <= 10 
        ? TileType.Water 
        : TileType.Land;

    public static VegetationType GetVegetationTypeByHeight(float height)
    {
        return height switch
        {
            <= 10 => VegetationType.Water,
            <= 30 => VegetationType.Kolline,
            <= 50 => VegetationType.Montane,
            <= 60 => VegetationType.Subalpine,
            <= 70 => VegetationType.Alpine_Trees,
            <= 80 => VegetationType.Alpine_Bushes,
            <= 90 => VegetationType.Subnivale,
            > 90 => VegetationType.Nivale,
            _ => VegetationType.Water
        };
    }
}