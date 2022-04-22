using System;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Data.OpenGL;
using SimulateTheWorld.Graphics.Rendering.Utilities;

namespace SimulateTheWorld.Graphics.Rendering.Rendering;

public class OpenGLRenderer
{
    private readonly ShaderProgram _shaderProgram;
    private readonly VAO _vao;
    private readonly VBO _vbo;
    private readonly EBO _ebo;

    private readonly Texture texture1;

    public Camera Camera { get; }
    
    private float _rotation;

    public OpenGLRenderer()
    {
        OpenGLPreparer.PrepareOpenGL(out _shaderProgram, out _vbo, out _vao, out _ebo);

        texture1 = Texture.LoadFromFile("Rendering/Textures/Diffuse/Diffuse_Tile.jpg", TextureUnit.Texture0);

        Camera = new Camera(new Vector3(0.0f, 0.0f, -2.0f));
    }

    public void OnLoaded() { }

    public void OnRender(TimeSpan elapsedTimeSpan, double width, double height)
    {
        GL.ClearColor(new Color4(0, 0, 40, 0));
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        _shaderProgram.Use();

        ApplyMatrices(elapsedTimeSpan);

        texture1.Bind();
        _vao.Bind();

        GL.DrawElements(PrimitiveType.Triangles, TestData.Indices.Length, DrawElementsType.UnsignedInt, 0);
    }

    private void ApplyMatrices(TimeSpan elapsedTimeSpan)
    {
        Matrix4 model = Matrix4.Identity;
        _rotation += 10f * elapsedTimeSpan.Milliseconds / 1000f;
        model *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(_rotation));

        _shaderProgram.SetMatrix4("model", model);
        Camera.Matrix(45.0f, 0.01f, 1000.0f, _shaderProgram);
    }

    public void OnUnLoaded()
    {
        OpenGLPreparer.DestroyOpenGL(_vbo, _vao, _ebo, _shaderProgram);
    }

    public void UpdateViewPort(double width, double height)
    {
        GL.Viewport(0, 0, (int)width, (int)height);
        Camera.AspectRatio = (float)width / (float)height;
    }
}