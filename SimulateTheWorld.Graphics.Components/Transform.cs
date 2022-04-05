namespace SimulateTheWorld.Graphics.Components;

public class Transform
{
    public float AngleX { get; protected set; }
    public float AngleY { get; protected set; }
    public float AngleZ { get; protected set; }

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