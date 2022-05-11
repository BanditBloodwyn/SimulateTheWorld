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

        for (int x = 0; x < STWTerrain.TerrainSize; x++)
        {
            for (int y = 0; y < STWTerrain.TerrainSize; y++)
            {
                int i = x + y * STWTerrain.TerrainSize;

                TerrainTile tile = STWWorld.Instance.Terrain.Tiles[i];

                vertices[i] = new DataVertex(
                    new Vector3(x * STWTerrain.TileSize, 0, y * STWTerrain.TileSize),
                    (int)tile.TileType,
                    (int)tile.TerrainType,
                    tile.PopulationValues.Population.Quantity,
                    0,
                    tile.PopulationValues.LifeStandard,
                    tile.PopulationValues.Urbanization);
            }
        }

        return vertices;
    }
}