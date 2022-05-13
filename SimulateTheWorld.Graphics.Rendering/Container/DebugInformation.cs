using OpenTK.Mathematics;

namespace SimulateTheWorld.Graphics.Rendering.Container;

public class DebugInformation
{
    public Vector3 CameraPosition { private get; set; }
    public string CameraPositionString => $"Camera Pos: {CameraPosition.X:0.00}, {CameraPosition.Y:0.00}, {CameraPosition.Z:0.00}";

    public Vector3 RayCastDirection { private get; set; }
    public string RayCastDirectionString => $"Raycast direction: {RayCastDirection.X:0.000}, {RayCastDirection.Y:0.000}, {RayCastDirection.Z:0.000}";

    public Vector3? CurrentTileCoordinates { private get; set; }
    public string CurrentTileCoordinatesString => CurrentTileCoordinates != null 
        ? $"Current Tile Coords: {CurrentTileCoordinates.Value.X:0.00}, {CurrentTileCoordinates.Value.Y:0.00}, {CurrentTileCoordinates.Value.Z:0.00}" 
        : string.Empty;
    public int? CurrentTileID { get; set; }

    public double FPS { get; set; }
    public double Milliseconds { get; set; }
}