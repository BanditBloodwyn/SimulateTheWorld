﻿using System.Windows;

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

    private void MenuItem_OnClick(object sender, RoutedEventArgs e)
    {
        _viewModel.PinTile();
        Hide();
    }
}