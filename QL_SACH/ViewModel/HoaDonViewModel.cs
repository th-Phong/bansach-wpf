using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using QL_SACH.Model;

namespace QL_SACH.ViewModel
{
    public class HoaDonViewModel : BaseViewModel
    {
        private ObservableCollection<HOADON> _ListHoaDon;
        public ObservableCollection<HOADON> ListHoaDon { get => _ListHoaDon; set { _ListHoaDon = value; OnPropertyChanged(); } }

        private ObservableCollection<KHACHHANG> _KhachHang;
        public ObservableCollection<KHACHHANG> KhachHang { get => _KhachHang; set { _KhachHang = value; OnPropertyChanged(); } }

        private ObservableCollection<NHANVIEN> _NhanVien;
        public ObservableCollection<NHANVIEN> NhanVien { get => _NhanVien; set { _NhanVien = value; OnPropertyChanged(); } }

        private string _SoHD;
        public string SoHD { get => _SoHD; set { _SoHD = value; OnPropertyChanged(); } }

        private DateTime? _NgayHoaDon;
        public DateTime? NgayHoaDon { get => _NgayHoaDon; set { _NgayHoaDon = value; OnPropertyChanged(); } }

        private string _TrangThai;
        public string TrangThai { get => _TrangThai; set { _TrangThai = value; OnPropertyChanged(); } }

        /// <summary>
        /// Khai báo Command
        /// </summary>
        public ICommand AddCommand { get; set; }

        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        /// <summary>
        /// Thay đổi giá trị trong control khi chọn một đối tượng trong ListView
        /// </summary>
        private Model.HOADON _SelectedItem;

