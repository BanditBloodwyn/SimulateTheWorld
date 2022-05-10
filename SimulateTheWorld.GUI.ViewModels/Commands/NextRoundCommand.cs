using System;
using System.Threading.Tasks;
using System.Windows.Input;
using SimulateTheWorld.World.Data.Instances;

namespace SimulateTheWorld.GUI.ViewModels.Commands;

public class NextRoundCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;
    public event Action? TriggerUpdateWorldRendering;
    public event Action<bool>? OnEnableUpdateButton;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        Task.Factory
            .StartNew(() => OnEnableUpdateButton?.Invoke(false))
            .ContinueWith(_ => STWWorld.Instance.Update())
            .ContinueWith(_ => TriggerUpdateWorldRendering?.Invoke())
            .ContinueWith(_ => OnEnableUpdateButton?.Invoke(true));
    }

    public void OnCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}