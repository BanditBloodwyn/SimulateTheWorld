using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Data.OpenGL;

namespace SimulateTheWorld.Graphics.Data;

public class Camera
{
    public Vector3 Position { get; set; }
    public Vector3 Rotation { get; set; }
    public Vector3 Up { get; set; }

    public float AspectRatio { get; set; }
    public float Speed { get; set; }
    public float Sensitivity { get; set; }

    public Camera(Vector3 position)
    {
        Position = position;
        AspectRatio = 1.0f;
        Sensitivity = 0.01f;

        Rotation = new Vector3(0, 0, 1.0f);
        Up = new Vector3(0, 1.0f, 0);
    }

    public void Matrix(float fovDeg, float nearPlane, float farPlane, ShaderProgram shaderProgram)
    {
        Matrix4 view = Matrix4.Identity;
        Matrix4 projection = Matrix4.Identity;

        view *= Matrix4.LookAt(Position, Position + Rotation, Up);
        projection *= Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(fovDeg), AspectRatio, nearPlane, farPlane);
        
        shaderProgram.SetMatrix4("view", view);
        shaderProgram.SetMatrix4("projection", projection);
    }

    public void Inputs()
    {
    }

    public void Translate(Vector3 delta)
    {
        Vector3 position = Position;
        position.X += delta.X * Sensitivity;
        position.Y += delta.Y * Sensitivity;
        position.Z += delta.Z * Sensitivity;
        Position = position;
    }

    public void Rotate(Vector3 delta)
    {
        
    }
}