﻿using SimulateTheWorld.Core.GUI.MVVM;
using SimulateTheWorld.World.Systems.Instances;

namespace SimulateTheWorld.GUI.ViewModels.SidePanel.Panels.MarkedTile;

public class MarkedTileViewModel : ObservableObject
{
    public TerrainTile? Tile { get; private set; }
    
    public void SetTile(int tileID)
    {
        if (tileID > STWWorld.Instance.Terrain.Tiles.Length - 1)
            return;

        Tile = STWWorld.Instance.Terrain.Tiles[tileID];

        OnPropertyChanged(nameof(Tile));
    }
}