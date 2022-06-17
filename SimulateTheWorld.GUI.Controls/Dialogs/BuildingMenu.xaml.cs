using System;
using System.Windows.Controls;
using System.Windows.Input;
using SimulateTheWorld.GUI.ViewModels.Dialogs.BuildingMenu;
using SimulateTheWorld.World.Data.Types.Classes;

namespace SimulateTheWorld.GUI.Controls.Dialogs;

/// <summary>
/// Interaktionslogik für BuildingMenu.xaml
/// </summary>
public partial class BuildingMenu
{
    private readonly BuildingMenuViewModel _viewModel;

    public BuildingMenu(TerrainTile? tile)
    {
        InitializeComponent();

        _viewModel = (DataContext as BuildingMenuViewModel)!;
        _viewModel.Tile = tile;
    }

    private void OnBuildingClicked(object sender, MouseButtonEventArgs e)
    {
        if (sender is not TreeViewItem item)
            return;

        Type type = (item.DataContext as BuildingItem)!.Building.GetType();
        _viewModel.Build(type);
    }
}