using System;
using SimulateTheWorld.Core.GUI.MVVM;
using SimulateTheWorld.Core.Logging;
using SimulateTheWorld.GUI.ViewModels.Commands.SidePanel;

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
        Logger.Info(this, $"Set \"Next Round\" button enable {en}");
        
        NextRoundEnabled = enable;
    }

    public void SetUpdateWorldRendering(Action? triggerUpdateWorldRendering)
    {
        NextRoundCommand.TriggerUpdateWorldRendering += triggerUpdateWorldRendering;
    }
}