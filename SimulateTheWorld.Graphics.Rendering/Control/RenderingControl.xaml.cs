using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using OpenTK.Windowing.Common;
using OpenTK.Wpf;
using SimulateTheWorld.Graphics.Rendering.Rendering;
using MouseWheelEventArgs = System.Windows.Input.MouseWheelEventArgs;

namespace SimulateTheWorld.Graphics.Rendering.Control
{
    /// <summary>
    /// Interaktionslogik für RenderingControl.xaml
    /// </summary>
    public sealed partial class RenderingControl : UserControl
    {
        private readonly OpenGLRenderer _renderer;

        public RenderingControl()
        {
            InitializeComponent();

            var mainSettings = new GLWpfControlSettings { MajorVersion = 4, MinorVersion = 5, GraphicsProfile = ContextProfile.Core, GraphicsContextFlags = ContextFlags.Debug, RenderContinuously = true};
            GlControl.Start(mainSettings);

            _renderer = new OpenGLRenderer();
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

        }

        private void GlControl_OnMouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
