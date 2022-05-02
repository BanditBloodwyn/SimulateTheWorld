using System;
using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Data;
using SimulateTheWorld.Graphics.Data.Components;
using SimulateTheWorld.Graphics.Data.OpenGL;

namespace SimulateTheWorld.Graphics.Shapes.Primitives;

public class STWPoint
{
    public long ID { get; protected set; }
    public DataPoint? DataPoint { get; protected set; }
    public Transform Transform { get; set; }

    public STWPoint(long id)
    {
        ID = id;
        Transform = new Transform();
        DataPoint = new DataPoint(new Vertex(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f), Vector3.One, new Vector2(0.0f, 0.0f)));
    }

    public void Draw(ShaderProgram shaderProgram, Camera camera)
    {
        Matrix4 model = Matrix4.Identity;
        model *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Transform.AngleX));
        model *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Transform.AngleY));
        model *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Transform.AngleZ));
        model *= Matrix4.CreateTranslation(Transform.PositionX, Transform.PositionY, Transform.PositionZ);
        shaderProgram.SetMatrix4("model", model);

        DataPoint?.Draw(shaderProgram, camera);
    }
}