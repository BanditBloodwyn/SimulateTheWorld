using System.Collections.Generic;

namespace SimulateTheWorld.World.Core.Helper;

public class TileMarker
{
    public List<int> MarkedIDs { get; } = new();

    public void MarkTile(int tileID, bool demarkRest)
    {
        if (demarkRest)
        {
            foreach (int id in MarkedIDs)
                STWWorld.Instance.Terrain.Tiles[id].Marked = false;
            MarkedIDs.Clear();
        }

        if (tileID > STWWorld.Instance.Terrain.Tiles.Length - 1)
            return;

        STWWorld.Instance.Terrain.Tiles[tileID].Marked = true;
        MarkedIDs.Add(tileID);
    }
}