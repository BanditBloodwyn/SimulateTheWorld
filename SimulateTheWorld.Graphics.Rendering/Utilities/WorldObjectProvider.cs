using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Data;
using SimulateTheWorld.Graphics.Data.Components;
using SimulateTheWorld.World.Systems.Instances;

namespace SimulateTheWorld.Graphics.Rendering.Utilities;

public static class WorldObjectProvider
{
    public static GameObject CreateWorldObject()
    {
        GameObject gameObject = new GameObject(0);

        gameObject.Drawable = new PointCloud(CreateInitialVertices());
        VertexUpdater.UpdateVertexData(gameObject.Drawable);

        return gameObject;
    }

    private static DataVertex[] CreateInitialVertices()
    {
        DataVertex[] vertices = new DataVertex[STWWorld.TerrainSize * STWWorld.TerrainSize];

        for (int x = 0; x < STWWorld.TerrainSize; x++)
        {
            for (int y = 0; y < STWWorld.TerrainSize; y++)
            {
                int i = x + y * STWWorld.TerrainSize;
                vertices[i] = new DataVertex(new Vector3(x * STWWorld.TileSize, 0, y * STWWorld.TileSize));
            }
        }

        return vertices;
    }
}