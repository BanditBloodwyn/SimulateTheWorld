using System.Windows;
using SimulateTheWorld.GUI.Dialogs.ContextMenus;
using SimulateTheWorld.World.Data.Types.Classes;
using SimulateTheWorld.World.Systems.Instances;

namespace SimulateTheWorld.Graphics.Rendering.Utilities;

public class TileContextMenuHandler
{
    private readonly TileContextMenu _menu;

    public bool ContextMenuOpened => _menu.IsActive;

    public TileContextMenuHandler()
    {
        _menu = new TileContextMenu();
    }

    public void Open(int id, Point mousePosition)
    {
        TerrainTile tile = STWWorld.Instance.Terrain.Tiles[id];
        (_menu.DataContext as TileContextMenuViewModel)!.Tile = tile;

        _menu.Top = mousePosition.Y;
        _menu.Left = mousePosition.X;
        _menu.Show();
    }

    public void Hide()
    {
        _menu.Hide();
    }

    public void Close()
    {
        _menu.Close();
    }
}