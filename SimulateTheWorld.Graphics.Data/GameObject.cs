using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Data.Components;
using SimulateTheWorld.Graphics.Data.Interfaces;
using SimulateTheWorld.Graphics.Data.OpenGL;

namespace SimulateTheWorld.Graphics.Data;

public class GameObject : IDrawable
{
    public long ID { get; }
    public Transform Transform { get; }
    public IDrawable? Drawable { get; set; }

    public GameObject(long id)
    {
        ID = id;
        Transform = new Transform();
    }

    public void Draw(ShaderProgram shaderProgram, Camera camera)
    {
        Matrix4 model = Matrix4.Identity;
        model *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Transform.AngleX));
        model *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Transform.AngleY));
        model *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Transform.AngleZ));
        model *= Matrix4.CreateTranslation(Transform.PositionX, Transform.PositionY, Transform.PositionZ);
        shaderProgram.SetMatrix4("uModel", model);

        Drawable?.Draw(shaderProgram, camera);
    }
}