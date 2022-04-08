using System.Linq;

namespace SimulateTheWorld.Models.SidePanel.Panels.MapFilters;

public class MapFiltersModel
{
    private readonly MapFilter[] _filters;

    private static MapFiltersModel? _instance;

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
        PopByTribeFilter = new MapFilter(MapFilterType.PopByTribe, true);
        CountriesFilter = new MapFilter(MapFilterType.Countries);
        LifeStandardFilter = new MapFilter(MapFilterType.LifeStandard);
        UrbanizationFilter = new MapFilter(MapFilterType.Urbanization);

        _filters = new[] { PopByTribeFilter, CountriesFilter, LifeStandardFilter, UrbanizationFilter };
    }
}