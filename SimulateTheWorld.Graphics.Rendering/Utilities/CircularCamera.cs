using System;
using OpenTK.Mathematics;

namespace SimulateTheWorld.Graphics.Rendering.Utilities;

public class CircularCamera
{
    private float fovRadian;
    private float pitchRadian;
    private float yawRadian;

    private Vector3 _front = -Vector3.UnitZ;

    public Vector3 Position { get; set; }
    public float AspectRatio { private get; set; }

    public Vector3 Front => _front; // Vector pointing forward from the camera
    public Vector3 Up { get; private set; } = Vector3.UnitY; // Vector pointing upwards from the camera
    public Vector3 Right { get; private set; } = Vector3.UnitX; // Vector pointing to the right from the camera

    public float Pitch
    {
        get => MathHelper.RadiansToDegrees(pitchRadian);
        set
        {
            float angle = MathHelper.Clamp(value, -89f, 89f);
            pitchRadian = MathHelper.DegreesToRadians(angle);
            UpdateVectors();
        }
    }

    public float Yaw
    {
        get => MathHelper.RadiansToDegrees(yawRadian);
        set
        {
            yawRadian = MathHelper.DegreesToRadians(value);
            UpdateVectors();
        }
    }

    public float Fov
    {
        get => MathHelper.RadiansToDegrees(fovRadian);
        set
        {
            float angle = MathHelper.Clamp(value, 1f, 90f);
            fovRadian = MathHelper.DegreesToRadians(angle);
        }
    }

    public CircularCamera(Vector3 position)
    {
        Position = position;
        Pitch = 0;
        Yaw = -90;

        AspectRatio = 1;
        Fov = 45.0f;
    }

    public Matrix4 GetViewMatrix()
    {
        Matrix4 view = Matrix4.LookAt(Position, Position + _front, Up);
        return view;
    }

    public Matrix4 GetProjectionMatrix()
    {
        return Matrix4.CreatePerspectiveFieldOfView(fovRadian, AspectRatio, 0.01f, 1000f);
    }

    private void UpdateVectors()
    {
        _front.X = (float)Math.Cos(pitchRadian) * (float)Math.Cos(yawRadian);
        _front.Y = (float)Math.Sin(pitchRadian);
        _front.Z = (float)Math.Cos(pitchRadian) * (float)Math.Sin(yawRadian);
        _front = Vector3.Normalize(_front);

        Right = Vector3.Normalize(Vector3.Cross(_front, Vector3.UnitY));
        Up = Vector3.Normalize(Vector3.Cross(Right, _front));
    }
}