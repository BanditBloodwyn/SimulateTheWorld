using System.Windows;
using SimulateTheWorld.GUI.ViewModels.Dialogs;
using SimulateTheWorld.World.Core;
using SimulateTheWorld.World.Data.Types.Classes;

namespace SimulateTheWorld.GUI.ViewModels.RenderingControl;

public class TileContextMenuHandler
{
    private static TileContextMenuHandler? _instance;

    public Window? Menu { get; set; } = null;

    public bool ContextMenuOpened => Menu != null && Menu.IsActive;
    
    public static TileContextMenuHandler Instance
    {
        get { return _instance ??= new TileContextMenuHandler(); }
    }

    public void Open(int id, Point mousePosition)
    {
        if (Menu == null)
            return;

        TerrainTile tile = STWWorld.Instance.Terrain.Tiles[id];
        (Menu.DataContext as TileContextMenuViewModel)!.Tile = tile;

        Menu.Top = mousePosition.Y;
        Menu.Left = mousePosition.X;
        Menu.Show();
    }

    public void Hide()
    {
        Menu?.Hide();
    }

    public void Close()
    {
        Menu?.Close();
    }
}