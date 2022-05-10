using System;
using System.Threading.Tasks;
using System.Windows.Input;
using SimulateTheWorld.World.Data.Instances;

namespace SimulateTheWorld.GUI.ViewModels.Commands;

public class NextRoundCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;
    public event Action? TriggerUpdateWorldRendering;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        Task.Factory.StartNew(STWWorld.Instance.Update)
            .ContinueWith(_ => TriggerUpdateWorldRendering?.Invoke());
    }
}