using System;
using SimulateTheWorld.Graphics.Components;

namespace SimulateTheWorld.Graphics.Shapes
{
    public class STWShape
    {
        public float[]? Vertices { get; protected set; }
        public int[]? Indices { get; protected set; }
        public float[]? Normals { get; protected set; }

        public Transform Transform { get; set; }
        public Material Material { get; set; }

        protected STWShape()
        {
            Transform = new Transform();
            Material = new Material();
        }
    }
}
