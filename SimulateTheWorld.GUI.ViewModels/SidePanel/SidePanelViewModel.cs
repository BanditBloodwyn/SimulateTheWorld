using System;
using System.Threading.Tasks;
using SimulateTheWorld.Core.Logging;
using SimulateTheWorld.GUI.Core.MVVM;
using SimulateTheWorld.GUI.Core.MVVM.Commands;
using SimulateTheWorld.World.Core;

namespace SimulateTheWorld.GUI.ViewModels.SidePanel;

public class SidePanelViewModel : ObservableObject
{
    private bool _nextRoundEnabled;
    public event Action? TriggerUpdateWorldRendering;

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

    public DelegateCommand NextRoundCommand { get; }

    public SidePanelViewModel()
    {
        NextRoundEnabled = true;

        NextRoundCommand = new DelegateCommand(_ =>
        {
            Logger.Group("NextRoundCommand");

            Task.Factory
                .StartNew(() => OnEnableNextRoundButton(false))
                .ContinueWith(static _ => STWWorld.Instance.NextRoundTrigger())
                .ContinueWith(_ => TriggerUpdateWorldRendering?.Invoke())
                .ContinueWith(_ => OnEnableNextRoundButton(true))
                .ContinueWith(static _ => Logger.Group("NextRoundCommand"));

        });
    }

    private void OnEnableNextRoundButton(bool enable)
    {
        string en = enable ? "true" : "false";
        Logger.Debug(this, $"Set \"Next Round\" button enable {en}");
        
        NextRoundEnabled = enable;
    }

    public void SetUpdateWorldRendering(Action? triggerUpdateWorldRendering)
    {
        TriggerUpdateWorldRendering += triggerUpdateWorldRendering;
    }
}