using System.Windows;
using OpenTK.Wpf;
using SimulateTheWorld.Rendering.Rendering;

namespace SimulateTheWorld.Rendering.Model;

public class RenderingControlViewModel
{
    private readonly OpenGLRenderer _renderer;

    public GLWpfControl GLControl { get; }

    public RenderingControlViewModel()
    {
        _renderer = new OpenGLRenderer();

        GLControl = new GLWpfControl();

        InitGLControl();
    }

    private void InitGLControl()
    {
        GLControl.Render += _renderer.Render;
        GLControl.SizeChanged += OnSizeChanged;

        GLWpfControlSettings settings = new GLWpfControlSettings
        {
            MajorVersion = 3,
            MinorVersion = 3
        };
        GLControl.Start(settings);
    }

    private void OnSizeChanged(object sender, SizeChangedEventArgs sizeChangedEventArgs)
    {
        UpdateViewPort(GLControl.Width, GLControl.Height);
    }

    private void UpdateViewPort(double width, double height)
    {

    }
}