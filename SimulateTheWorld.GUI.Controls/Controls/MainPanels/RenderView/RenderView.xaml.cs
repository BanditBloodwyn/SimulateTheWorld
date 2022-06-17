using System;
using System.Threading.Tasks;
using SimulateTheWorld.Core.Logging;
using SimulateTheWorld.Graphics.Rendering.Container;
using SimulateTheWorld.GUI.Controls.Dialogs;
using SimulateTheWorld.GUI.ViewModels.RenderingControl;
using SimulateTheWorld.World.Systems.Instances;

namespace SimulateTheWorld.GUI.Controls.Controls.MainPanels.RenderView;

/// <summary>
/// Interaktionslogik für RenderView.xaml
/// </summary>
public partial class RenderView
{
    public event Action<int>? OnTileSelected;

    public RenderView()
    {
        InitializeComponent();

        (_renderingControl.DataContext as RenderingControlViewModel)!.OnDebugInfoChanged += RenderingControlOnOnDebugInfoChanged;
        (_renderingControl.DataContext as RenderingControlViewModel)!.OnTileSelected += OnOnTileSelected;
        RenderingControlViewModel.SetTileContextMenu(new TileContextMenu());

        WaitingWindow waitingWindow = new WaitingWindow();
        waitingWindow.Show();

        Task.Factory
            .StartNew(static () => STWWorld.Instance)
            .ContinueWith(_ =>
            {
                Dispatcher.Invoke(() =>
                {
                    _renderingControl.Load();
                    waitingWindow.Close();
                });
            });
    }

    private void OnOnTileSelected(int tileID)
    {
        OnTileSelected?.Invoke(tileID);
    }

    private void RenderingControlOnOnDebugInfoChanged(DebugInformation info)
    {
        _lbl_cameraPos.Content = info.CameraPositionString;

        _fpsc_fpsControl.lbl_FpsSec.Content = info.FPS.ToString("N");
        _fpsc_fpsControl.lbl_FpsMilliSec.Content = ((info.FPS - Math.Truncate(info.FPS)) * 100).ToString("N");
        _fpsc_fpsControl.lbl_MilliSec.Content = info.Milliseconds.ToString("00");

        _lbl_rayCast.Content = $"{info.RayCastDirectionString} | {info.CurrentTileCoordinatesString} | TileID: {info.CurrentTileID}";
    }

    public void UpdateWorldRendering()
    {
        Logger.Debug(this, "Update world rendering");

        Dispatcher.Invoke(() => (_renderingControl.DataContext as RenderingControlViewModel)?.OnUpdateVertexData());
    }
}