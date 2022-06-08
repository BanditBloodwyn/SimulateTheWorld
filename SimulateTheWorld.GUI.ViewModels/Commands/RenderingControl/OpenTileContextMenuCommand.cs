using System;
using System.Windows.Controls;
using System.Windows.Input;
using SimulateTheWorld.GUI.Dialogs.ContextMenus;

namespace SimulateTheWorld.GUI.ViewModels.Commands.RenderingControl;

public class OpenTileContextMenuCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;
   
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        (int id, UserControl control) param = parameter as (int id, UserControl control)? ?? (0, null);

        var menu = new TileContextMenu();
        menu.IsOpen = true;
    }

    public void OnCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}