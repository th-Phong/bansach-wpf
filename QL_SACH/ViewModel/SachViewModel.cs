using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using QL_SACH.Model;

namespace QL_SACH.ViewModel
{
    public class SachViewModel : BaseViewModel
    {
        private ObservableCollection<SACH> _ListSach;
        public ObservableCollection<SACH> ListSach { get => _ListSach; set { _ListSach = value; OnPropertyChanged(); } }

        private ObservableCollection<TACGIA> _TacGia;
        public ObservableCollection<TACGIA> TacGia { get => _TacGia; set { _TacGia = value; OnPropertyChanged(); } }

        private ObservableCollection<THELOAI> _TheLoai;
        public ObservableCollection<THELOAI> TheLoai { get => _TheLoai; set { _TheLoai = value; OnPropertyChanged(); } }

        private ObservableCollection<NHAXUATBAN> _NhaXuatBan;
        public ObservableCollection<NHAXUATBAN> NhaXuatBan { get => _NhaXuatBan; set { _NhaXuatBan = value; OnPropertyChanged(); } }

        private ObservableCollection<KHUYENMAI> _KhuyenMai;
        public ObservableCollection<KHUYENMAI> KhuyenMai { get => _KhuyenMai; set { _KhuyenMai = value; OnPropertyChanged(); } }

        private string _MaSach;
        public string MaSach { get => _MaSach; set { _MaSach = value; OnPropertyChanged(); } }

        /// <summary>
        /// Khai báo Command
        /// </summary>
        public ICommand AddCommand { get; set; }

        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        /// <summary>
        /// Thay đổi giá trị trong control khi chọn một đối tượng trong ListView
        /// </summary>
        private Model.SACH _SelectedItem;

