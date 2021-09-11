using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using QL_SACH.Model;

namespace QL_SACH.ViewModel
{
    public class NhanVienViewModel : BaseViewModel
    {
        private ObservableCollection<NHANVIEN> _ListNhanVien;
        public ObservableCollection<NHANVIEN> ListNhanVien { get => _ListNhanVien; set { _ListNhanVien = value; OnPropertyChanged(); } }

        private ObservableCollection<TAIKHOAN> _TaiKhoan;
        public ObservableCollection<TAIKHOAN> TaiKhoan { get => _TaiKhoan; set { _TaiKhoan = value; OnPropertyChanged(); } }

        private ObservableCollection<ChucVu> _ChucVu;
        public ObservableCollection<ChucVu> ChucVu { get => _ChucVu; set { _ChucVu = value; OnPropertyChanged(); } }

        private string _MaNV;
        public string MaNV { get => _MaNV; set { _MaNV = value; OnPropertyChanged(); } }

        private string _TenNV;
        public string TenNV { get => _TenNV; set { _TenNV = value; OnPropertyChanged(); } }

        private string _DiaChi;
        public string DiaChi { get => _DiaChi; set { _DiaChi = value; OnPropertyChanged(); } }

        private int _SoDienThoai;
        public int SoDienThoai { get => _SoDienThoai; set { _SoDienThoai = value; OnPropertyChanged(); } }

        private string _CMND;
        public string CMND { get => _CMND; set { _CMND = value; OnPropertyChanged(); } }

        private string _Phai;
        public string Phai { get => _Phai; set { _Phai = value; OnPropertyChanged(); } }

        private DateTime? _NgaySinh;
        public DateTime? NgaySinh { get => _NgaySinh; set { _NgaySinh = value; OnPropertyChanged(); } }

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
        private Model.NHANVIEN _SelectedItem;

