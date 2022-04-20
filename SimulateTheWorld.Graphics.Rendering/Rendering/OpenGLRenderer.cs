using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Data;

namespace SimulateTheWorld.Graphics.Rendering.Rendering;

public class OpenGLRenderer
{
    private readonly ShaderProgram _shaderProgram;
    private readonly int _vao;
    private readonly int _vbo;
    private readonly int _ebo;

    public OpenGLRenderer()
    {
        OpenGLPreparer.PrepareOpenGL(out _shaderProgram, out _vbo, out _vao, out _ebo);
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

        GL.DrawElements(PrimitiveType.Triangles, 9, DrawElementsType.UnsignedInt, 0);
    }

    public void OnUnLoaded()
    {
        OpenGLPreparer.DestroyOpenGL(_vbo, _vao, _ebo);
    }

    public void UpdateViewPort(double width, double height)
    {
        GL.Viewport(0, 0, (int)width, (int)height);
    }
}