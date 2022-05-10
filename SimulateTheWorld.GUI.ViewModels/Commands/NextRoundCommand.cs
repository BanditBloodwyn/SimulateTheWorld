using System;
using System.Windows.Input;

namespace SimulateTheWorld.GUI.ViewModels.Commands;

public class NextRoundCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;
    public event Action? TriggerNextRound;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        TriggerNextRound?.Invoke();
    }
}