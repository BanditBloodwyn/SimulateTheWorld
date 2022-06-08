using System;
using System.Linq;
using System.Windows.Input;
using System.Windows.Threading;
using OpenTK.Mathematics;
using SimulateTheWorld.Core.GUI.MVVM;
using SimulateTheWorld.Core.GUI.MVVM.Mediator;
using SimulateTheWorld.Graphics.Data;
using SimulateTheWorld.Graphics.Rendering.Container;
using SimulateTheWorld.Graphics.Rendering.Rendering;
using SimulateTheWorld.Graphics.Rendering.Utilities;
using SimulateTheWorld.GUI.ViewModels.Commands.RenderingControl;
using SimulateTheWorld.GUI.ViewModels.Mediation.Mediators;
using SimulateTheWorld.GUI.ViewModels.Mediation.Messages;
using SimulateTheWorld.World.Systems.Instances;

namespace SimulateTheWorld.Graphics.Rendering.Control;

public class RenderingControlViewModel : ObservableObject, ISubscriber<IMessage>
{
    private readonly OpenGLRenderer _renderer;
    private readonly InputController _inputController;
    private readonly TileFinder _tileFinder;
    private readonly DebugInformation _debugInformation;

    private Dispatcher _dispatcher = null!;
    
    private bool _loaded;
    private bool _dragging;
    private int _millisecs;

    public event Action<int>? OnTileSelected;
    public event Action<DebugInformation>? OnDebugInfoChanged;

    private OpenTileContextMenuCommand OpenTileContextMenuCommand { get; }

    public RenderingControlViewModel()
    {
        CameraMoverMediator.Instance.Subscribe(this);
        
        OpenTileContextMenuCommand = new OpenTileContextMenuCommand();

        _renderer = new OpenGLRenderer();
        _inputController = new InputController();
        _tileFinder = new TileFinder(Camera.Instance);
        _debugInformation = new DebugInformation();
    }

    public void SetDispatcher(Dispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    public void OnUpdateVertexData()
    {
        _renderer.OnUpdateVertexData(_dispatcher);
        _dispatcher.Invoke(() =>
        {
            if (STWWorld.Instance.Terrain.TileMarker.MarkedIDs.Count > 0)
                OnTileSelected?.Invoke(STWWorld.Instance.Terrain.TileMarker.MarkedIDs.First());
        });
    }

    public void OnLoad()
    {
        _renderer.OnLoaded();
        _loaded = true;
    }

    public static void OnUnload()
    {
        OpenGLRenderer.OnUnLoaded();
    }

    public void OnSizeChanged(double width, double height)
    {
        if (!_loaded)
            return;

        OpenGLRenderer.UpdateViewPort(width, height);
    }

    public static void OnMouseWheel(int delta)
    {
        Camera.Instance.Translate(new Vector3(0.0f, -delta, 0.0f));
    }

    public void OnMouseMove(MouseEventArgs args, RenderingControl renderingControl)
    {
        if (!_loaded)
            return;

        _inputController.NewMousePosition = args.GetPosition(renderingControl);
        Vector2 delta = _inputController.GetDelta();

        if (args.RightButton == MouseButtonState.Pressed)
        {
            _dragging = true;
            Camera.Instance.Translate(new Vector3(delta.X, 0.0f, delta.Y));
        }
        if (args.RightButton == MouseButtonState.Released)
            _dragging = false;

        if (args.MiddleButton == MouseButtonState.Pressed)
            Camera.Instance.Rotate(new Vector3(0, delta.Y, 0.0f));

        _inputController.OldMousePosition = args.GetPosition(renderingControl);
    }

    public void OnMouseUp(MouseButton changedButton)
    {
        if (!_loaded)
            return;

        if (changedButton == MouseButton.Left)
            MarkTile();

        if (changedButton == MouseButton.Right && !_dragging)
        {
            MarkTile();
            OpenTileContextMenuCommand.Execute(this);
        }
    }

    private void MarkTile()
    {
        if (!_tileFinder.CurrentTileID.HasValue)
            return;

        STWWorld.Instance.Terrain.TileMarker.MarkTile(_tileFinder.CurrentTileID.Value, true);
        OnUpdateVertexData();
    }

    public void OnRender(TimeSpan elapsedTimeSpan, double width, double height)
    {
        if (!_loaded || _renderer.FpsCounter == null)
            return;

        _renderer.OnRender(elapsedTimeSpan);
        _tileFinder.Update(_inputController.NewMousePosition, width, height);

        UpdateDebugInformation(elapsedTimeSpan);
    }

    public void Handle(IMessage message)
    {
        if (message is not CameraMoverMessage cameraMoverMessage)
            return;

        Camera.Instance.Transform.Position = new Vector3(
            cameraMoverMessage.X,
            Camera.Instance.Transform.PositionY,
            cameraMoverMessage.Y + Camera.Instance.Transform.PositionY / 3);
        Camera.Instance.Front = new Vector3(0, -2, -1);

        OnUpdateVertexData();
    }

    private void UpdateDebugInformation(TimeSpan elapsedTimeSpan)
    {
        _millisecs += elapsedTimeSpan.Milliseconds;
        if (_millisecs >= FPSCounter.Interval)
        {
            if (_renderer.FpsCounter != null)
            {
                _debugInformation.FPS = _renderer.FpsCounter.FPS;
                _debugInformation.Milliseconds = _renderer.FpsCounter.Milliseconds;
            }

            _millisecs = 0;
        }

        _debugInformation.CameraPosition = Camera.Instance.Transform.Position;
        _debugInformation.RayCastDirection = _tileFinder.CurrentRay;
        _debugInformation.CurrentTileCoordinates = _tileFinder.CurrentTileCoordinates;
        _debugInformation.CurrentTileID = _tileFinder.CurrentTileID;
        OnDebugInfoChanged?.Invoke(_debugInformation);
    }
}