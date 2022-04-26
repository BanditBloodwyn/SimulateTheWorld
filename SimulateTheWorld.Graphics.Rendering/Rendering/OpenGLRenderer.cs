using System;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using SimulateTheWorld.Graphics.Data;
using SimulateTheWorld.Graphics.Data.OpenGL;
using SimulateTheWorld.Graphics.Rendering.Utilities;

namespace SimulateTheWorld.Graphics.Rendering.Rendering;

public class OpenGLRenderer
{
    private readonly ShaderProgram _shaderProgram;
    private readonly Mesh _mesh;

    public FPSCounter FpsCounter { get; private set; }

    public Camera Camera { get; }
    
    public OpenGLRenderer()
    {
        _shaderProgram = new ShaderProgram("Rendering/Shaders/shader.vert", "Rendering/Shaders/shader.frag");
        _mesh = new Mesh(TestData.Vertices, TestData.Indices, TestData.Textures);

        Vector3 objectPos = new Vector3(0.0f, 0.0f, 0.0f);
        Matrix4 objectModel = Matrix4.Identity;
        objectModel *= Matrix4.CreateTranslation(objectPos);
        _shaderProgram.SetMatrix4("model", objectModel);

        Camera = new Camera(new Vector3(0.0f, 1.0f, -2.0f));

        GL.Enable(EnableCap.DepthTest);
        GL.Enable(EnableCap.CullFace);
        GL.FrontFace(FrontFaceDirection.Cw);
        FpsCounter = new FPSCounter();
    }

    public void OnLoaded() { }

    public void OnRender(TimeSpan elapsedTimeSpan)
    {
        FpsCounter.CurrentTime = GLFW.GetTime();
        GL.ClearColor(new Color4(0, 0, 40, 0));
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        _mesh.Draw(_shaderProgram, Camera);
    }

    public void OnUnLoaded()
    {

    }

    public void UpdateViewPort(double width, double height)
    {
        GL.Viewport(0, 0, (int)width, (int)height);
        Camera.AspectRatio = (float)width / (float)height;
    }
}