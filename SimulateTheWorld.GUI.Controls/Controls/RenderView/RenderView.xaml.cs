using System.Windows.Controls;
using SimulateTheWorld.Graphics.Rendering.Utilities;

namespace SimulateTheWorld.GUI.Controls.Controls.RenderView
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
            _lbl_debug.Content = $"Camera Pos: {info.CameraPosition.X:0.000}, {info.CameraPosition.Y:0.000}, {info.CameraPosition.Z:0.000}";
        }
    }
}
