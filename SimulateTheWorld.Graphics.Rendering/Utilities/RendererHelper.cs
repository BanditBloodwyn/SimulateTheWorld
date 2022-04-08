using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Resources.Rendering;
using SimulateTheWorld.Models.SidePanel.Panels.MapFilters;
using SimulateTheWorld.World.Data.Instances;

namespace SimulateTheWorld.Graphics.Rendering.Utilities;

public static class RendererHelper
{
    public static Vector4 GetFilterColor(long id)
    {
        MapFilter[] activeFilters = MapFiltersModel.Instance.ActiveFilters;

        TerrainTile terrainTile = STWWorld.Instance.Terrain.Tiles[id];
        return MapFilterColors.SampleColorPair(MapFilterColors.LifeStandard, terrainTile.PopulationValues.LifeStandard);
    }
}