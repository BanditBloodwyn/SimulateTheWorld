using System;
using System.Windows;
using System.Windows.Controls;
using OpenTK.Windowing.Common;
using OpenTK.Wpf;
using SimulateTheWorld.Rendering.Rendering;

namespace SimulateTheWorld.Rendering.Control
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

            var mainSettings = new GLWpfControlSettings { MajorVersion = 4, MinorVersion = 5, GraphicsProfile = ContextProfile.Compatability, GraphicsContextFlags = ContextFlags.Debug};
            GlControl.Start(mainSettings);
            _renderer = new OpenGLRenderer();
        }

        private void GlControl_OnRender(TimeSpan elapsedTimeSpan)
        {
            _renderer.OnRender(elapsedTimeSpan);
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
    }
}
