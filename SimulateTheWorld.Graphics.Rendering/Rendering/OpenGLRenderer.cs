using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Data;

namespace SimulateTheWorld.Graphics.Rendering.Rendering;

public class OpenGLRenderer
{
    private readonly ShaderProgram _shaderProgram;
    private readonly int _vao;

    public OpenGLRenderer()
    {
        OpenGLPreparer.PrepareOpenGL(out _shaderProgram, out _vao);
    }

    public void OnLoaded()
    {

    }

    public void OnRender()
    {
        GL.ClearColor(new Color4(0, 0, 40, 0));
        GL.Clear(ClearBufferMask.ColorBufferBit);

        _shaderProgram.Use();

        GL.BindVertexArray(_vao);

        GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
    }

    public void OnUnLoaded()
    {
        OpenGLPreparer.DestroyOpenGL();
    }

    public void UpdateViewPort(double width, double height)
    {
        GL.Viewport(0, 0, (int)width, (int)height);
    }
}