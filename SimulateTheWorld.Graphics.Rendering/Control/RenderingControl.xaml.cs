using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Wpf;
using SimulateTheWorld.Graphics.Rendering.Container;
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
        private readonly RayCaster rayCaster;

        public event Action<DebugInformation>? OnDebugInfoChanged;
        private int _millisecs;

        private DebugInformation DebugInformation { get; }

        public RenderingControl()
        {
            InitializeComponent();

            GLWpfControlSettings mainSettings = new GLWpfControlSettings { MajorVersion = 4, MinorVersion = 5, GraphicsProfile = ContextProfile.Core, GraphicsContextFlags = ContextFlags.Default, RenderContinuously = true};
            GlControl.Start(mainSettings);

            _renderer = new OpenGLRenderer();

            _inputController = new InputController();
            rayCaster = new RayCaster(_renderer.Camera);

            DebugInformation = new DebugInformation();
        }

        public void OnUpdateVertexData()
        {
            _renderer.OnUpdateVertexData(Dispatcher);
        }

        private void GlControl_OnRender(TimeSpan elapsedTimeSpan)
        {
            _renderer.OnRender(elapsedTimeSpan);
            rayCaster.Update(_inputController.NewMousePosition, GlControl.ActualWidth, GlControl.ActualHeight);

            _millisecs += elapsedTimeSpan.Milliseconds;
            if (_millisecs >= FPSCounter.Interval)
            {
                DebugInformation.FPS = _renderer.FpsCounter.FPS;
                DebugInformation.Milliseconds = _renderer.FpsCounter.Milliseconds;
                _millisecs = 0;
            }
            DebugInformation.CameraPosition = _renderer.Camera.Transform.Position;
            DebugInformation.RayCastDirection = rayCaster.CurrentRay;
            DebugInformation.CurrentTileCoordinates = rayCaster.CurrentTileCoordinates;
            OnDebugInfoChanged?.Invoke(DebugInformation);
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
            _renderer.Camera.Translate(new Vector3(0.0f, -e.Delta, 0.0f));
        }

        private void GlControl_OnMouseMove(object sender, MouseEventArgs e)
        {
            _inputController.NewMousePosition = e.GetPosition(this);
            Vector2 delta = _inputController.GetDelta();

            if (e.RightButton == MouseButtonState.Pressed)
                _renderer.Camera.Translate(new Vector3(delta.X, 0.0f, delta.Y));

            if (e.MiddleButton == MouseButtonState.Pressed)
                _renderer.Camera.Rotate(new Vector3(0, delta.Y, 0.0f));

            _inputController.OldMousePosition = e.GetPosition(this);
        }
    }
}
