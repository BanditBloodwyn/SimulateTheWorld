using System.Windows.Controls;
using SimulateTheWorld.Rendering.Model;

namespace SimulateTheWorld.Rendering.Control
{
    /// <summary>
    /// Interaktionslogik für RenderingControl.xaml
    /// </summary>
    public sealed partial class RenderingControl : UserControl
    {
        public RenderingControl()
        {
            InitializeComponent();
            AddChild((DataContext as RenderingControlViewModel)?.GLControl);
        }
    }
}
