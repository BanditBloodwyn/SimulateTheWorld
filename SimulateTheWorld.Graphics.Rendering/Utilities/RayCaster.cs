using System.Windows;
using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Data;

namespace SimulateTheWorld.Graphics.Rendering.Utilities;

public class RayCaster
{
    private readonly Camera camera;

    public Vector3 CurrentRay { get; private set; }

    public RayCaster(Camera camera)
    {
        this.camera = camera;
    }

    public Vector3 GetClickedTileCoordinates()
    {
        return Vector3.Zero;
    }

    public void Update(Point mousePosition, double screenWidth, double screenHeight)
    {
        CurrentRay = CalculateMouseRay(mousePosition, screenWidth, screenHeight);
    }

    private Vector3 CalculateMouseRay(Point mousePosition, double screenWidth, double screenHeight)
    {
        Vector2 normalizedDeviceCoords = GetNormalizedDeviceCoords(mousePosition, screenWidth, screenHeight);
        Vector4 clipCoords = GetClipCoords(normalizedDeviceCoords);
        Vector4 eyeCoords = GetEyeCoords(clipCoords);
        Vector3 worldCoords = GetWorldCoords(eyeCoords);
        return worldCoords;
    }

    private Vector2 GetNormalizedDeviceCoords(Point mousePosition, double screenWidth, double screenHeight)
    {
        float x = 2 * (float)mousePosition.X / (float)screenWidth - 1f;
        float y = 2 * (float)mousePosition.Y / (float)screenHeight - 1f;
        return new Vector2(x, y);
    }

    private Vector4 GetClipCoords(Vector2 normalizedDeviceCoords)
    {
        return new Vector4(normalizedDeviceCoords.X, normalizedDeviceCoords.Y, -1, 1);
    }

    private Vector4 GetEyeCoords(Vector4 clipCoords)
    {
        Matrix4 invertedProjectionMatrix = Matrix4.Invert(camera.ProjectionMatrix);
        Vector4 eyeCoords = invertedProjectionMatrix * clipCoords;
        return new Vector4(eyeCoords.X, eyeCoords.Y, -1, 0);
    }

    private Vector3 GetWorldCoords(Vector4 eyeCoords)
    {
        Matrix4 invertedViewMatrix = Matrix4.Invert(camera.ViewMatrix);
        Vector4 rayWorld = invertedViewMatrix * eyeCoords;
        Vector3 mouseRay = new Vector3(rayWorld.X, rayWorld.Y, rayWorld.Z);
        mouseRay.Normalize();
        return mouseRay;
    }
}