using SimulateTheWorld.Core.MVVM;
using SimulateTheWorld.Models.SidePanel.Panels.MapFilters;

namespace SimulateTheWorld.GUI.ViewModels.SidePanel.Panels.MapFilters;

public class MapFiltersViewModel : ObservableObject
{
    public MapFiltersModel Model { get; }

    public MapFiltersViewModel()
    {
        Model = MapFiltersModel.Instance;

        GetMapFilterNames();
    }

    private void GetMapFilterNames()
    {
        Model.PopByTribeFilter.DisplayName = Resources.Localization.Locals_German.mapfilters_popByTribe;
        Model.CountriesFilter.DisplayName = Resources.Localization.Locals_German.mapfilters_countries;
        Model.LifeStandardFilter.DisplayName = Resources.Localization.Locals_German.mapfilters_lifeStandard;
        Model.UrbanizationFilter.DisplayName = Resources.Localization.Locals_German.mapfilters_urbanization;
    }
}