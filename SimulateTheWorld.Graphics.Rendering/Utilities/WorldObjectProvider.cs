using System.Collections.Generic;
using System.Linq;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Data;
using SimulateTheWorld.Graphics.Data.Enums;
using SimulateTheWorld.Graphics.Data.OpenGL;
using SimulateTheWorld.Graphics.Shapes;
using SimulateTheWorld.Graphics.Shapes.Primitives;
using SimulateTheWorld.World.Data.Instances;

namespace SimulateTheWorld.Graphics.Rendering.Utilities;

public static class WorldObjectProvider
{
    private const float tileSize = 1;
    
    public static STWShape[] CreateWorldTiles()
    {
        Texture texture = Texture.LoadFromFile("Rendering/Textures/Diffuse/Diffuse_Tile.jpg", TextureUnit.Texture0, TextureType.Diffuse);

        List<STWQuadrilateral> tileShapes = new List<STWQuadrilateral>();

        for (int x = 0; x < STWTerrain.TerrainSize; x++)
        {
            for (int y = 0; y < STWTerrain.TerrainSize; y++)
            {
                STWQuadrilateral tile = new STWQuadrilateral(
                    x * STWTerrain.TerrainSize + y,
                    tileSize,
                    tileSize,
                    texture);
                tile.Transform.Translate(x * tileSize, 0, -y * tileSize);
                tile.Transform.Rotate(0, 0, 0);

                tileShapes.Add(tile);
            }
        }

        return tileShapes.ToArray();
    }

    public static STWShape CreateWorldObject()
    {
        return null;
    }

    private static Mesh CreateWorldMesh()
    {
        Texture texture = Texture.LoadFromFile("Rendering/Textures/Diffuse/Diffuse_Tile.jpg", TextureUnit.Texture0, TextureType.Diffuse);
        Vertex[] vertices = new Vertex[STWTerrain.TerrainSize * STWTerrain.TerrainSize];
        int[] indices = new int[(STWTerrain.TerrainSize - 1) * (STWTerrain.TerrainSize - 1) * 6];
        
        int vertexIndex = 0;

        for (int x = 0; x < STWTerrain.TerrainSize; x++)
        {
            for (int y = 0; y < STWTerrain.TerrainSize; y++)
            {
                int i = x + y * STWTerrain.TerrainSize;

                // Vertices
                vertices[i] = new Vertex(new Vector3(x * tileSize, 0, y * tileSize), new Vector3(0, 1, 0), Vector3.One, Vector2.Zero);

                // Indices
                if (x != STWTerrain.TerrainSize - 1 && y != STWTerrain.TerrainSize - 1)
                {
                    indices[vertexIndex] = i;
                    indices[vertexIndex + 1] = i + STWTerrain.TerrainSize + 1;
                    indices[vertexIndex + 2] = i + STWTerrain.TerrainSize;

                    indices[vertexIndex + 3] = i;
                    indices[vertexIndex + 4] = i + 1;
                    indices[vertexIndex + 5] = i + STWTerrain.TerrainSize + 1;

                    vertexIndex += 6;
                }

            }
        }

        return new Mesh(vertices.ToArray(), indices.ToArray(), texture);
    }
}