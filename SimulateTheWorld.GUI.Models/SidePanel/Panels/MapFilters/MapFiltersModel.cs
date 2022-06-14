using System;
using System.Linq;
using SimulateTheWorld.Core.Types.Enums;

namespace SimulateTheWorld.GUI.Models.SidePanel.Panels.MapFilters;

public class MapFiltersModel
{
    private readonly MapFilter[] _filters;

    private static MapFiltersModel? _instance;

    public MapFilter VegetationZone { get; }
    public MapFilter HeightFilter { get; }
    public MapFilter LifeStandardFilter { get; }
    public MapFilter UrbanizationFilter { get; }

    public MapFilter Flora_DeciduousTrees { get; }
    public MapFilter Flora_EvergreenTrees { get; }
    public MapFilter Flora_Vegetables { get; }
    public MapFilter Flora_Fruits { get; }

    public MapFilter Ressource_CoalFilter { get; }
    public MapFilter Ressource_IronOreFilter { get; }
    public MapFilter Ressource_GoldOreFilter { get; }
    public MapFilter Ressource_OilFilter { get; }
    public MapFilter Ressource_GasFilter { get; }

    public MapFilter? ActiveFilter => _filters.FirstOrDefault(static filter => filter.Active);

    public static MapFiltersModel Instance
    {
        get { return _instance ??= new MapFiltersModel(); }
    }

    private MapFiltersModel()
    {
        VegetationZone = new MapFilter(MapFilterType.VegetationZone, true);
        HeightFilter = new MapFilter(MapFilterType.Height);
        LifeStandardFilter = new MapFilter(MapFilterType.LifeStandard);
        UrbanizationFilter = new MapFilter(MapFilterType.Urbanization);

        Flora_DeciduousTrees = new MapFilter(MapFilterType.Flora_DeciduousTrees);
        Flora_EvergreenTrees = new MapFilter(MapFilterType.Flora_EvergreenTrees);
        Flora_Vegetables = new MapFilter(MapFilterType.Flora_Vegetables);
        Flora_Fruits = new MapFilter(MapFilterType.Flora_Fruits);

        Ressource_CoalFilter = new MapFilter(MapFilterType.Ressource_Coal);
        Ressource_IronOreFilter = new MapFilter(MapFilterType.Ressource_IronOre);
        Ressource_GoldOreFilter = new MapFilter(MapFilterType.Ressource_GoldOre);
        Ressource_OilFilter = new MapFilter(MapFilterType.Ressource_Oil);
        Ressource_GasFilter = new MapFilter(MapFilterType.Ressource_Gas);

        _filters = new[] { 
            VegetationZone, 
            HeightFilter, 
            LifeStandardFilter, UrbanizationFilter,
            Flora_DeciduousTrees, Flora_EvergreenTrees, Flora_Vegetables, Flora_Fruits,
            Ressource_CoalFilter, Ressource_IronOreFilter, Ressource_GoldOreFilter, Ressource_OilFilter, Ressource_GasFilter };
    }

    public void SetOnMapFilterChanged(Action onMapFilterChanged)
    {
        foreach (MapFilter mapFilter in _filters)
        {
            mapFilter.MapFilterChanged += onMapFilterChanged;
            mapFilter.OnMapFilterChanged += OnMapFilterChanged;
        }
    }

    private void OnMapFilterChanged(MapFilter mapFilter)
    {
        foreach (MapFilter filter in _filters.Except(new []{ mapFilter }))
        {
            filter.Active = false;
        }
    }
}