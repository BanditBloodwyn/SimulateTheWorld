using System;
using System.Threading.Tasks;
using System.Windows.Input;
using SimulateTheWorld.Core.Logging;
using SimulateTheWorld.World.Systems.Instances;

namespace SimulateTheWorld.GUI.ViewModels.Commands.SidePanel;

public class NextRoundCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;
    public event Action? TriggerUpdateWorldRendering;
    public event Action<bool>? OnEnableNextRoundButton;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        Logger.Group("NextRoundCommand");

        Task.Factory
            .StartNew(() => OnEnableNextRoundButton?.Invoke(false))
            .ContinueWith(_ => STWWorld.Instance.Update())
            .ContinueWith(_ => TriggerUpdateWorldRendering?.Invoke())
            .ContinueWith(_ => OnEnableNextRoundButton?.Invoke(true))
            .ContinueWith(_ => Logger.Group("NextRoundCommand"));
    }

    public void OnCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}