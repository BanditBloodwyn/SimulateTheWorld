using System;
using System.Reflection;
using SimulateTheWorld.World.Data.Types.Classes;
using SimulateTheWorld.World.Data.Types.Interfaces;

namespace SimulateTheWorld.World.Systems.WorldSystems.Helper;

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
        if (building.BuiltModifier == null || building.BuiltModifier == null || terrainTile == null)
            return;

        TerrainTile[] tilesToModify = TilesToModifyFinder.GetTilesToModify(terrainTile.ID);

        foreach (TerrainTile tileToModify in tilesToModify)
            building.BuiltModifier.Invoke(terrainTile, tileToModify, tilesToModify.Length);
    }
}