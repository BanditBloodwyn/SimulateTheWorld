using OpenTK.Graphics.OpenGL4;
using SimulateTheWorld.Graphics.Data.Components;

namespace SimulateTheWorld.Graphics.Data.OpenGL;

public class VBO
{
    private int ID { get; }

    public unsafe VBO(Vertex[] vertices)
    {
        
        ID = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, ID);
        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(Vertex), vertices, BufferUsageHint.StaticDraw);
    }

    public unsafe VBO(DataVertex[] vertices)
    {

        ID = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, ID);
        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(DataVertex), vertices, BufferUsageHint.StaticDraw);
    }

    public unsafe void Update(DataVertex[] vertices)
    {
        GL.BindBuffer(BufferTarget.ArrayBuffer, ID);
        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(DataVertex), vertices, BufferUsageHint.StaticDraw);
    }

    public void Bind() => GL.BindBuffer(BufferTarget.ArrayBuffer, ID);

    public void Unbind() => GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

    public void Delete() => GL.DeleteBuffer(ID);
}