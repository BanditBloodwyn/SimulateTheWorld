using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using SimulateTheWorld.World.System.Instances;

namespace SimulateTheWorld.GUI.ViewModels.Commands;

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
        Debug.WriteLine("\n==================");

        Task.Factory
            .StartNew(() => OnEnableNextRoundButton?.Invoke(false))
            .ContinueWith(_ => STWWorld.Instance.Update())
            .ContinueWith(_ => TriggerUpdateWorldRendering?.Invoke())
            .ContinueWith(_ => OnEnableNextRoundButton?.Invoke(true))
            .ContinueWith(_ => Debug.WriteLine("==================\n"));
    }

    public void OnCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}