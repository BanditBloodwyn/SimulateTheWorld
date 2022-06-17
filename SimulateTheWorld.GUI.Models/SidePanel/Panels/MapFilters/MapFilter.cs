using System;
using SimulateTheWorld.Core.Types.Enums;
using SimulateTheWorld.GUI.Core.MVVM;

namespace SimulateTheWorld.GUI.Models.SidePanel.Panels.MapFilters;

public class MapFilter : ObservableObject
{
    private bool _active;

    public event Action<MapFilterType, bool>? MapFilterChanged;
    public event Action<MapFilter>? OnMapFilterChanged;

    public string? DisplayName { get; set; }
    
    public MapFilterType Type { get; }

    public bool Active
    {
        get => _active;
        set
        {
            if (_active != value)
            {
                _active = value;
                MapFilterChanged?.Invoke(Type, Active);

                OnPropertyChanged();

                if(_active)
                    OnMapFilterChanged?.Invoke(this);
            }
        }
    }

    public MapFilter(MapFilterType type, bool active = false)
    {
        Type = type;
        Active = active;
    }
}