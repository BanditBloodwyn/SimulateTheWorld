using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Data;
using SimulateTheWorld.Graphics.Data.Components;
using SimulateTheWorld.World.Data.Data;

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
        DataVertex[] vertices = new DataVertex[WorldProperties.Instance.WorldSize * WorldProperties.Instance.WorldSize];

        for (int x = 0; x < WorldProperties.Instance.WorldSize; x++)
        {
            for (int y = 0; y < WorldProperties.Instance.WorldSize; y++)
            {
                int i = x + y * WorldProperties.Instance.WorldSize;
                vertices[i] = new DataVertex(new Vector3(x * WorldProperties.Instance.TileSize, 0, y * WorldProperties.Instance.TileSize));
            }
        }

        return vertices;
    }
}