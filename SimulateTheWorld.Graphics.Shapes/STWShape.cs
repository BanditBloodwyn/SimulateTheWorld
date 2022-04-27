using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Data;
using SimulateTheWorld.Graphics.Data.Components;
using SimulateTheWorld.Graphics.Data.OpenGL;

namespace SimulateTheWorld.Graphics.Shapes;

public class STWShape
{
    public long ID { get; protected set; }
    public Mesh? Mesh { get; protected set; }
    public Transform Transform { get; set; }

    protected STWShape(long id)
    {
        ID = id;
        Transform = new Transform();
        Mesh = null;
    }

    public virtual void Draw(ShaderProgram shaderProgram, Camera camera)
    {
        Matrix4 model = Matrix4.Identity;
        model *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Transform.AngleX));
        model *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Transform.AngleY));
        model *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Transform.AngleZ));
        model *= Matrix4.CreateTranslation(Transform.PositionX, Transform.PositionY, Transform.PositionZ);
        shaderProgram.SetMatrix4("model", model);
    }
}