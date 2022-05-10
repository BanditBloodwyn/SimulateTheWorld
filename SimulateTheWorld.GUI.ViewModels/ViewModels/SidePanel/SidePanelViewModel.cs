using System;
using SimulateTheWorld.Core.MVVM;
using SimulateTheWorld.GUI.ViewModels.Commands;

namespace SimulateTheWorld.GUI.ViewModels.ViewModels.SidePanel;

public class SidePanelViewModel : ObservableObject
{
    private bool _updateEnabled;

    public bool UpdateEnabled
    {
        get => _updateEnabled;
        set
        {
            if (_updateEnabled != value)
            {
                _updateEnabled = value;
                OnPropertyChanged();
            }
        }
    }

    public NextRoundCommand NextRoundCommand { get; }

    public SidePanelViewModel()
    {
        UpdateEnabled = true;

        NextRoundCommand = new NextRoundCommand();
        NextRoundCommand.OnEnableUpdateButton += OnEnableUpdateButton;
    }

    private void OnEnableUpdateButton(bool enable)
    {
        UpdateEnabled = enable;
    }

    public void SetUpdateWorldRendering(Action? triggerUpdateWorldRendering)
    {
        NextRoundCommand.TriggerUpdateWorldRendering += triggerUpdateWorldRendering;
    }
}