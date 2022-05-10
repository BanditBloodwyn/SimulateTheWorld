using System;
using System.Diagnostics;
using SimulateTheWorld.Core.MVVM;
using SimulateTheWorld.GUI.ViewModels.Commands;

namespace SimulateTheWorld.GUI.ViewModels.ViewModels.SidePanel;

public class SidePanelViewModel : ObservableObject
{
    private bool _nextRoundEnabled;

    public bool NextRoundEnabled
    {
        get => _nextRoundEnabled;
        set
        {
            if (_nextRoundEnabled != value)
            {
                _nextRoundEnabled = value;
                OnPropertyChanged();
            }
        }
    }

    public NextRoundCommand NextRoundCommand { get; }

    public SidePanelViewModel()
    {
        NextRoundEnabled = true;

        NextRoundCommand = new NextRoundCommand();
        NextRoundCommand.OnEnableNextRoundButton += OnEnableNextRoundButton;
    }

    private void OnEnableNextRoundButton(bool enable)
    {
        string en = enable ? "true" : "false";
        Debug.WriteLine($"Set \"Next Round\" button enable {en}");
        NextRoundEnabled = enable;
    }

    public void SetUpdateWorldRendering(Action? triggerUpdateWorldRendering)
    {
        NextRoundCommand.TriggerUpdateWorldRendering += triggerUpdateWorldRendering;
    }
}