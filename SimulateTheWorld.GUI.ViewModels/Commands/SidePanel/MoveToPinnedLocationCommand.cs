﻿using System;
using System.Windows.Input;
using SimulateTheWorld.GUI.Mediators.Mediators;
using SimulateTheWorld.GUI.Mediators.Messages;
using SimulateTheWorld.World.Data.Data;
using SimulateTheWorld.World.Data.Types.Classes;
using SimulateTheWorld.World.Systems.Instances;

namespace SimulateTheWorld.GUI.ViewModels.Commands.SidePanel;

public class MoveToPinnedLocationCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        if (parameter is Tuple<Location?, int> location)
        {
            STWWorld.Instance.Terrain.TileMarker.MarkTile(location.Item2, true);

            if (location.Item1 == null)
                return;

            CameraMoverMediator.Instance.Publish(new CameraMoverMessage
            {
                X = location.Item1.Coordinate.X * WorldProperties.Instance.TileTotalSize,
                Y = location.Item1.Coordinate.Y * WorldProperties.Instance.TileTotalSize
            });
        }
    }

    public void OnCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}