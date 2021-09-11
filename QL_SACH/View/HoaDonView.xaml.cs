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
    /// Interaction logic for HoaDonView.xaml
    /// </summary>
    public partial class HoaDonView : UserControl
    {
        public HoaDonView()
        {
            InitializeComponent();
            cbTrangThai.ItemsSource = new string[] { "Đã thanh toán", "Chưa thanh toán" };
        }

        private void listHoaDon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            listHoaDon.SelectedItem = null;
        }

        private void UserControl_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            listHoaDon.SelectedItem = null;
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            listHoaDon.SelectedItem = null;
        }   
    }
}