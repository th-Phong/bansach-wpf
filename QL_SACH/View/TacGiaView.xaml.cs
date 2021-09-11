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

namespace QL_SACH.View
{
    /// <summary>
    /// Interaction logic for TacGiaView.xaml
    /// </summary>
    public partial class TacGiaView : UserControl
    {
        public TacGiaView()
        {
            InitializeComponent();
            cbPhai.ItemsSource = new string[] { "Nam", "Nữ" };
        }

        private void ListView_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            listTacGia.SelectedItem = null;
        }

        private void UserControl_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            listTacGia.SelectedItem = null;
        }
    }
}