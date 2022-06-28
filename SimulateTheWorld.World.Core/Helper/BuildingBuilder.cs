using System;
using System.Reflection;
using SimulateTheWorld.World.Data.Types.Classes;
using SimulateTheWorld.World.Data.Types.Interfaces;
using SimulateTheWorld.World.Systems.Helper;

namespace SimulateTheWorld.World.Core.Helper;

public static class BuildingBuilder
{
    public static void Build(Type type, TerrainTile? terrainTile)
    {
        ConstructorInfo? constructorInfo = type.GetConstructor(Array.Empty<Type>());
        if (constructorInfo == null)
            return;

        IBuilding building = (IBuilding)constructorInfo.Invoke(null);
        terrainTile?.Buildings.Add(building);

        ApplyBuiltModifier(building, terrainTile);
    }

    private static void ApplyBuiltModifier(IBuilding building, TerrainTile? terrainTile)
    {
        if (building.BuiltModifier == null || terrainTile == null)
            return;

        TerrainTile[] tilesToModify = TilesToModifyFinder.GetTilesToModify(terrainTile.ID, STWWorld.Instance.Terrain.Tiles);

        foreach (TerrainTile tileToModify in tilesToModify)
            building.BuiltModifier.Invoke(terrainTile, tileToModify, tilesToModify.Length);
    }
}