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

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.ContextMenu != null)
            {
                button.ContextMenu.IsOpen = true;
            }
        }

        private void btn_RightClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }
    }
}
