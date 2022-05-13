using System;
using System.Windows;
using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Data;
using SimulateTheWorld.World.Data.Instances;

namespace SimulateTheWorld.Graphics.Rendering.Utilities;

public class RayCaster
{
    private const int RECURSION_COUNT = 200;
    private const float RAY_RANGE = 600;

    private readonly Camera camera;

    public Vector3 CurrentRay { get; private set; }
    public Vector3? CurrentTileCoordinates { get; private set; }
    public int? CurrentTileID => CurrentTileCoordinates != null 
        ? (int)Math.Round(Math.Abs(CurrentTileCoordinates.Value.X / STWTerrain.TileSize), 0) + (int)Math.Round(Math.Abs(CurrentTileCoordinates.Value.Z / STWTerrain.TileSize), 0) * STWTerrain.TerrainSize 
        : null;

    public RayCaster(Camera camera)
    {
        this.camera = camera;
    }

    public void Update(Point mousePosition, double screenWidth, double screenHeight)
    {
        CurrentRay = CalculateMouseRay(mousePosition, screenWidth, screenHeight);

        CurrentTileCoordinates = IntersectionInRange(0, RAY_RANGE, CurrentRay) 
            ? BinarySearch(0, 0, RAY_RANGE, CurrentRay) 
            : null;
    }

    private Vector3? BinarySearch(int count, float start, float finish, Vector3 ray)
    {
        float half = start + (finish - start) / 2f;
        if (count >= RECURSION_COUNT)
            return GetPointOnRay(ray, half);
        
        return IntersectionInRange(start, half, ray) 
            ? BinarySearch(count + 1, start, half, ray) 
            : BinarySearch(count + 1, half, finish, ray);
    }

    private bool IntersectionInRange(float start, float finish, Vector3 ray)
    {
        Vector3 startPoint = GetPointOnRay(ray, start);
        Vector3 endPoint = GetPointOnRay(ray, finish);
        return startPoint.Y > 0 && endPoint.Y < 0;
    }

    private Vector3 GetPointOnRay(Vector3 ray, float distance)
    {
        Vector3 camPos = camera.Transform.Position;
        Vector3 start = new Vector3(camPos.X, camPos.Y, camPos.Z);
        Vector3 scaledRay = new Vector3(ray.X * distance, ray.Y * distance, ray.Z * distance);
        return Vector3.Add(start, scaledRay);
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
        Vector3 mouseRay = new Vector3(rayWorld.X, -rayWorld.Y, rayWorld.Z);
        mouseRay.Normalize();
        return mouseRay;
    }
}