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
using SimulateTheWorld.World.Systems.Instances;
using MouseWheelEventArgs = System.Windows.Input.MouseWheelEventArgs;

namespace SimulateTheWorld.Graphics.Rendering.Control
{
    /// <summary>
    /// Interaktionslogik für RenderingControl.xaml
    /// </summary>
    public sealed partial class RenderingControl : UserControl
    {
        private OpenGLRenderer? _renderer;
        private InputController? _inputController;
        private TileFinder? _tileFinder;

        private bool _loaded;

        private int _millisecs;

        public event Action<DebugInformation>? OnDebugInfoChanged;
        public event Action<int>? OnTileSelected;

        private DebugInformation DebugInformation { get; }

        public RenderingControl()
        {
            InitializeComponent();

            GLWpfControlSettings mainSettings = new GLWpfControlSettings
            {
                MajorVersion = 4, MinorVersion = 5, GraphicsProfile = ContextProfile.Core,
                GraphicsContextFlags = ContextFlags.Default, RenderContinuously = true
            };
            GlControl.Start(mainSettings);

            DebugInformation = new DebugInformation();

            STWWorld.Instance.OnUpdateVertexData += OnUpdateVertexData;
        }

        public void Load()
        {
            _renderer = new OpenGLRenderer();
            _renderer.OnLoaded();

            _inputController = new InputController();
            
            if (_renderer.Camera != null) 
                _tileFinder = new TileFinder(_renderer.Camera);
            
            _loaded = true;
        }

        public void OnUpdateVertexData()
        {
            _renderer?.OnUpdateVertexData(Dispatcher);
            Dispatcher.Invoke(() =>
            {
                if (_tileFinder?.CurrentTileID != null) 
                    OnTileSelected?.Invoke(_tileFinder.CurrentTileID.Value);
            });
        }

        private void GlControl_OnRender(TimeSpan elapsedTimeSpan)
        {
            if (!_loaded || _renderer?.FpsCounter == null || _renderer?.Camera == null || _tileFinder == null || _inputController == null)
                return;

            _renderer.OnRender(elapsedTimeSpan);
            _tileFinder.Update(_inputController.NewMousePosition, GlControl.ActualWidth, GlControl.ActualHeight);

            _millisecs += elapsedTimeSpan.Milliseconds;
            if (_millisecs >= FPSCounter.Interval)
            {
                DebugInformation.FPS = _renderer.FpsCounter.FPS;
                DebugInformation.Milliseconds = _renderer.FpsCounter.Milliseconds;
                _millisecs = 0;
            }

            DebugInformation.CameraPosition = _renderer.Camera.Transform.Position;
            DebugInformation.RayCastDirection = _tileFinder.CurrentRay;
            DebugInformation.CurrentTileCoordinates = _tileFinder.CurrentTileCoordinates;
            DebugInformation.CurrentTileID = _tileFinder.CurrentTileID;
            OnDebugInfoChanged?.Invoke(DebugInformation);
        }

        private void GlControl_OnUnloaded(object sender, RoutedEventArgs e)
        {
            _renderer?.OnUnLoaded();
        }

        private void GlControl_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!_loaded)
                return;

            _renderer?.UpdateViewPort(GlControl.ActualWidth, GlControl.ActualHeight);
        }

        private void GlControl_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            _renderer?.Camera?.Translate(new Vector3(0.0f, -e.Delta, 0.0f));
        }

        private void GlControl_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (!_loaded || _renderer == null || _tileFinder == null || _inputController == null)
                return;

            _inputController.NewMousePosition = e.GetPosition(this);
            Vector2 delta = _inputController.GetDelta();

            if (e.RightButton == MouseButtonState.Pressed)
                _renderer.Camera?.Translate(new Vector3(delta.X, 0.0f, delta.Y));

            if (e.MiddleButton == MouseButtonState.Pressed)
                _renderer.Camera?.Rotate(new Vector3(0, delta.Y, 0.0f));

            _inputController.OldMousePosition = e.GetPosition(this);
        }

        private void GlControl_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!_loaded || _renderer == null || _tileFinder == null || _inputController == null)
                return;
            
            if (e.ChangedButton != MouseButton.Left)
                return;

            if (!_tileFinder.CurrentTileID.HasValue)
                return;

            STWWorld.Instance.Terrain.MarkTile(_tileFinder.CurrentTileID.Value);
            OnTileSelected?.Invoke(_tileFinder.CurrentTileID.Value);
        }
    }
}
