using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Threading;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Data;
using SimulateTheWorld.Graphics.Data.OpenGL;
using SimulateTheWorld.Graphics.Rendering.Utilities;
using SimulateTheWorld.Graphics.Resources.Rendering;
using SimulateTheWorld.Models.SidePanel.Panels.MapFilters;
using SimulateTheWorld.World.Data.Instances;

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
        _world = WorldObjectProvider.CreateWorldObject();

        Camera = new Camera(new Vector3(STWTerrain.TerrainSize / 2.0f * STWTerrain.TileSize, 15.0f, 0));
        FpsCounter = new FPSCounter();
        MapFiltersModel.Instance.SetOnMapFilterChanged(OnMapFilterChanged);

        GL.Enable(EnableCap.DepthTest);
        GL.Enable(EnableCap.CullFace);
        GL.FrontFace(FrontFaceDirection.Cw);
    }

    private void OnMapFilterChanged()
    {
        if (MapFiltersModel.Instance.ActiveFilter != null)
        {
            Color[] colors = MapFilterColors.GetColorsByFilterType(MapFiltersModel.Instance.ActiveFilter.Type);
            Vector4 filterColorZero = new Vector4(colors[0].R / 255f, colors[0].G / 255f, colors[0].B / 255f, 1);
            Vector4 filterColorHundred = new Vector4(colors[1].R / 255f, colors[1].G / 255f, colors[1].B / 255f, 1);
            
            Debug.WriteLine($"Changing map filter\nNew map filter: {MapFiltersModel.Instance.ActiveFilter.DisplayName}, Colors: {filterColorZero}, {filterColorHundred}");

            _pointShader.SetVector4("uFilterColorZero", filterColorZero);
            _pointShader.SetVector4("uFilterColorHundred", filterColorHundred);
            _pointShader.SetInt("uFilterMode", (int)MapFiltersModel.Instance.ActiveFilter.Type);
        }
    }

    public void OnLoaded() { }

    public void OnRender(TimeSpan elapsedTimeSpan)
    {
        FpsCounter.TimeDifference = elapsedTimeSpan.Milliseconds;

        GL.ClearColor(new Color4(0, 0, 40, 0));
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        _pointShader.SetFloat("uTileSize", STWTerrain.TileSize);
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