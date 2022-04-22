using System.Windows;
using OpenTK.Mathematics;

namespace SimulateTheWorld.Graphics.Rendering.Utilities;

public class InputController
{
    public Point OldMousePosition { get; set; }
    public Point NewMousePosition { get; set; }

    public InputController()
    {
        OldMousePosition = new Point(0, 0);
        NewMousePosition = new Point(0, 0);
    }

    public Vector2 GetDelta()
    {
        double deltaX = (OldMousePosition.X - NewMousePosition.X);
        double deltaY = (OldMousePosition.Y - NewMousePosition.Y);

        return new Vector2((float)deltaX, (float)deltaY);
    }
}