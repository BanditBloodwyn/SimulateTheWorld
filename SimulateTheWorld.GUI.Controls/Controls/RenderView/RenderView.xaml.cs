using System.Windows.Controls;
using OpenTK.Mathematics;
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
            _lbl_debug.Content = $"Camera Pos: {info.CameraPosition.X:0.000}, {info.CameraPosition.Y:0.000}, {info.CameraPosition.Z:0.000}" + "\t" +
                                 $"Camera Rot: {MathHelper.RadiansToDegrees(info.CameraRotation.X):0.000}, {MathHelper.RadiansToDegrees(info.CameraRotation.Y):0.000}, {MathHelper.RadiansToDegrees(info.CameraRotation.Z):0.000}";
        }
    }
}
