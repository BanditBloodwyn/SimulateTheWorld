using System;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Data;
using SimulateTheWorld.Graphics.Data.OpenGL;
using SimulateTheWorld.Graphics.Rendering.Utilities;
using SimulateTheWorld.GUI.Models.SidePanel.Panels.MapFilters;
using SimulateTheWorld.World.Data.Data;

namespace SimulateTheWorld.Graphics.Rendering.Rendering;

public class OpenGLRenderer
{
    private ShaderProgram? _pointShader;
    private GameObject? _world;

    public FPSCounter? FpsCounter { get; private set; }

    public void OnLoaded()
    {
        _world = WorldObjectProvider.CreateWorldObject();
       
        _pointShader = new ShaderProgram("Rendering/Shaders/point.vert", "Rendering/Shaders/points.frag", "Rendering/Shaders/points.geom");
        ShaderPreparer.PrepareShader(_pointShader);

        Camera.Instance.Transform.Position = new Vector3(WorldProperties.Instance.WorldSize / 2.0f * WorldProperties.Instance.TileTotalSize, 15.0f, WorldProperties.Instance.WorldSize / 2.0f * WorldProperties.Instance.TileTotalSize);
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
        if(FpsCounter != null) 
            FpsCounter.TimeDifference = elapsedTimeSpan.Milliseconds;

        GL.ClearColor(new Color4(0, 0, 80, 0));
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        if(_pointShader != null) 
            _world.Draw(_pointShader, Camera.Instance);
    }

    public void OnUpdateVertexData()
    {
        if (_world!.Drawable != null)
            VertexUpdater.UpdateVertexData(_world.Drawable);
    }

    public static void OnUnLoaded() { }

    public static void UpdateViewPort(double width, double height)
    {
        GL.Viewport(0, 0, (int)width, (int)height);
        Camera.Instance.AspectRatio = (float)width / (float)height;
    }
}