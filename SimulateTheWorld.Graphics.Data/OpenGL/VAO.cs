using OpenTK.Graphics.OpenGL4;

namespace SimulateTheWorld.Graphics.Data.OpenGL;

public class VAO
{
    private int ID { get; }

    public VAO()
    {
        ID = GL.GenVertexArray();
    }

    public void LinkAttrib(VBO vbo, int layout, int numComponents, VertexAttribPointerType type, int stride, int offset)
    {
        vbo.Bind();

        GL.VertexAttribPointer(layout, numComponents, type, false, stride, offset);
        GL.EnableVertexAttribArray(layout);

        vbo.Unbind();
    }

    public void Bind() => GL.BindVertexArray(ID);

    public void Unbind() => GL.BindVertexArray(0);

    public void Delete() => GL.DeleteVertexArray(ID);
}