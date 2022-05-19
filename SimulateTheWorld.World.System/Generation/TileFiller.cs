using System;
using SimulateTheWorld.World.Data.Data.Enums;
using SimulateTheWorld.World.System.Instances;

namespace SimulateTheWorld.World.System.Generation;

public class TileFiller
{
    public void FillTileValues(TerrainTile tile)
    {
        FillTerrainValues(tile);
        FillFloraValues(tile);
        FillFaunaValues(tile);
        FillPopulationValues(tile);
    }

    private void FillTerrainValues(TerrainTile tile)
    {
        switch (tile.VegetationType)
        {
            case VegetationType.Water:
                tile.TerrainValues.Coal = 1;
                tile.TerrainValues.IronOre = 1;
                tile.TerrainValues.GoldOre = 1;
                tile.TerrainValues.Oil = 10;
                tile.TerrainValues.Gas = 10;
                break;
            case VegetationType.Kolline:
                break;
            case VegetationType.Montane:
                break;
            case VegetationType.Subalpine:
                break;
            case VegetationType.Alpine_Trees:
                break;
            case VegetationType.Alpine_Bushes:
                break;
            case VegetationType.Subnivale:
                break;
            case VegetationType.Nivale:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void FillFloraValues(TerrainTile tile)
    {

    }

    private void FillFaunaValues(TerrainTile tile)
    {

    }

    private void FillPopulationValues(TerrainTile tile)
    {

    }
}