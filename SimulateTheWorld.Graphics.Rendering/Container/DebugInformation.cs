using OpenTK.Mathematics;

namespace SimulateTheWorld.Graphics.Rendering.Container;

public class DebugInformation
{
    public Vector3 CameraPosition { get; set; }
   
    public Vector3 RayCastDirection { get; set; }
    public Vector3? CurrentTileCoordinates { get; set; }
    
    public double FPS { get; set; }
    public double Milliseconds { get; set; }
}