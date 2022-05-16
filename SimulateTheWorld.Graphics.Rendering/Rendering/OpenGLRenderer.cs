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
    private readonly ShaderProgram _pointShader;
    private readonly GameObject _world;

    public FPSCounter FpsCounter { get; }

    public Camera Camera { get; }
    
    public OpenGLRenderer()
    {
        _pointShader = new ShaderProgram("Rendering/Shaders/point.vert", "Rendering/Shaders/points.frag", "Rendering/Shaders/points.geom");
        ShaderPreparer.PrepareShader(_pointShader);

        _world = WorldObjectProvider.CreateWorldObject();

        Camera = new Camera(new Vector3(STWTerrain.TerrainSize / 2.0f * STWTerrain.TileSize, 15.0f, STWTerrain.TerrainSize / 2.0f * STWTerrain.TileSize));
        FpsCounter = new FPSCounter();
        MapFiltersModel.Instance.SetOnMapFilterChanged(() => ShaderPreparer.SetFilterColors(_pointShader));

        GL.Enable(EnableCap.DepthTest);
        GL.Enable(EnableCap.CullFace);
        GL.FrontFace(FrontFaceDirection.Cw);
    }

    public void OnLoaded() { }

    public void OnRender(TimeSpan elapsedTimeSpan)
    {
        FpsCounter.TimeDifference = elapsedTimeSpan.Milliseconds;

        GL.ClearColor(new Color4(0, 0, 40, 0));
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