using System;
using System.Collections.Generic;
using System.Reflection;
using SimulateTheWorld.GUI.Core.MVVM;
using SimulateTheWorld.World.Core.Helper;
using SimulateTheWorld.World.Data.Types.Classes;
using SimulateTheWorld.World.Data.Types.Interfaces;

namespace SimulateTheWorld.GUI.ViewModels.Dialogs.BuildingMenu;

public class BuildingMenuViewModel : ObservableObject
{
    private TerrainTile? _tile;

    public BuildingItem[]? Buildings { get; private set; }

    public TerrainTile? Tile
    {
        get => _tile;
        set
        {
            _tile = value;
            Buildings = GetAllBuildings();

            OnPropertyChanged();
            OnPropertyChanged(nameof(Buildings));
        }
    }

    private BuildingItem[] GetAllBuildings()
    {
        if(Tile == null)
            return Array.Empty<BuildingItem>();

        List<BuildingItem> buildings = new List<BuildingItem>();

        Type[]? types = Assembly.GetAssembly(typeof(IBuilding))?.GetTypes();

        if (types == null || types.Length == 0)
            return Array.Empty<BuildingItem>();

        foreach (Type type in types)
        {
            if (!typeof(IBuilding).IsAssignableFrom(type) || type.IsInterface || type.IsAbstract)
                continue;

            ConstructorInfo? constructorInfo = type.GetConstructor(Array.Empty<Type>());
            if (constructorInfo == null)
                continue;

            IBuilding building = (IBuilding)constructorInfo.Invoke(null);

            buildings.Add(new BuildingItem(building, building.Buildable(Tile)));
        }

        return buildings.ToArray();
    }

    public void Build(Type type)
    {
        BuildingBuilder.Build(type, Tile);
    }
}