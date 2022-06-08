using System;
using System.Windows.Threading;
using SimulateTheWorld.Core.Logging;
using SimulateTheWorld.Graphics.Data.Components;
using SimulateTheWorld.Graphics.Data.Interfaces;
using SimulateTheWorld.World.Systems.Instances;

namespace SimulateTheWorld.Graphics.Rendering.Utilities;

public static class VertexUpdater
{
    public static void UpdateVertexData(IDrawable drawable, Dispatcher? dispatcher = null)
    {
        int updatedVerticesCount = 0;

        try
        {
            if (drawable is PointCloud pointCloud)
            {
                for (int i = 0; i < pointCloud.Vertices.Length; i++)
                {
                    TerrainTile tile = STWWorld.Instance.Terrain.Tiles[i];

                    pointCloud.Vertices[i].marked = tile.Marked ? 1.0f : 0.0f;

                    pointCloud.Vertices[i].tileType = (int)tile.TileType;
                    pointCloud.Vertices[i].vegetationType = (int)tile.VegetationType;

                    pointCloud.Vertices[i].height = tile.TerrainValues.Height;

                    pointCloud.Vertices[i].lifeStandard = tile.PopulationValues.LifeStandard;
                    pointCloud.Vertices[i].urbanization = tile.PopulationValues.Urbanization;
                    
                    pointCloud.Vertices[i].ressource_fossils.X = tile.TerrainValues.Coal;
                    pointCloud.Vertices[i].ressource_fossils.Y = tile.TerrainValues.Oil;
                    pointCloud.Vertices[i].ressource_fossils.Z = tile.TerrainValues.Gas;

                    pointCloud.Vertices[i].ressource_standardOres.Z = tile.TerrainValues.IronOre;
                    pointCloud.Vertices[i].ressource_preciousOres.X = tile.TerrainValues.GoldOre;
                    
                    pointCloud.Vertices[i].floraValues.X = tile.FloraValues.DeciduousTrees;
                    pointCloud.Vertices[i].floraValues.Y = tile.FloraValues.EvergreenTrees;
                    pointCloud.Vertices[i].floraValues.Z = tile.FloraValues.Vegetables;
                    pointCloud.Vertices[i].floraValues.W = tile.FloraValues.Fruits;

                    updatedVerticesCount++;
                }

                pointCloud.UpdateVertexData();
               
                Logger.Info(typeof(VertexUpdater), $"Updated vertices: {updatedVerticesCount}");
            }
        }
        catch (Exception e)
        {
            Logger.Error(typeof(VertexUpdater), "Vertex randomization failed", e.ToString());
            throw;
        }
    }
}