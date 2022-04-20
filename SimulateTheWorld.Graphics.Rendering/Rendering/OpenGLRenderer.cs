using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Data;
using SimulateTheWorld.Graphics.Rendering.Utilities;

namespace SimulateTheWorld.Graphics.Rendering.Rendering;

public class OpenGLRenderer
{
    private readonly ShaderProgram _shaderProgram;
    private readonly int _vao;

    public CircularCamera Camera { get; }

    public OpenGLRenderer()
    {
        Camera = new CircularCamera(Vector3.UnitZ * 10);

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
        Camera.AspectRatio = (float)(width / height);
        GL.Viewport(0, 0, (int)width, (int)height);
    }
}