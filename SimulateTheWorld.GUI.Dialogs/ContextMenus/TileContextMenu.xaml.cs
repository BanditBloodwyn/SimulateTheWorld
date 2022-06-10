using System.Windows;
using System.Windows.Input;

namespace SimulateTheWorld.GUI.Dialogs.ContextMenus;

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
            _viewModel.OpenPinTileControlCommand?.Execute(point);
        }

        Hide();
    }
}