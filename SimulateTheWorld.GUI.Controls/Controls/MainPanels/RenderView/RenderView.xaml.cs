using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Controls;
using SimulateTheWorld.Graphics.Rendering.Container;
using SimulateTheWorld.World.System.Instances;

namespace SimulateTheWorld.GUI.Controls.Controls.MainPanels.RenderView
{
    /// <summary>
    /// Interaktionslogik für RenderView.xaml
    /// </summary>
    public partial class RenderView : UserControl
    {
        public event Action<int>? OnTileSelected;

        public RenderView()
        {
            InitializeComponent();
            
            _renderingControl.OnDebugInfoChanged += RenderingControlOnOnDebugInfoChanged;
            _renderingControl.OnTileSelected += OnOnTileSelected;

            WaitingWindow waitingWindow = new WaitingWindow();
            waitingWindow.Show();

            Task.Factory
                .StartNew(() => STWWorld.Instance)
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
            Debug.WriteLine("Update world rendering");

            _renderingControl.OnUpdateVertexData();
        }
    }
}
