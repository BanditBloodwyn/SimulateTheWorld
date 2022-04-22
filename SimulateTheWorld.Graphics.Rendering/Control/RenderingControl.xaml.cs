using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Wpf;
using SimulateTheWorld.Graphics.Rendering.Rendering;
using SimulateTheWorld.Graphics.Rendering.Utilities;
using MouseWheelEventArgs = System.Windows.Input.MouseWheelEventArgs;

namespace SimulateTheWorld.Graphics.Rendering.Control
{
    /// <summary>
    /// Interaktionslogik für RenderingControl.xaml
    /// </summary>
    public sealed partial class RenderingControl : UserControl
    {
        private readonly OpenGLRenderer _renderer;
        private readonly InputController _inputController;

        public RenderingControl()
        {
            InitializeComponent();

            var mainSettings = new GLWpfControlSettings { MajorVersion = 4, MinorVersion = 5, GraphicsProfile = ContextProfile.Core, GraphicsContextFlags = ContextFlags.Default};
            GlControl.Start(mainSettings);

            _renderer = new OpenGLRenderer();
            _inputController = new InputController();
        }

        private void GlControl_OnRender(TimeSpan elapsedTimeSpan)
        {
            _renderer.OnRender(elapsedTimeSpan, GlControl.ActualWidth, GlControl.ActualHeight);
        }

        private void GlControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            _renderer.OnLoaded();
        }

        private void GlControl_OnUnloaded(object sender, RoutedEventArgs e)
        {
            _renderer.OnUnLoaded();
        }

        private void GlControl_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            _renderer.UpdateViewPort(GlControl.ActualWidth, GlControl.ActualHeight);
        }

        private void GlControl_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            _renderer.Camera.Translate(new Vector3(0.0f, 0.0f, e.Delta));
        }

        private void GlControl_OnMouseMove(object sender, MouseEventArgs e)
        {
            _inputController.NewMousePosition = e.GetPosition(this);
            Vector2 delta = _inputController.GetDelta();

            if (e.RightButton == MouseButtonState.Pressed)
                _renderer.Camera.Translate(new Vector3(-delta.X, -delta.Y, 0.0f));

            if (e.MiddleButton == MouseButtonState.Pressed)
                ;
                //_renderer.Camera.Rotate(new Vector3(delta.X, delta.Y, 0.0f));

            _inputController.OldMousePosition = e.GetPosition(this);
        }
    }
}
