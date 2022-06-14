using System.Windows;
using SimulateTheWorld.GUI.ViewModels.Dialogs;
using SimulateTheWorld.World.Data.Types.Classes;

namespace SimulateTheWorld.GUI.Controls.Dialogs;

/// <summary>
/// Interaktionslogik für PinTileControl.xaml
/// </summary>
public partial class PinTileControl
{
    private readonly PinTileControlViewModel _viewModel;

    public PinTileControl(TerrainTile tile)
    {
        InitializeComponent();

        _viewModel = (DataContext as PinTileControlViewModel)!;
        _viewModel.Tile = tile;
    }

    private void ButtonBase_OnPinTileClick(object sender, RoutedEventArgs e)
    {
        _viewModel.PinTileCommand.Execute(null);
        Close();
    }

    private void ButtonBase_OnCancelClick(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Close()
    {
        if (Parent is Window window)
            window.Close();
    }
}