using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;

namespace SimulateTheWorld.Graphics.Data.OpenGL;

public class VBO
{
    private int ID { get; }

    public unsafe VBO(Vertex[] vertices)
    {
        
        ID = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, ID);
        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(Vertex), GetData(vertices), BufferUsageHint.StaticDraw);
    }

    private float[] GetData(Vertex[] vertices)
    {
        List<float> data = new List<float>();
        foreach (Vertex vertex in vertices)
        {
            data.Add(vertex.position.X);
            data.Add(vertex.position.Y);
            data.Add(vertex.position.Z);
            
            data.Add(vertex.normal.X);
            data.Add(vertex.normal.Y);
            data.Add(vertex.normal.Z);
            
            data.Add(vertex.color.X);
            data.Add(vertex.color.Y);
            data.Add(vertex.color.Z);

            data.Add(vertex.textureUV.X);
            data.Add(vertex.textureUV.Y);
        }

        return data.ToArray();
    }

    public void Bind() => GL.BindBuffer(BufferTarget.ArrayBuffer, ID);

    public void Unbind() => GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

    public void Delete() => GL.DeleteBuffer(ID);
}