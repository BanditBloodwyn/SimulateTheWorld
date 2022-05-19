using System;
using System.Linq;
using SimulateTheWorld.Core.Types.Enums;

namespace SimulateTheWorld.GUI.Models.SidePanel.Panels.MapFilters;

public class MapFiltersModel
{
    private readonly MapFilter[] _filters;

    private static MapFiltersModel? _instance;

    public MapFilter Vegetation { get; }
    public MapFilter HeightFilter { get; }
    public MapFilter PopByTribeFilter { get; }
    public MapFilter CountriesFilter { get; }
    public MapFilter LifeStandardFilter { get; }
    public MapFilter UrbanizationFilter { get; }

    public MapFilter Ressource_CoalFilter { get; }


    public MapFilter? ActiveFilter => _filters.FirstOrDefault(filter => filter.Active);

    public static MapFiltersModel Instance
    {
        get { return _instance ??= new MapFiltersModel(); }
    }

    private MapFiltersModel()
    {
        Vegetation = new MapFilter(MapFilterType.Vegetation, true);
        HeightFilter = new MapFilter(MapFilterType.Height);
        PopByTribeFilter = new MapFilter(MapFilterType.PopByTribe);
        CountriesFilter = new MapFilter(MapFilterType.Countries);
        LifeStandardFilter = new MapFilter(MapFilterType.LifeStandard);
        UrbanizationFilter = new MapFilter(MapFilterType.Urbanization);

        Ressource_CoalFilter = new MapFilter(MapFilterType.Ressource_Coal);

        _filters = new[] { Vegetation, HeightFilter, PopByTribeFilter, CountriesFilter, LifeStandardFilter, UrbanizationFilter, Ressource_CoalFilter };
    }

    public void SetOnMapFilterChanged(Action onMapFilterChanged)
    {
        foreach (MapFilter mapFilter in _filters)
            mapFilter.MapFilterChanged += onMapFilterChanged;
    }
}