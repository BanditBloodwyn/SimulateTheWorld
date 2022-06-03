using System;
using System.Collections.Generic;
using SimulateTheWorld.World.Systems.Instances;

namespace SimulateTheWorld.World.Systems
{
    public class TileMarker
    {
        private readonly List<int> markedIDs = new();

        public event Action? OnUpdateVertexData;

        public void MarkTile(int tileID, bool demarkRest)
        {
            if (demarkRest)
            {
                foreach (int id in markedIDs)
                    STWWorld.Instance.Terrain.Tiles[id].Marked = false;
                markedIDs.Clear();
            }

            if (tileID > STWWorld.Instance.Terrain.Tiles.Length - 1)
                return;

            STWWorld.Instance.Terrain.Tiles[tileID].Marked = true;
            markedIDs.Add(tileID);

            OnUpdateVertexData?.Invoke();
        }
    }
}
