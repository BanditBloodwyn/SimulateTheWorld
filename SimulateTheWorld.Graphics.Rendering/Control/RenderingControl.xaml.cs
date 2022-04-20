using System;
using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        private readonly MouseHandler mouseHandler;

        public RenderingControl()
        {
            InitializeComponent();

            var mainSettings = new GLWpfControlSettings { MajorVersion = 4, MinorVersion = 5, GraphicsProfile = ContextProfile.Core, GraphicsContextFlags = ContextFlags.Debug};
            GlControl.Start(mainSettings);

            _renderer = new OpenGLRenderer();
            mouseHandler = new MouseHandler();
        }

        private void GlControl_OnRender(TimeSpan elapsedTimeSpan)
        {
            _renderer.OnRender();
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
            _renderer.Camera.Position += _renderer.Camera.Front * e.Delta * 0.005f;
        }

        private void GlControl_OnMouseMove(object sender, MouseEventArgs e)
        {
            mouseHandler.NewPosition = e.GetPosition(this);
            Vector2 delta = mouseHandler.GetDelta();

            if (e.RightButton == MouseButtonState.Pressed)
            {
                _renderer.Camera.Position -= _renderer.Camera.Up * delta.Y / 20;
                _renderer.Camera.Position += _renderer.Camera.Right * delta.X / 20;
            }
            if (e.MiddleButton == MouseButtonState.Pressed)
            {
                _renderer.Camera.Pitch -= delta.Y ;
            }

            mouseHandler.OldPosition= e.GetPosition(this);
        }
    }
}
