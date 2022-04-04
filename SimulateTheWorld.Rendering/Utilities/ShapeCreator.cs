using System.Collections.Generic;
using SimulateTheWorld.Rendering.Rendering.Classes.Shapes;
using SimulateTheWorld.World;

namespace SimulateTheWorld.Rendering.Utilities;

public static class ShapeCreator
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

        for (int x = 0; x < terrainTiles.GetLength(0); x++)
        {
            for (int y = 0; y < terrainTiles.GetLength(1); y++)
            {
                STWQuadrilateral tile = new STWQuadrilateral(tileSize, tileSize);
                tile.Material.SetTexture("Rendering/Textures/Diffuse/Diffuse_Tile.png");
                tile.Transform.Translate(x * tileSize, y * tileSize, 0f);
                tileShapes.Add(tile);
            }
        }

        return tileShapes.ToArray();
    }
}