        public Model.SACH SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    MaSach = SelectedItem.MaSach;
                    SelectedTacGia = SelectedItem.TACGIA;
                    SelectedTheLoai = SelectedItem.THELOAI;
                    SelectedNhaXuatBan = SelectedItem.NHAXUATBAN;
                    SelectedKhuyenMai = SelectedItem.KHUYENMAI;
                }
            }
        }

        private Model.TACGIA _SelectedTacGia;

        public Model.TACGIA SelectedTacGia
        {
            get => _SelectedTacGia;
            set
            {
                _SelectedTacGia = value;
                OnPropertyChanged();
            }
        }

        private Model.THELOAI _SelectedTheLoai;

        public Model.THELOAI SelectedTheLoai
        {
            get => _SelectedTheLoai;
            set
            {
                _SelectedTheLoai = value;
                OnPropertyChanged();
            }
        }

        private Model.NHAXUATBAN _SelectedNhaXuatBan;

        public Model.NHAXUATBAN SelectedNhaXuatBan
        {
            get => _SelectedNhaXuatBan;
            set
            {
                _SelectedNhaXuatBan = value;
                OnPropertyChanged();
            }
        }

        private Model.KHUYENMAI _SelectedKhuyenMai;

        public Model.KHUYENMAI SelectedKhuyenMai
        {
            get => _SelectedKhuyenMai;
            set
            {
                _SelectedKhuyenMai = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Các xử lý chính
        /// </summary>
        public SachViewModel()
        {

            ListSach = new ObservableCollection<SACH>(DataProvider.Ins.DB.SACH);
            TacGia = new ObservableCollection<TACGIA>(DataProvider.Ins.DB.TACGIA);
            TheLoai = new ObservableCollection<THELOAI>(DataProvider.Ins.DB.THELOAI);
            NhaXuatBan = new ObservableCollection<NHAXUATBAN>(DataProvider.Ins.DB.NHAXUATBAN);
            KhuyenMai = new ObservableCollection<KHUYENMAI>(DataProvider.Ins.DB.KHUYENMAI);
            //Thêm Sách mới
            AddCommand = new RelayCommand<object>((p) =>
            {
                //Bật tắt TextBox Mã sách
                if (SelectedItem == null)
                    IsEnabled = true;
                else
                    IsEnabled = false;
                //Bật tắt nút
                if (SelectedItem == null && MaSach != null)// && (SelectedTacGia != null && SelectedTheLoai != null && SelectedNhaXuatBan != null && SelectedKhuyenMai != null))
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                if (DataProvider.Ins.DB.SACH.Find(MaSach) == null)
                {
                    if (CheckNull() == false)
                    {
                        var AddRecord = MessageBox.Show("Bạn có chắc chắn muốn Thêm Sách " + MaSach + " của Tác giả: " + SelectedTacGia.TenTacGia + " không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (AddRecord == MessageBoxResult.Yes)
                        {
                            var sach = new Model.SACH() { MaSach = MaSach, MaTacGia = SelectedTacGia.MaTacGia, MaTheLoai = SelectedTheLoai.MaTheLoai, MaNhaXuatBan = SelectedNhaXuatBan.MaNhaXuatBan, MaKM = SelectedKhuyenMai.MaKM };

                            DataProvider.Ins.DB.SACH.Add(sach);
                            DataProvider.Ins.DB.SaveChanges();

                            ListSach.Add(sach);
                            MessageBox.Show("Mã sách " + MaSach + " đã thêm thành công !", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                            Reset();
                        }
                    }
                    else
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin tất cả thông tin !!!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show("Mã sách " + MaSach + " đã tồn tại !", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });
            //Sửa thông tin Sách
            EditCommand = new RelayCommand<object>((p) =>
            {
                if ((SelectedTacGia == null || SelectedTheLoai == null || SelectedNhaXuatBan == null || SelectedKhuyenMai == null) || SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.SACH.Where(x => x.MaSach == SelectedItem.MaSach);
                if (displayList != null)// && displayList.Count() != 0)
                    return true;

                return false;
            }, (p) =>
            {
                var FixRecord = MessageBox.Show("Bạn có chắc chắn muốn sửa Sách " + SelectedItem.MaSach + " không ?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (FixRecord == MessageBoxResult.Yes)
                {
                    var sach = DataProvider.Ins.DB.SACH.Where(x => x.MaSach == SelectedItem.MaSach).SingleOrDefault();
                    sach.MaTacGia = SelectedTacGia.MaTacGia;
                    sach.MaTheLoai = SelectedTheLoai.MaTheLoai;
                    sach.MaNhaXuatBan = SelectedNhaXuatBan.MaNhaXuatBan;
                    sach.MaKM = SelectedKhuyenMai.MaKM;
                    DataProvider.Ins.DB.SaveChanges();
                    SelectedItem.MaSach = MaSach;
                    MessageBox.Show("Mã sách " + MaSach + " đã sửa thành công !", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);

                    Reset();
                }
            });
            //Xóa Sách
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                var displayList = DataProvider.Ins.DB.SACH.Where(x => x.MaSach == SelectedItem.MaSach);
                if (displayList != null)// && displayList.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                var DeleteRecord = MessageBox.Show("Bạn có chắc chắn muốn xóa Sách " + SelectedItem.MaSach + " không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (DeleteRecord == MessageBoxResult.Yes)
                {
                    var sach = DataProvider.Ins.DB.SACH.Where(x => x.MaSach == SelectedItem.MaSach).FirstOrDefault();
                    //Kiểm tra sách có tồn tại trong CHI TIẾT HÓA ĐƠN hay không
                    var sach_in_hoadon = DataProvider.Ins.DB.CT_HOADON.Where(x => x.MaSach == SelectedItem.MaSach).FirstOrDefault();
                    if (sach_in_hoadon != null)
                    {
                        MessageBox.Show("Mã sách " + MaSach + " đã tồn tại trong các hóa đơn trước đó - Vui lòng kiểm tra lại !!!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        DataProvider.Ins.DB.SACH.Remove(sach);
                        DataProvider.Ins.DB.SaveChanges();
                        MessageBox.Show("Mã sách " + MaSach + " đã xóa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        ListSach.Remove(sach);
                        Reset();
                    }
                }
            });
        }

        /// <summary>
        /// Làm mới dữ liệu trong các control
        /// </summary>
        public void Reset()
        {
            MaSach = null;
            SelectedTacGia = null;
            SelectedTheLoai = null;
            SelectedNhaXuatBan = null;
            SelectedKhuyenMai = null;
            SelectedItem = null;
        }
        //Tạo sự kiện bật-tắt IsEnable textbox Mã sách
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

        //public bool _isSelected;
        //public bool IsSelected
        //{
        //    get { return _isSelected; }
        //    set
        //    {
        //        if (_isSelected == value)
        //        {
        //            return;
        //        }
        //        _isSelected = value;
        //        OnPropertyChanged();
        //    }
        //}
        
        //kiểm tra dữ liệu trong các control trên form 
        public bool CheckNull()
        {
            if (MaSach != null && SelectedTacGia != null && SelectedTheLoai != null && SelectedNhaXuatBan != null && SelectedKhuyenMai != null)
                return false;
            else
                return true;
        }
    }
}