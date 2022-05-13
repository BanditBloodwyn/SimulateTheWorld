using System.Collections.Generic;
using SimulateTheWorld.World.System.Instances;

namespace SimulateTheWorld.World.System
{
    public class TileMarker
    {
        private readonly List<int> markedIDs = new();

        public void MarkTile(int tileID, bool demarkRest)
        {
            if(demarkRest)
            {
                foreach (int id in markedIDs)
                    STWWorld.Instance.Terrain.Tiles[id].Marked = false;
                markedIDs.Clear();
            }

            STWWorld.Instance.Terrain.Tiles[tileID].Marked = true;
            markedIDs.Add(tileID);
        }
    }
}
