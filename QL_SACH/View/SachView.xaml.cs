using System.Windows;
using System.Windows.Controls;
using QL_SACH.View;

namespace QL_SACH.View
{
    /// <summary>
    /// Interaction logic for SachView.xaml
    /// </summary>
    public partial class SachView : UserControl
    {
        public SachView()
        {
            InitializeComponent();
        }

        private void listSach_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            listSach.SelectedItem = null;
        }

        private void Grid_MouseRightButtonDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            listSach.SelectedItem = null;
        }

        private void Grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            listSach.SelectedItem = null;
        }
    }
}