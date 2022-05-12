using System;
using System.Diagnostics;
using System.Windows.Controls;
using SimulateTheWorld.Graphics.Rendering.Container;

namespace SimulateTheWorld.GUI.Controls.Controls.MainPanels.RenderView
{
    /// <summary>
    /// Interaktionslogik für RenderView.xaml
    /// </summary>
    public partial class RenderView : UserControl
    {
        public RenderView()
        {
            InitializeComponent();
            
            _renderingControl.OnDebugInfoChanged += RenderingControlOnOnDebugInfoChanged;
        }

        private void RenderingControlOnOnDebugInfoChanged(DebugInformation info)
        {
            _lbl_cameraPos.Content = $"Camera Pos: {info.CameraPosition.X:0.000}, {info.CameraPosition.Y:0.000}, {info.CameraPosition.Z:0.000}";

            _fpsc_fpsControl.lbl_FpsSec.Content = info.FPS.ToString("N");
            _fpsc_fpsControl.lbl_FpsMilliSec.Content = ((info.FPS - Math.Truncate(info.FPS)) * 100).ToString("N");

            _lbl_rayCast.Content = $"Raycast direction: {info.RayCastDirection.X:0.000}, {info.RayCastDirection.Y:0.000}, {info.RayCastDirection.Z:0.000}";
        }

        public void UpdateWorldRendering()
        {
            Debug.WriteLine("Update world rendering");

            _renderingControl.OnUpdateVertexData();
        }
    }
}
