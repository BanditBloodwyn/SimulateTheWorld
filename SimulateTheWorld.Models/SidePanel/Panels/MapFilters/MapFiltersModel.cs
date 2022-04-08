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
   
    public MapFilter[] ActiveFilters => _filters.Where(filter => filter.Active).ToArray();

    public static MapFiltersModel Instance
    {
        get { return _instance ??= new MapFiltersModel(); }
    }

    private MapFiltersModel()
    {
        PopByTribeFilter = new MapFilter(true);
        CountriesFilter = new MapFilter();
        LifeStandardFilter = new MapFilter();
        UrbanizationFilter = new MapFilter();

        _filters = new[] { PopByTribeFilter, CountriesFilter, LifeStandardFilter, UrbanizationFilter };
    }
}