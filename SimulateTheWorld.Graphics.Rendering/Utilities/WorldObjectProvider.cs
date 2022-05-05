using System;
using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Data.Components;
using SimulateTheWorld.Graphics.Data.OpenGL;
using SimulateTheWorld.Graphics.Shapes;
using SimulateTheWorld.World.Data.Instances;

namespace SimulateTheWorld.Graphics.Rendering.Utilities;

public static class WorldObjectProvider
{
    public static STWShape CreateWorldObject()
    {
        STWShape shape = new STWShape(0);
        shape.Drawable = new PointCloud(CreateData());
        shape.Transform.Rotate(0, 90, 0);
        return shape;
    }

    private static DataVertex[] CreateData()
    {
        DataVertex[] vertices = new DataVertex[STWTerrain.TerrainSize * STWTerrain.TerrainSize];
        Random random = new Random();

        for (int x = 0; x < STWTerrain.TerrainSize; x++)
        {
            for (int y = 0; y < STWTerrain.TerrainSize; y++)
            {
                int i = x + y * STWTerrain.TerrainSize;
                int tile = random.Next(0, 2);
                int terrain = random.Next(0, 3);
                vertices[i] = new DataVertex(
                    new Vector3(x * STWTerrain.TileSize, 0, y * STWTerrain.TileSize), 
                    tile, 
                    terrain);
            }
        }

        return vertices;
    }
}