using OpenTK.Graphics.OpenGL4;

namespace SimulateTheWorld.Graphics.Data.OpenGL;

public class EBO
{
    private int ID { get; }

    public EBO(int[] indices)
    {
        ID = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, ID);
        GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(int), indices, BufferUsageHint.StaticDraw);
    }

    public void Bind() => GL.BindBuffer(BufferTarget.ElementArrayBuffer, ID);

    public void Unbind() => GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);

    public void Delete() => GL.DeleteBuffer(ID);
}