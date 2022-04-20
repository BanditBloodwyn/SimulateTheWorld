using OpenTK.Graphics.OpenGL4;

namespace SimulateTheWorld.Graphics.Data.OpenGL;

public class VAO
{
    private int ID { get; }

    public VAO()
    {
        ID = GL.GenVertexArray();
    }

    public void LinkVBO(VBO vbo, int layout)
    {
        vbo.Bind();

        GL.VertexAttribPointer(layout, 3, VertexAttribPointerType.Float, false, 0, 0);
        GL.EnableVertexAttribArray(layout);

        vbo.Unbind();
    }

    public void Bind() => GL.BindVertexArray(ID);

    public void Unbind() => GL.BindVertexArray(0);

    public void Delete() => GL.DeleteVertexArray(ID);
}