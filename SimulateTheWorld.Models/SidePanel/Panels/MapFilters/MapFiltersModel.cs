﻿using System;
using System.Linq;

namespace SimulateTheWorld.Models.SidePanel.Panels.MapFilters;

public class MapFiltersModel
{
    private readonly MapFilter[] _filters;

    private static MapFiltersModel? _instance;

    public MapFilter TerrainFilter { get; }
    public MapFilter PopByTribeFilter { get; }
    public MapFilter CountriesFilter { get; }
    public MapFilter LifeStandardFilter { get; }
    public MapFilter UrbanizationFilter { get; }
   
    public MapFilter? ActiveFilter => _filters.FirstOrDefault(filter => filter.Active);

    public static MapFiltersModel Instance
    {
        get { return _instance ??= new MapFiltersModel(); }
    }

    private MapFiltersModel()
    {
        TerrainFilter = new MapFilter(MapFilterType.Terrain, true);
        PopByTribeFilter = new MapFilter(MapFilterType.PopByTribe);
        CountriesFilter = new MapFilter(MapFilterType.Countries);
        LifeStandardFilter = new MapFilter(MapFilterType.LifeStandard);
        UrbanizationFilter = new MapFilter(MapFilterType.Urbanization);

        _filters = new[] { TerrainFilter, PopByTribeFilter, CountriesFilter, LifeStandardFilter, UrbanizationFilter };
    }

    public void SetOnMapFilterChanged(Action onMapFilterChanged)
    {
        foreach (MapFilter mapFilter in _filters)
            mapFilter.MapFilterChanged += onMapFilterChanged;
    }
}