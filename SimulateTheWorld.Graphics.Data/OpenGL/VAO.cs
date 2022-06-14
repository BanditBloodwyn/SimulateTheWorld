using OpenTK.Graphics.OpenGL4;

namespace SimulateTheWorld.Graphics.Data.OpenGL;

public class VAO
{
    private int ID { get; }

    public VAO()
    {
        ID = GL.GenVertexArray();
    }

    public static void LinkAttrib(VBO vbo, int layout, int numComponents, VertexAttribPointerType type, int stride, int offset)
    {
        vbo.Bind();

        GL.VertexAttribPointer(layout, numComponents, type, false, stride, offset);
        GL.EnableVertexAttribArray(layout);

        VBO.Unbind();
    }
    public void LinkIntAttrib(VBO vbo, int layout, int numComponents, VertexAttribIntegerType type, int stride, int offset)
    {
        vbo.Bind();

        GL.VertexAttribIPointer(layout, numComponents, type, stride, ref offset);
        GL.EnableVertexAttribArray(layout);

        VBO.Unbind();
    }

    public void Bind() => GL.BindVertexArray(ID);

    public static void Unbind() => GL.BindVertexArray(0);

    public void Delete() => GL.DeleteVertexArray(ID);
}