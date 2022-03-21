using System.Windows.Controls;
using System.Windows.Input;

namespace SimulateTheWorld.GUI.Controls.Toolbar
{
    /// <summary>
    /// Interaktionslogik für STWToolbar.xaml
    /// </summary>
    public partial class STWToolbar : UserControl
    {
        public STWToolbar()
        {
            InitializeComponent();
        }

        private void btn_RightClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }
    }
}
