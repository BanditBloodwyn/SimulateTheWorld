using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Data.Components;
using SimulateTheWorld.Graphics.Data.OpenGL;

namespace SimulateTheWorld.Graphics.Data;

public class Camera
{
    private static Camera? _instance;

    private readonly Vector3 _up = Vector3.UnitY;

    public static Camera Instance
    {
        get { return _instance ??= new Camera(); }
    }

    public Transform Transform { get; set; } = new Transform();

    public Matrix4 ProjectionMatrix { get; set; }
    public Matrix4 ViewMatrix { get; set; }

    public Vector3 Front { get; set; } = new(0, -2, -1);

    public float AspectRatio { get; set; }
    public float Speed { get; set; }
    public float Sensitivity { get; set; }
    
    private Camera()
    {
        AspectRatio = 1.0f;
        Sensitivity = 0.001f;
        Speed = 0.003f;
    }

    public void Matrix(float fovDeg, float nearPlane, float farPlane, ShaderProgram shaderProgram)
    {
        ViewMatrix = Matrix4.Identity;
        ProjectionMatrix = Matrix4.Identity;

        ViewMatrix *= Matrix4.LookAt(Transform.Position, Transform.Position + Front, _up);
        ProjectionMatrix *= Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(fovDeg), AspectRatio, nearPlane, farPlane);
        
        shaderProgram.SetMatrix4("uView", ViewMatrix);
        shaderProgram.SetMatrix4("uProjection", ProjectionMatrix);
    }

    public void Translate(Vector3 delta)
    {
        Vector3 position = Transform.Position;
        position.X += delta.X * Speed;
        position.Y += delta.Y * Speed;
        position.Z += delta.Z * Speed;

        if(position.Y <= 0) 
            return;

        Transform.Position = position;

        Update();
    }

    public void Rotate(Vector3 delta)
    {
        Vector3 rotation = Front;
        rotation.X += delta.X * Sensitivity;
        rotation.Y += delta.Y * Sensitivity;
        rotation.Z += delta.Z * Sensitivity;
        Front = rotation;
    }

    private void Update()
    {
        Speed = Transform.PositionY / 1000;
    }

}