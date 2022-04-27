using OpenTK.Mathematics;

namespace SimulateTheWorld.Graphics.Data.Components;

public class Transform
{
    private float angleXRadian;
    private float angleYRadian;
    private float angleZRadian;

    public float AngleX
    {
        get => MathHelper.RadiansToDegrees(angleXRadian);
        set => angleXRadian = MathHelper.DegreesToRadians(value);
    }
    public float AngleY
    {
        get => MathHelper.RadiansToDegrees(angleYRadian);
        set => angleYRadian = MathHelper.DegreesToRadians(value);
    }
    public float AngleZ
    {
        get => MathHelper.RadiansToDegrees(angleZRadian);
        set => angleZRadian = MathHelper.DegreesToRadians(value);
    }

    public Vector3 Position
    {
        get => new(PositionX, PositionY, PositionZ);
        set
        {
            PositionX = value.X;
            PositionY = value.Y;
            PositionZ = value.Z;
        }
    }
    public float PositionX { get; protected set; }
    public float PositionY { get; protected set; }
    public float PositionZ { get; protected set; }

    public Transform()
    {
        ResetRotation();
        ResetTranslation();
    }

    public void Rotate(float deltaX, float deltaY, float deltaZ)
    {
        AngleX += deltaX;
        AngleY += deltaY;
        AngleZ += deltaZ;
    }

    public void Translate(float deltaX, float deltaY, float deltaZ)
    {
        PositionX += deltaX;
        PositionY += deltaY;
        PositionZ += deltaZ;
    }

    public void ResetRotation()
    {
        AngleX = 0.0f;
        AngleY = 0.0f;
        AngleZ = 0.0f;
    }

    public void ResetTranslation()
    {
        PositionX = 0.0f;
        PositionY = 0.0f;
        PositionZ = 0.0f;
    }
}