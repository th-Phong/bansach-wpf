using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using QL_SACH.Model;

namespace QL_SACH.ViewModel
{
    public class KhacHangViewModel : BaseViewModel
    {
        private ObservableCollection<KHACHHANG> _ListKhachHang;
        public ObservableCollection<KHACHHANG> ListKhachHang { get => _ListKhachHang; set { _ListKhachHang = value; OnPropertyChanged(); } }

        private string _MaKhachHang;
        public string MaKhachHang { get => _MaKhachHang; set { _MaKhachHang = value; OnPropertyChanged(); } }

        private string _TenKhachHang;
        public string TenKhachHang { get => _TenKhachHang; set { _TenKhachHang = value; OnPropertyChanged(); } }

        private string _Phai;
        public string Phai { get => _Phai; set { _Phai = value; OnPropertyChanged(); } }

        private string _DiaChi;
        public string DiaChi { get => _DiaChi; set { _DiaChi = value; OnPropertyChanged(); } }

        private int _SDT;
        public int SDT { get => _SDT; set { _SDT = value; OnPropertyChanged(); } }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }

        private DateTime? _NgaySinh;
        public DateTime? NgaySinh { get => _NgaySinh; set { _NgaySinh = value; OnPropertyChanged(); } }

        /// <summary>
        /// Khai báo Command
        /// </summary>
        public ICommand AddCommand { get; set; }

        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        /// <summary>
        /// Thay đổi giá trị trong control khi chọn một đối tượng trong ListView
        /// </summary>
        private Model.KHACHHANG _SelectedItem;

        public Model.KHACHHANG SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    MaKhachHang = SelectedItem.MaKhachHang;
                    TenKhachHang = SelectedItem.TenKhachHang;
                    Phai = SelectedItem.Phai;
                    DiaChi = SelectedItem.DiaChi;
                    SDT = SelectedItem.SDT;
                    Email = SelectedItem.Email;
                    NgaySinh = SelectedItem.NgaySinh;
                }
            }
        }

        /// <summary>
        /// Làm trống control
        /// </summary>
        public void Reset()
        {
            MaKhachHang = null;
            TenKhachHang = null;
            Phai = null;
            DiaChi = null;
            SDT = 0;
            Email = null;
            NgaySinh = null;
            SelectedItem = null;
        }

        /// <summary>
        /// Các xử lý chính
        /// </summary>
        public KhacHangViewModel()
        {
            ListKhachHang = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANG);
            //Thêm khách hàng
            AddCommand = new RelayCommand<object>((p) =>
            {
                if ((SelectedItem == null) && (MaKhachHang != null && TenKhachHang != null && Phai != null && DiaChi != null && SDT.ToString() != null && Email != null && NgaySinh != null))
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                if (DataProvider.Ins.DB.KHACHHANG.Find(MaKhachHang) == null)
                {
                    var AddRecord = MessageBox.Show("Bạn có chắc chắn muốn Thêm Khách hàng " + TenKhachHang + " không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (AddRecord == MessageBoxResult.Yes)
                    {
                        var khachhang = new Model.KHACHHANG() { MaKhachHang = MaKhachHang, TenKhachHang = TenKhachHang, Phai = Phai, DiaChi = DiaChi, SDT = SDT, Email = Email, NgaySinh = NgaySinh };

                        DataProvider.Ins.DB.KHACHHANG.Add(khachhang);
                        DataProvider.Ins.DB.SaveChanges();

                        ListKhachHang.Add(khachhang);
                        MessageBox.Show("Khách hàng " + TenKhachHang + " đã thêm thành công !!!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        Reset();
                    }
                }
                else
                {
                    MessageBox.Show("Mã khách hàng " + MaKhachHang + " đã tồn tại !!!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });
            //Sửa thông tin khách hàng
            EditCommand = new RelayCommand<object>((p) =>
            {
                if ((MaKhachHang == null || TenKhachHang == null || Phai == null || DiaChi == null || SDT.ToString() == null || Email == null || NgaySinh.ToString() == null) || SelectedItem == null)
                    return false;
                var displayList = DataProvider.Ins.DB.KHACHHANG.Where(x => x.MaKhachHang == SelectedItem.MaKhachHang);
                if (displayList != null)// && displayList.Count() != 0
                    return true;
                return false;
            }, (p) =>
            {
                var FixRecord = MessageBox.Show("Bạn có chắc chắn muốn sửa Thông tin khách hàng " + SelectedItem.TenKhachHang + " không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (FixRecord == MessageBoxResult.Yes)
                {
                    var khachhang = DataProvider.Ins.DB.KHACHHANG.Where(x => x.MaKhachHang == SelectedItem.MaKhachHang).SingleOrDefault();
                    khachhang.TenKhachHang = TenKhachHang;
                    khachhang.Phai = Phai;
                    khachhang.DiaChi = DiaChi;
                    khachhang.SDT = SDT;
                    khachhang.Email = Email;
                    khachhang.NgaySinh = NgaySinh;
                    DataProvider.Ins.DB.SaveChanges();
                    //SelectedItem.MaKhachHang = MaKhachHang;
                    MessageBox.Show("Khách hàng " + MaKhachHang + " đã sửa thành công !!!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);

                    Reset();
                }
            });
            //Xóa khách hàng
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.KHACHHANG.Where(x => x.MaKhachHang == SelectedItem.MaKhachHang);
                if (displayList != null)// && displayList.Count() != 0
                    return true;
                return false;
            }, (p) =>
            {
                var DeleteRecord = MessageBox.Show("Bạn có chắc chắn muốn xóa Khách hàng " + SelectedItem.TenKhachHang + " không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (DeleteRecord == MessageBoxResult.Yes)
                {
                    var khachhang = DataProvider.Ins.DB.KHACHHANG.Where(x => x.MaKhachHang == SelectedItem.MaKhachHang).FirstOrDefault();

                    DataProvider.Ins.DB.KHACHHANG.Remove(khachhang);
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Mã khách hàng " + MaKhachHang + " đã xóa thành công !!!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    ListKhachHang.Remove(khachhang);

                    Reset();
                }
            });
        }
    }
}