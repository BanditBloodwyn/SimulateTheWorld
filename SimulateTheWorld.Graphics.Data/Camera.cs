﻿using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Data.Components;
using SimulateTheWorld.Graphics.Data.OpenGL;

namespace SimulateTheWorld.Graphics.Data;

public class Camera
{
    private Vector3 _up = Vector3.UnitY;

    public Transform Transform { get; set; } = new Transform();

    public Vector3 Front { get; set; } = -Vector3.UnitZ;

    public float AspectRatio { get; set; }
    public float Speed { get; set; }
    public float Sensitivity { get; set; }
    

    public Camera(Vector3 position)
    {
        Transform.Position = position;
        AspectRatio = 1.0f;
        Sensitivity = 0.001f;
        Speed = 0.001f;

    }

    public void Matrix(float fovDeg, float nearPlane, float farPlane, ShaderProgram shaderProgram)
    {
        Matrix4 view = Matrix4.Identity;
        Matrix4 projection = Matrix4.Identity;

        view *= Matrix4.LookAt(Transform.Position, Transform.Position + Front, _up);
        projection *= Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(fovDeg), AspectRatio, nearPlane, farPlane);
        
        shaderProgram.SetMatrix4("view", view);
        shaderProgram.SetMatrix4("projection", projection);
    }

    public void Translate(Vector3 delta)
    {
        Vector3 position = Transform.Position;
        position.X += delta.X * Speed;
        position.Y += delta.Y * Speed;
        position.Z += delta.Z * Speed;
        Transform.Position = position;
    }

    public void Rotate(Vector3 delta)
    {
        Vector3 rotation = Front;
        rotation.X += delta.X * Sensitivity;
        rotation.Y += delta.Y * Sensitivity;
        rotation.Z += delta.Z * Sensitivity;
        Front = rotation;
    }
}