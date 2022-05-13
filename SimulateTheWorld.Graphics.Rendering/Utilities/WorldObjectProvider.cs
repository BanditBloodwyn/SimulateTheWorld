using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Data;
using SimulateTheWorld.Graphics.Data.Components;
using SimulateTheWorld.World.Data.Instances;

namespace SimulateTheWorld.Graphics.Rendering.Utilities;

public static class WorldObjectProvider
{
    public static GameObject CreateWorldObject()
    {
        GameObject gameObject = new GameObject(0);

        gameObject.Drawable = new PointCloud(CreateInitialVertices());
        VertexUpdater.UpdateVertexData(gameObject.Drawable);
        gameObject.Transform.Rotate(0, 90, 0);

        return gameObject;
    }

    private static DataVertex[] CreateInitialVertices()
    {
        DataVertex[] vertices = new DataVertex[STWTerrain.TerrainSize * STWTerrain.TerrainSize];

        for (int x = 0; x < STWTerrain.TerrainSize; x++)
        {
            for (int y = 0; y < STWTerrain.TerrainSize; y++)
            {
                int i = x + y * STWTerrain.TerrainSize;
                vertices[i] = new DataVertex(new Vector3(x * STWTerrain.TileSize, 0, y * STWTerrain.TileSize));
            }
        }

        return vertices;
    }
}