using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Globalization;
using System.Threading;

namespace QL_SACH.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            GridPrincipal.Children.Add(new SachView());

            //Set datetime kiểu dd/mm/yyyy
            CultureInfo ci = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            ci.DateTimeFormat.DateSeparator = "/";
            Thread.CurrentThread.CurrentCulture = ci;
        }

        private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            GridData.Margin = new Thickness(70, 70, 10, 10);
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
            GridData.Margin = new Thickness(212, 70, 10, 10);
        }

        //Chọn form hiển thị khi nhấp vào menu bên trái
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int index = ListViewMenu.SelectedIndex;

            //MoveCursorMenu(index);
            //switch (index)
            //{
            //    case 0:
            //        GridPrincipal.Children.Clear();
            //        GridPrincipal.Children.Add(new HoaDonView());
            //        break;

            //    case 1:
            //        GridPrincipal.Children.Clear();
            //        GridPrincipal.Children.Add(new ChiTietHoaDonView());
            //        break;

            //    case 2:
            //        GridPrincipal.Children.Clear();
            //        GridPrincipal.Children.Add(new KhachHangView());
            //        break;

            //    case 3:
            //        GridPrincipal.Children.Clear();
            //        GridPrincipal.Children.Add(new NhanVienView());
            //        break;

            //    case 4:
            //        GridPrincipal.Children.Clear();
            //        GridPrincipal.Children.Add(new HangHoaView());
            //        break;

            //    default:
            //        break;
            //}
        }

        private void MoveCursorMenu(int index)
        {
            TrainsitionContextSlide.OnApplyTemplate();
            GridCusor.Margin = new Thickness(0, (60 * index) + 0.4, 0, 0);
        }
    }
}