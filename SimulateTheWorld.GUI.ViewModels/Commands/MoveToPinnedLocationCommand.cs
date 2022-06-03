using System;
using System.Windows.Input;
using SimulateTheWorld.World.Systems.Instances;

namespace SimulateTheWorld.GUI.ViewModels.Commands;

public class MoveToPinnedLocationCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;
    
    public bool CanExecute(object? parameter)
    {
        throw new NotImplementedException();
    }

    public void Execute(object? parameter)
    {
        if (parameter is int id)
            STWWorld.Instance.Terrain.MarkTile(id);
    }
}