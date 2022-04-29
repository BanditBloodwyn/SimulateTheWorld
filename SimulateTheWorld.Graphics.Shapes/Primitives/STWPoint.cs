using System;
using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Data;
using SimulateTheWorld.Graphics.Data.OpenGL;

namespace SimulateTheWorld.Graphics.Shapes.Primitives;

public class STWPoint : STWShape
{
    public STWPoint(long id)
        : base(id)
    {
        Vertex[] vertices = new[]
        {
            new Vertex(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), Vector3.One, new Vector2(0.0f, 0.0f)), // top right
        };

        int[] indices = { 0 };

        Mesh = new Mesh(vertices, indices, Array.Empty<Texture>());
    }
}