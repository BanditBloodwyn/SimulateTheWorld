using System;
using System.Drawing;
using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Resources.Rendering;
using SimulateTheWorld.Models.SidePanel.Panels.MapFilters;
using SimulateTheWorld.World.Data.Instances;

namespace SimulateTheWorld.Graphics.Rendering.Utilities;

public static class RendererHelper
{
    public static Vector4 GetFilterColor(long id)
    {
        MapFilter? activeFilter = MapFiltersModel.Instance.ActiveFilter;

        if (activeFilter == null) 
            return Vector4.One;

        TerrainTile terrainTile = STWWorld.Instance.Terrain.Tiles[id];
        return MapFilterColors.SampleColorPair(GetFilterColors(activeFilter.Type), GetTileValue(terrainTile, activeFilter.Type));
    }

    private static float GetTileValue(TerrainTile terrainTile, MapFilterType type)
    {
        return type switch
        {
            MapFilterType.PopByTribe => terrainTile.PopulationValues.Population.Quantity,
            MapFilterType.Countries => terrainTile.PopulationValues.Population.Quantity,
            MapFilterType.LifeStandard => terrainTile.PopulationValues.LifeStandard,
            MapFilterType.Urbanization => terrainTile.PopulationValues.Urbanization,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }

    private static Color[] GetFilterColors(MapFilterType type)
    {
        return type switch
        {
            MapFilterType.PopByTribe => MapFilterColors.PopByTribe,
            MapFilterType.Countries => MapFilterColors.Countries,
            MapFilterType.LifeStandard => MapFilterColors.LifeStandard,
            MapFilterType.Urbanization => MapFilterColors.Urbanization,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}