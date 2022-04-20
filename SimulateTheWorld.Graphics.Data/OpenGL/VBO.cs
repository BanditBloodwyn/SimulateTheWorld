using OpenTK.Graphics.OpenGL4;

namespace SimulateTheWorld.Graphics.Data.OpenGL;

public class VBO
{
    private int ID { get; }

    public VBO(float[] vertices)
    {
        ID = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, ID);
        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
    }

    public void Bind() => GL.BindBuffer(BufferTarget.ArrayBuffer, ID);

    public void Unbind() => GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

    public void Delete() => GL.DeleteBuffer(ID);
}