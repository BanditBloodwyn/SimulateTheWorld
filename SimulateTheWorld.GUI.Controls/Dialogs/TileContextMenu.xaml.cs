using System.Windows;
using System.Windows.Input;
using SimulateTheWorld.GUI.Core.Helper;
using SimulateTheWorld.GUI.ViewModels.Dialogs;

namespace SimulateTheWorld.GUI.Controls.Dialogs;

/// <summary>
/// Interaktionslogik für TileContextMenu.xaml
/// </summary>
public partial class TileContextMenu
{
    private readonly TileContextMenuViewModel _viewModel;

    public TileContextMenu()
    {
        InitializeComponent();

        _viewModel = DataContext as TileContextMenuViewModel ?? new TileContextMenuViewModel();
    }

    private void MenuItem_OnPinTileClick(object sender, RoutedEventArgs e)
    {
        if(_viewModel.Tile == null || _viewModel.Tile.Pinned)
            _viewModel.PinTileCommand.Execute(null);
        else
        {
            Point point = Point.Add(Mouse.GetPosition(this), new Vector(Left, Top));
            DialogOpener.Open(new PinTileControl(_viewModel.Tile), WindowStyle.None, point);
        }

        Hide();
    }

    private void MenuItem_OnBuildClick(object sender, RoutedEventArgs e)
    {
        Point point = Point.Add(Mouse.GetPosition(this), new Vector(Left, Top));
        DialogOpener.Open(new BuildingMenu(_viewModel.Tile), WindowStyle.ToolWindow, point);
       
        Hide();
    }
}