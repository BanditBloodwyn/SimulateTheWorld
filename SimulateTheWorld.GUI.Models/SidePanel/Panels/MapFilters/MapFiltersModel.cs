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
    public MapFilter Ressource_IronOreFilter { get; }
    public MapFilter Ressource_GoldOreFilter { get; }
    public MapFilter Ressource_OilFilter { get; }
    public MapFilter Ressource_GasFilter { get; }

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
        Ressource_IronOreFilter = new MapFilter(MapFilterType.Ressource_IronOre);
        Ressource_GoldOreFilter = new MapFilter(MapFilterType.Ressource_GoldOre);
        Ressource_OilFilter = new MapFilter(MapFilterType.Ressource_Oil);
        Ressource_GasFilter = new MapFilter(MapFilterType.Ressource_Gas);

        _filters = new[] { 
            Vegetation, HeightFilter, PopByTribeFilter, CountriesFilter, LifeStandardFilter, UrbanizationFilter, 
            Ressource_CoalFilter, Ressource_IronOreFilter, Ressource_GoldOreFilter, Ressource_OilFilter, Ressource_GasFilter };
    }

    public void SetOnMapFilterChanged(Action onMapFilterChanged)
    {
        foreach (MapFilter mapFilter in _filters)
            mapFilter.MapFilterChanged += onMapFilterChanged;
    }
}