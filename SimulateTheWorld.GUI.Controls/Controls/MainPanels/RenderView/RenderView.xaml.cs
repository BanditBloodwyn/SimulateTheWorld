using System;
using System.Windows.Controls;
using SimulateTheWorld.Graphics.Rendering.Container;

namespace SimulateTheWorld.GUI.Controls.Controls.MainPanels.RenderView
{
    /// <summary>
    /// Interaktionslogik für RenderView.xaml
    /// </summary>
    public partial class RenderView : UserControl
    {
        private readonly RendererInputData InputData;

        public RenderView()
        {
            InitializeComponent();
            
            InputData = new RendererInputData();
            _renderingControl.InputData = InputData;

            _renderingControl.OnDebugInfoChanged += RenderingControlOnOnDebugInfoChanged;
        }

        private void RenderingControlOnOnDebugInfoChanged(DebugInformation info)
        {
            _lbl_debug.Content = $"Camera Pos: {info.CameraPosition.X:0.000}, {info.CameraPosition.Y:0.000}, {info.CameraPosition.Z:0.000}";
            _fpsc_fpsControl.lbl_FpsSec.Content = info.FPS.ToString("N");
            _fpsc_fpsControl.lbl_FpsMilliSec.Content = ((info.FPS - Math.Truncate(info.FPS)) * 100).ToString("N");
        }

        public void TriggerNextRound()
        {
            InputData.TriggerUpdate = true;
        }
    }
}
