using System.Drawing;
using OpenTK.Mathematics;
using SimulateTheWorld.Core.Logging;
using SimulateTheWorld.Graphics.Data.OpenGL;
using SimulateTheWorld.Graphics.Resources.Rendering;
using SimulateTheWorld.GUI.Models.SidePanel.Panels.MapFilters;
using SimulateTheWorld.World.Data.Data;

namespace SimulateTheWorld.Graphics.Rendering.Rendering;

public static class ShaderPreparer
{
    public static void PrepareShader(ShaderProgram shader)
    {
        shader.SetFloat("uTileSize", WorldProperties.Instance.TileFillSize);
        shader.SetVector4("uMarkedTileColor", new Vector4(MapColors.MarkedTileColor.R, MapColors.MarkedTileColor.G, MapColors.MarkedTileColor.B, MapColors.MarkedTileColor.A));
    }

    public static void SetFilterColors(ShaderProgram shader)
    {
        if (MapFiltersModel.Instance.ActiveFilter == null)
            return;

        if (!MapFiltersModel.Instance.ActiveFilter.Active)
            return;

        Color[] colors = MapColors.GetColorsByFilterType(MapFiltersModel.Instance.ActiveFilter.Type);
        Vector4 filterColorZero = new Vector4(colors[0].R / 255f, colors[0].G / 255f, colors[0].B / 255f, 1);
        Vector4 filterColorHundred = new Vector4(colors[1].R / 255f, colors[1].G / 255f, colors[1].B / 255f, 1);

        Logger.Info(typeof(ShaderPreparer), $"Changing map filter",
            $"New map filter: {MapFiltersModel.Instance.ActiveFilter.DisplayName}, Colors: {filterColorZero}, {filterColorHundred}");

        shader.SetVector4("uFilterColorZero", filterColorZero);
        shader.SetVector4("uFilterColorHundred", filterColorHundred);
        shader.SetInt("uFilterMode", (int)MapFiltersModel.Instance.ActiveFilter.Type);
    }
}