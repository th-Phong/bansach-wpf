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
    /// Interaction logic for NhanVienView.xaml
    /// </summary>
    public partial class NhanVienView : UserControl
    {
        public NhanVienView()
        {
            InitializeComponent();
            cbPhai.ItemsSource = new string[] { "Nam", "Nữ" };
            cbTrangThai.ItemsSource = new string[] { "Đang đi làm", "Đã nghỉ việc", "Đang xử lý" };
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            listNhanVien.SelectedItem = null;
        }

        private void listNhanVien_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            listNhanVien.SelectedItem = null;
        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            listNhanVien.SelectedItem = null;
        }

        private void listNhanVien_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            listNhanVien.SelectedItem = null;
        }

        private void Grid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            listNhanVien.SelectedItem = null;
        }
    }
}