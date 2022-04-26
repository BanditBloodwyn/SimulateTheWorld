using System;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using SimulateTheWorld.Graphics.Data;
using SimulateTheWorld.Graphics.Data.OpenGL;
using SimulateTheWorld.Graphics.Rendering.Utilities;
using SimulateTheWorld.Graphics.Shapes;

namespace SimulateTheWorld.Graphics.Rendering.Rendering;

public class OpenGLRenderer
{
    private readonly ShaderProgram _shaderProgram;
    private readonly STWShape[] _shapes;

    public FPSCounter FpsCounter { get; private set; }

    public Camera Camera { get; }
    
    public OpenGLRenderer()
    {
        _shaderProgram = new ShaderProgram("Rendering/Shaders/shader.vert", "Rendering/Shaders/shader.frag");

        _shapes = WorldObjectProvider.CreateWorldTiles();

        Camera = new Camera(new Vector3(0.0f, 1.0f, -2.0f));

        GL.Enable(EnableCap.DepthTest);
        GL.Enable(EnableCap.CullFace);
        GL.FrontFace(FrontFaceDirection.Cw);
        FpsCounter = new FPSCounter();
    }

    public void OnLoaded() { }

    public void OnRender()
    {
        FpsCounter.CurrentTime = GLFW.GetTime();
        GL.ClearColor(new Color4(0, 0, 40, 0));
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        foreach (STWShape shape in _shapes)
        {
            shape.Draw(_shaderProgram, Camera);
        }
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