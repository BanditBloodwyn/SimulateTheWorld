using OpenTK.Mathematics;

namespace SimulateTheWorld.Graphics.Rendering.Utilities;

public class DebugInformation
{
    public Vector3 CameraPosition { get; set; }
    public Vector3 CameraRotation { get; set; }
    public double FPS { get; set; }
    public double Milliseconds { get; set; }
}