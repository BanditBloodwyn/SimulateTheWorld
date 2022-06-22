using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        PinTile();
    }

    private void ButtonBase_OnCancelClick(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void PinTile()
    {
        _viewModel.PinTileCommand.Execute(null);
        Close();
    }

    private void Close()
    {
        if (Parent is Window window)
            window.Close();
    }

    private void Textbox_OnKeyUp(object sender, KeyEventArgs e)
    {
        if(e.Key == Key.Enter)
            PinTile();
    }

    private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        _viewModel.LocationName = (sender as TextBox).Text;
    }
}