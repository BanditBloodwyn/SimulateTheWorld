using System;
using OpenTK.Graphics.ES30;
using OpenTK.Mathematics;
using SimulateTheWorld.World;

namespace SimulateTheWorld.Rendering.Rendering;

public class OpenGLRenderer
{
    public void Render(TimeSpan elapsedTime)
    {
        GL.ClearColor(new Color4(0, 0, 70, 0));
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        TerrainTile[,] terrainTiles = STWWorld.Instance.Terrain.Tiles;
    }
}