        public Model.NHANVIEN SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    MaNV = SelectedItem.MaNV;
                    SelectedTaiKhoan = SelectedItem.TAIKHOAN;
                    SelectedChucVu = SelectedItem.ChucVu;
                    TenNV = SelectedItem.TenNV;
                    DiaChi = SelectedItem.DiaChi;
                    SoDienThoai = SelectedItem.SoDienThoai;
                    CMND = SelectedItem.CMND;
                    Phai = SelectedItem.Phai;
                    NgaySinh = SelectedItem.NgaySinh;
                    TrangThai = SelectedItem.TrangThai;
                }
            }
        }

        private Model.TAIKHOAN _SelectedTaiKhoan;

        public Model.TAIKHOAN SelectedTaiKhoan
        {
            get => _SelectedTaiKhoan;
            set
            {
                _SelectedTaiKhoan = value;
                OnPropertyChanged();
            }
        }

        private Model.ChucVu _SelectedChucVu;

        public Model.ChucVu SelectedChucVu
        {
            get => _SelectedChucVu;
            set
            {
                _SelectedChucVu = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Reset dữ liệu trên các control về rỗng
        /// </summary>
        public void Reset()
        {
            MaNV = null;
            SelectedTaiKhoan = null;
            SelectedChucVu = null;
            TenNV = null;
            DiaChi = null;
            SoDienThoai = 0;
            CMND = null;
            Phai = null;
            NgaySinh = DateTime.Now;
            SelectedItem = null;
            TrangThai = null;
        }

        /// <summary>
        /// Các xử lý chính
        /// </summary>
        public NhanVienViewModel()
        {
            ListNhanVien = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIEN);
            TaiKhoan = new ObservableCollection<TAIKHOAN>(DataProvider.Ins.DB.TAIKHOAN);
            ChucVu = new ObservableCollection<ChucVu>(DataProvider.Ins.DB.ChucVu);

            //Thêm nhân viên
            AddCommand = new RelayCommand<object>((p) =>
            {
                //Bật tắt TextBox Mã sách
                if (SelectedItem == null)
                    IsEnabled = true;
                else
                    IsEnabled = false;
                //Bật tắt nút
                if ((SelectedItem == null) && (SelectedTaiKhoan != null && SelectedChucVu != null && TenNV != null))// && DiaChi != null && SoDienThoai.ToString() != null && CMND != null && Phai != null && NgaySinh != null))
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                if (DataProvider.Ins.DB.NHANVIEN.Find(MaNV) == null)
                {
                    var AddRecord = MessageBox.Show("Bạn có chắc chắn muốn Thêm Nhân viên " + TenNV + " không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (AddRecord == MessageBoxResult.Yes)
                    {
                        if (CheckNull() == false)
                        {
                            var nhanvien = new Model.NHANVIEN() { MaNV = MaNV, UserName = SelectedTaiKhoan.UserName, MaChucVu = SelectedChucVu.MaChucVu, TenNV = TenNV, DiaChi = DiaChi, SoDienThoai = SoDienThoai, CMND = CMND, Phai = Phai, NgaySinh = NgaySinh, TrangThai = TrangThai };

                            DataProvider.Ins.DB.NHANVIEN.Add(nhanvien);
                            DataProvider.Ins.DB.SaveChanges();

                            ListNhanVien.Add(nhanvien);
                            MessageBox.Show("Nhân viên " + TenNV + " đã thêm thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                            Reset();
                        }
                        else
                            MessageBox.Show("Vui lòng nhập đầy đủ thông tin tất cả thông tin !!!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Mã nhân viên " + MaNV + " đã tồn tại", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });

            //Sửa thông tin nhân viên
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedTaiKhoan == null || SelectedChucVu == null || TenNV == null || DiaChi == null || SoDienThoai.ToString() == null || CMND == null || Phai == null || NgaySinh == null || SelectedItem == null || TrangThai == null)
                    return false;

                var displayList = DataProvider.Ins.DB.NHANVIEN.Where(x => x.MaNV == SelectedItem.MaNV);
                if (displayList != null)// && displayList.Count() != 0
                    return true;

                return false;
            }, (p) =>
            {
                var FixRecord = MessageBox.Show("Bạn có chắc chắn muốn sửa Thông tin nhân viên " + SelectedItem.TenNV + " không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (FixRecord == MessageBoxResult.Yes)
                {
                    var nhanvien = DataProvider.Ins.DB.NHANVIEN.Where(x => x.MaNV == SelectedItem.MaNV).SingleOrDefault();
                    nhanvien.UserName = SelectedTaiKhoan.UserName;
                    nhanvien.MaChucVu = SelectedChucVu.MaChucVu;
                    nhanvien.TenNV = TenNV;
                    nhanvien.DiaChi = DiaChi;
                    nhanvien.SoDienThoai = SoDienThoai;
                    nhanvien.CMND = CMND;
                    nhanvien.Phai = Phai;
                    nhanvien.NgaySinh = NgaySinh;
                    nhanvien.TrangThai = TrangThai;
                    DataProvider.Ins.DB.SaveChanges();
                    //SelectedItem.MaNV = MaNV;
                    MessageBox.Show("Sửa thông tin Nhân viên " + TenNV + " đã sửa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);

                    Reset();
                }
            });

            //Xóa nhân viên
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.NHANVIEN.Where(x => x.MaNV == SelectedItem.MaNV);
                if (displayList != null)// && displayList.Count() != 0
                    return true;
                return false;
            }, (p) =>
            {
                var DeleteRecord = MessageBox.Show("Bạn có chắc chắn muốn xóa Nhân viên " + SelectedItem.TenNV + " không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (DeleteRecord == MessageBoxResult.Yes)
                {
                    var nhanvien = DataProvider.Ins.DB.NHANVIEN.Where(x => x.MaNV == SelectedItem.MaNV).FirstOrDefault();
                    //Kiểm tra nhân viên này có tồn tại trong Hóa đơn hay chưa
                    var nhanvien_in_hoadon = DataProvider.Ins.DB.HOADON.Where(x => x.MaNV == SelectedItem.MaNV).FirstOrDefault();
                    var nhanvien_in_phieunhap = DataProvider.Ins.DB.PHIEUNHAPSACH.Where(x => x.MaNV == SelectedItem.MaNV).FirstOrDefault();

                    if (nhanvien_in_hoadon != null || nhanvien_in_phieunhap != null)
                    {
                        MessageBox.Show("Nhân viên " + SelectedItem.TenNV + " đã tồn tại trong các HÓA ĐƠN hoặc PHIẾU NHẬP - Vui lòng kiểm tra lại !!!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        DataProvider.Ins.DB.NHANVIEN.Remove(nhanvien);
                        DataProvider.Ins.DB.SaveChanges();
                        MessageBox.Show("Nhân viên " + TenNV + " đã xóa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        ListNhanVien.Remove(nhanvien);
                        //Làm trống dữ liệu trên các control nhập liệu
                        Reset();
                    }
                }
            });
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
            if (SelectedTaiKhoan != null && SelectedChucVu != null && TenNV != null && DiaChi != null && SoDienThoai.ToString() != null && CMND != null && Phai != null && NgaySinh != null)
                return false;
            else
                return true;
        }
    }
}