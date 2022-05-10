using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Threading;
using SimulateTheWorld.Graphics.Data.Components;
using SimulateTheWorld.Graphics.Data.Interfaces;
using SimulateTheWorld.World.Data.Instances;

namespace SimulateTheWorld.Graphics.Rendering.Utilities;

public static class VertexUpdater
{
    public static void UpdateVertexData(IDrawable drawable, Dispatcher dispatcher)
    {
        int updatedVerticesCount = 0;

        try
        {
            if (drawable is PointCloud pointCloud)
            {
                for (int i = 0; i < pointCloud.Vertices.Length; i++)
                {
                    TerrainTile tile = STWWorld.Instance.Terrain.Tiles[i];
                    pointCloud.Vertices[i].tileType = (int)tile.TileType;
                    pointCloud.Vertices[i].terrainType = (int)tile.TerrainType;
                    updatedVerticesCount++;
                }

                dispatcher.Invoke(pointCloud.UpdateVertexData);
                Debug.WriteLine($"\tUpdated vertices: {updatedVerticesCount}");
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine($"Vertex randomization failed: {e}");
            throw;
        }
    }
}