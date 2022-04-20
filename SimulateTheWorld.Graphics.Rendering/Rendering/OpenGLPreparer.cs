using OpenTK.Graphics.OpenGL;
using SimulateTheWorld.Graphics.Data;
using SimulateTheWorld.Graphics.Rendering.Utilities;

namespace SimulateTheWorld.Graphics.Rendering.Rendering;

public static class OpenGLPreparer
{
    public static void PrepareOpenGL(out ShaderProgram shaderProgram, out int vbo, out int vao, out int ebo)
    {
        PrepareShader(out shaderProgram);
        PrepareBuffers(out vbo, out vao, out ebo);
    }

    private static void PrepareShader(out ShaderProgram shaderProgram)
    {
        shaderProgram = new ShaderProgram("Rendering/Shaders/shader.vert", "Rendering/Shaders/shader.frag");
    }

    private static void PrepareBuffers(out int vbo, out int vao, out int ebo)
    {
        vao = GL.GenVertexArray();
        vbo = GL.GenBuffer();
        ebo = GL.GenBuffer();

        GL.BindVertexArray(vao);
        
        GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
        GL.BufferData(BufferTarget.ArrayBuffer, TestData.Vertices.Length * sizeof(float), TestData.Vertices, BufferUsageHint.StaticDraw);

        GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
        GL.BufferData(BufferTarget.ElementArrayBuffer, TestData.Indices.Length * sizeof(int), TestData.Indices, BufferUsageHint.StaticDraw);

        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);

        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        GL.BindVertexArray(0);
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
    }

    public static void DestroyOpenGL(int vbo, int vao, int ebo)
    {
        GL.DeleteVertexArray(vao);
        GL.DeleteBuffer(vbo);
        GL.DeleteBuffer(ebo);
    }
}