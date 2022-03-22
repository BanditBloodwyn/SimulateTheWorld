using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenTK.Graphics.ES30;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using OpenTK.Wpf;

namespace SimulateTheWorld.Rendering.Control
{
    /// <summary>
    /// Interaktionslogik für RenderingControl.xaml
    /// </summary>
    public partial class RenderingControl : UserControl
    {
        public RenderingControl()
        {
            InitializeComponent();

            InitGLControl();
        }

        private void InitGLControl()
        {
            NativeWindowSettings se = NativeWindowSettings.Default;
            GLWpfControlSettings settings = new GLWpfControlSettings
            {
                MajorVersion = 3,
                MinorVersion = 3
            };
            glControl.Start(settings);
        }

        private void GlControl_OnRender(TimeSpan obj)
        {
            GL.ClearColor(new Color4(0, 0, 70, 0));
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }
    }
}
