using SimulateTheWorld.Core.MVVM;
using SimulateTheWorld.Models.SidePanel.Panels.MapFilters;

namespace SimulateTheWorld.ViewModels.SidePanel.Panels.MapFilters;

public class MapFiltersViewModel : ObservableObject
{
    private readonly MapFiltersModel _model;

    public MapFiltersModel Model
    {
        get => _model;
        private init
        {
            if (_model.Equals(value))
                return;

            _model = value;
            OnPropertyChanged();
        }
    }


    public MapFiltersViewModel()
    {
        _model = new MapFiltersModel();
        Model = _model;
    }
}