        public Model.HOADON SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    SoHD = SelectedItem.SoHD;
                    SelectedKhachHang = SelectedItem.KHACHHANG;
                    SelectedNhanVien = SelectedItem.NHANVIEN;
                    NgayHoaDon = SelectedItem.NgayHoaDon;
                    TrangThai = SelectedItem.TrangThai;
                }
            }
        }

        private Model.KHACHHANG _SelectedKhachHang;

        public Model.KHACHHANG SelectedKhachHang
        {
            get => _SelectedKhachHang;
            set
            {
                _SelectedKhachHang = value;
                OnPropertyChanged();
            }
        }

        private Model.NHANVIEN _SelectedNhanVien;

        public Model.NHANVIEN SelectedNhanVien
        {
            get => _SelectedNhanVien;
            set
            {
                _SelectedNhanVien = value;
                OnPropertyChanged();
            }
        }

        public HoaDonViewModel()
        {
            ListHoaDon = new ObservableCollection<HOADON>(DataProvider.Ins.DB.HOADON);
            KhachHang = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANG);
            // NhanVien = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIEN);/*.Where(x=>x.Phai.Equals("Nữ")));*/
            NhanVien = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIEN.Where(x => x.TrangThai.Equals("Đang đi làm")));
            //Thêm hóa đơn
            AddCommand = new RelayCommand<object>((p) =>
            {
                //Bật tắt TextBox Mã sách
                if (SelectedItem == null)
                    IsEnabled = true;
                else
                    IsEnabled = false;
                //Bật tắt nút
                if ((SelectedItem == null) && (SoHD != null && _SelectedKhachHang != null && SelectedNhanVien != null))// && NgayHoaDon != null && TrangThai != null))
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                if (DataProvider.Ins.DB.HOADON.Find(SoHD) == null)
                {
                    if (CheckNull() == false)
                    {
                        var AddRecord = MessageBox.Show("Bạn có chắc chắn muốn Thêm hóa đơn " + SoHD + " không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (AddRecord == MessageBoxResult.Yes)
                        {
                            var hoadon = new Model.HOADON() { SoHD = SoHD, MaKhachHang = SelectedKhachHang.MaKhachHang, MaNV = SelectedNhanVien.MaNV, NgayHoaDon = NgayHoaDon, TrangThai = TrangThai };

                            DataProvider.Ins.DB.HOADON.Add(hoadon);
                            DataProvider.Ins.DB.SaveChanges();

                            ListHoaDon.Add(hoadon);
                            MessageBox.Show("Hóa đơn " + SoHD + " đã thêm thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);

                            Reset();
                        }
                    }
                    else
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin tất cả thông tin !!!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show("Mã hóa đơn " + SoHD + " đã tồn tại !", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });
            //Sửa thông tin hóa đơn
            EditCommand = new RelayCommand<object>((p) =>
            {
                if ((SelectedKhachHang == null || SelectedNhanVien == null || NgayHoaDon == null || TrangThai == null || SoHD == null) || SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.HOADON.Where(x => x.SoHD == SelectedItem.SoHD);
                if (displayList != null)// && displayList.Count() != 0
                    return true;

                return false;
            }, (p) =>
            {
                var FixRecord = MessageBox.Show("Bạn có chắc chắn muốn sửa Thông tin hóa đơn " + SelectedItem.SoHD + " không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (FixRecord == MessageBoxResult.Yes)
                {
                    var hoadon = DataProvider.Ins.DB.HOADON.Where(x => x.SoHD == SelectedItem.SoHD).SingleOrDefault();
                    hoadon.MaKhachHang = SelectedKhachHang.MaKhachHang;
                    hoadon.MaNV = SelectedNhanVien.MaNV;
                    hoadon.NgayHoaDon = NgayHoaDon;
                    hoadon.TrangThai = TrangThai;

                    DataProvider.Ins.DB.SaveChanges();
                    //SelectedItem.MaNV = MaNV;
                    MessageBox.Show("Số hóa đơn " + SoHD + " đã sửa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);

                    Reset();
                }
            });
            //Xóa hóa đơn
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.HOADON.Where(x => x.SoHD == SelectedItem.SoHD);
                if (displayList != null)// && displayList.Count() != 0
                    return true;
                return false;
            }, (p) =>
            {
                var DeleteRecord = MessageBox.Show("Bạn có chắc chắn muốn xóa Hóa đơn " + SelectedItem.SoHD + " không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (DeleteRecord == MessageBoxResult.Yes)
                {
                    var hoadon = DataProvider.Ins.DB.HOADON.Where(x => x.SoHD == SelectedItem.SoHD).FirstOrDefault();
                    //Kiểm tra sách có tồn tại trong CHI TIẾT HÓA ĐƠN hay không
                    var hoadon_in_cthoadon = DataProvider.Ins.DB.CT_HOADON.Where(x => x.SoHD == SelectedItem.SoHD).FirstOrDefault();
                    if (hoadon_in_cthoadon != null)
                    {
                        MessageBox.Show("Số hóa đơn " + SelectedItem.SoHD + " đã tồn tại trong các CHI TIẾT HÓA ĐƠN - Vui lòng kiểm tra lại !!!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        DataProvider.Ins.DB.HOADON.Remove(hoadon);
                        DataProvider.Ins.DB.SaveChanges();
                        MessageBox.Show("Hóa đơn " + SoHD + " đã xóa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        ListHoaDon.Remove(hoadon);
                        //Làm trống dữ liệu trên form
                        Reset();
                    }
                }
            });
        }

        //Làm trống giá trị trong các control
        public void Reset()
        {
            SoHD = null;
            SelectedKhachHang = null;
            SelectedNhanVien = null;
            NgayHoaDon = null;
            TrangThai = null;
            SelectedItem = null;
        }

        //Bật-Tắt IsEnabled textbox Mã hóa đơn
        public bool _isEnabled;

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                if (_isEnabled == value)
                {
                    return;
                }
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        //Kiểm tra dữ liệu rỗng
        public bool CheckNull()
        {
            if (SoHD != null && _SelectedKhachHang != null && SelectedNhanVien != null && NgayHoaDon != null && TrangThai != null)
                return false;
            else
                return true;
        }
    }
}