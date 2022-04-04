using System.Numerics;
using System.Windows;

namespace SimulateTheWorld.Rendering.Handler;

public class MouseHandler
{
    public Point OldPosition { get; set; }
    public Point NewPosition { get; set; }

    public float Sensitivity { get; set; }

    public MouseHandler()
    {
        OldPosition = new Point(0, 0);
        NewPosition = new Point(0, 0);
        Sensitivity = 0.1f;
    }

    public Vector2 GetDelta()
    {
        double deltaX = (OldPosition.X - NewPosition.X) * Sensitivity;
        double deltaY = (OldPosition.Y - NewPosition.Y) * Sensitivity;

        return new Vector2((float)deltaX, (float)deltaY);
    }
}