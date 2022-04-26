using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;
using SimulateTheWorld.Graphics.Data;
using SimulateTheWorld.Graphics.Data.Enums;
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
                tile.Transform.Translate(-x * tileSize, 0, y * tileSize);
                tile.Transform.Rotate(-90, 0, 0);

                tileShapes.Add(tile);
            }
        }

        return tileShapes.ToArray();
    }
}