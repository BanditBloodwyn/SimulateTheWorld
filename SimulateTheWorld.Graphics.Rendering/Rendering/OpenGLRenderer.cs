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
    private readonly ShaderProgram _normalsShader;
    private readonly ShaderProgram _pointShader;
    private readonly STWShape[] _shapes;
    private readonly STWShape _world;

    public FPSCounter FpsCounter { get; private set; }

    public Camera Camera { get; }
    
    public OpenGLRenderer()
    {
        _shaderProgram = new ShaderProgram("Rendering/Shaders/default.vert", "Rendering/Shaders/default.frag", "Rendering/Shaders/default.geom");
        _normalsShader = new ShaderProgram("Rendering/Shaders/default.vert", "Rendering/Shaders/normals.frag", "Rendering/Shaders/normals.geom");
        _pointShader = new ShaderProgram("Rendering/Shaders/point.vert", "Rendering/Shaders/points.frag", "Rendering/Shaders/points.geom");

        _shapes = WorldObjectProvider.CreateWorldTiles();
        _world = WorldObjectProvider.CreateWorldObject();

        Camera = new Camera(new Vector3(15.0f, 15.0f, 0));

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

        DrawShapes();
    }

    private void DrawShapes()
    {
        foreach (STWShape shape in _shapes)
        {
            shape.Draw(_shaderProgram, Camera);
        //    shape.Draw(_normalsShader, Camera);
        }
        //_world.Draw(_shaderProgram, Camera);
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