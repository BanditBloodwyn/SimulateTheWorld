using SimulateTheWorld.Core.GUI.MVVM;
using SimulateTheWorld.GUI.Models.SidePanel.Panels.MapFilters;

namespace SimulateTheWorld.GUI.ViewModels.ViewModels.SidePanel.Panels.MapFilters;

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
        Model.VegetationZone.DisplayName = Resources.Localization.Locals_German.mapfilters_vegetationZone;
        Model.HeightFilter.DisplayName = Resources.Localization.Locals_German.mapfilters_height;
        Model.PopByTribeFilter.DisplayName = Resources.Localization.Locals_German.mapfilters_popByTribe;
        Model.CountriesFilter.DisplayName = Resources.Localization.Locals_German.mapfilters_countries;
        Model.LifeStandardFilter.DisplayName = Resources.Localization.Locals_German.mapfilters_lifeStandard;
        Model.UrbanizationFilter.DisplayName = Resources.Localization.Locals_German.mapfilters_urbanization;
        
        Model.Flora_DeciduousTrees.DisplayName = Resources.Localization.Locals_German.mapfilters_flora_deciduousTrees;
        Model.Flora_EvergreenTrees.DisplayName = Resources.Localization.Locals_German.mapfilters_flora_evergreenTrees;
        Model.Flora_Vegetables.DisplayName = Resources.Localization.Locals_German.mapfilters_flora_vegetables;
        Model.Flora_Fruits.DisplayName = Resources.Localization.Locals_German.mapfilters_flora_fruits;

        Model.Ressource_CoalFilter.DisplayName = Resources.Localization.Locals_German.mapfilters_ressource_coal;
        Model.Ressource_IronOreFilter.DisplayName = Resources.Localization.Locals_German.mapfilters_ressource_ironOre;
        Model.Ressource_GoldOreFilter.DisplayName = Resources.Localization.Locals_German.mapfilters_ressource_goldOre;
        Model.Ressource_OilFilter.DisplayName = Resources.Localization.Locals_German.mapfilters_ressource_Oil;
        Model.Ressource_GasFilter.DisplayName = Resources.Localization.Locals_German.mapfilters_ressource_Gas;
    }
}