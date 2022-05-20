using System;
using System.Windows.Threading;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Data;
using SimulateTheWorld.Graphics.Data.OpenGL;
using SimulateTheWorld.Graphics.Rendering.Utilities;
using SimulateTheWorld.GUI.Models.SidePanel.Panels.MapFilters;
using SimulateTheWorld.World.System.Instances;

namespace SimulateTheWorld.Graphics.Rendering.Rendering;

public class OpenGLRenderer
{
    private ShaderProgram? _pointShader;
    private GameObject? _world;

    public FPSCounter FpsCounter { get; private set; }

    public Camera Camera { get; private set; }
    
    public void OnLoaded()
    {
        _world = WorldObjectProvider.CreateWorldObject();
       
        _pointShader = new ShaderProgram("Rendering/Shaders/point.vert", "Rendering/Shaders/points.frag", "Rendering/Shaders/points.geom");
        ShaderPreparer.PrepareShader(_pointShader);

        Camera = new Camera(new Vector3(STWWorld.TerrainSize / 2.0f * STWWorld.TileSize, 15.0f, STWWorld.TerrainSize / 2.0f * STWWorld.TileSize));
        FpsCounter = new FPSCounter();
        MapFiltersModel.Instance.SetOnMapFilterChanged(() => ShaderPreparer.SetFilterColors(_pointShader));

        GL.Enable(EnableCap.DepthTest);
        GL.Enable(EnableCap.CullFace);
        GL.FrontFace(FrontFaceDirection.Cw);
    }

    public void OnRender(TimeSpan elapsedTimeSpan)
    {
        if (_world == null)
            return;

        FpsCounter.TimeDifference = elapsedTimeSpan.Milliseconds;

        GL.ClearColor(new Color4(0, 0, 80, 0));
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        _world.Draw(_pointShader, Camera);
    }

    public void OnUpdateVertexData(Dispatcher dispatcher)
    {
        if (_world.Drawable != null)
            VertexUpdater.UpdateVertexData(_world.Drawable, dispatcher);
    }

    public void OnUnLoaded() { }

    public void UpdateViewPort(double width, double height)
    {
        GL.Viewport(0, 0, (int)width, (int)height);
        Camera.AspectRatio = (float)width / (float)height;
    }
}