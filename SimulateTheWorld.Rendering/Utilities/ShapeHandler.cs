using System.Collections.Generic;
using SimulateTheWorld.Graphics.Data;
using SimulateTheWorld.Graphics.Shapes;
using SimulateTheWorld.World;

namespace SimulateTheWorld.Graphics.Rendering.Utilities;

public static class ShapeHandler
{
    public static STWShape[] CreateShapes()
    {
        STWShape[] tileShapes = CreateWorldTiles();
        return tileShapes;
    }

    private static STWShape[] CreateWorldTiles()
    {
        float tileSize = 3;

        TerrainTile[,] terrainTiles = STWWorld.Instance.Terrain.Tiles;

        List<STWQuadrilateral> tileShapes = new List<STWQuadrilateral>();
        Texture texture = Texture.LoadFromFile(Resources.Rendering.Textures.Diffuse.Paths.Tile);

        for (int x = 0; x < terrainTiles.GetLength(0); x++)
        {
            for (int y = 0; y < terrainTiles.GetLength(1); y++)
            {
                STWQuadrilateral tile = new STWQuadrilateral(tileSize, tileSize);
                tile.Material.SetTexture(texture);
                tile.Transform.Translate(x * tileSize, y * tileSize, 0);
                tileShapes.Add(tile);
            }
        }

        return tileShapes.ToArray();
    }

    public static int GetShapesVertexBufferSize(STWShape[] shapes)
    {
        List<float> allVertices = new List<float>();

        foreach (STWShape shape in shapes)
        {
            if(shape.Vertices != null) 
                allVertices.AddRange(shape.Vertices);
        }

        return allVertices.Count * sizeof(float);
    }

    public static int GetShapesIndexBufferSize(STWShape[] shapes)
    {
        List<int> allIndices = new List<int>();

        foreach (STWShape shape in shapes)
        {
            if (shape.Indices != null) 
                allIndices.AddRange(shape.Indices);
        }

        return allIndices.Count * sizeof(uint);
    }
}