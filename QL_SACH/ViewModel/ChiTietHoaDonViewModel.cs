using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using QL_SACH.Model;

namespace QL_SACH.ViewModel
{
    public class ChiTietHoaDonViewModel : BaseViewModel
    {
        private ObservableCollection<CT_HOADON> _ListChiTietHoaDon;
        public ObservableCollection<CT_HOADON> ListChiTietHoaDon { get => _ListChiTietHoaDon; set { _ListChiTietHoaDon = value; OnPropertyChanged(); } }

        private ObservableCollection<SACH> _Sach;
        public ObservableCollection<SACH> Sach { get => _Sach; set { _Sach = value; OnPropertyChanged(); } }

        private ObservableCollection<HOADON> _HoaDon;
        public ObservableCollection<HOADON> HoaDon { get => _HoaDon; set { _HoaDon = value; OnPropertyChanged(); } }

        private int _SoLuong;
        public int SoLuong { get => _SoLuong; set { _SoLuong = value; OnPropertyChanged(); } }

        /// <summary>
        /// Khai báo Command
        /// </summary>
        public ICommand AddCommand { get; set; }

        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        /// <summary>
        /// Thay đổi giá trị trong control khi chọn một đối tượng trong ListView
        /// </summary>
        private Model.CT_HOADON _SelectedItem;

        public Model.CT_HOADON SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    SelectedHoaDon = SelectedItem.HOADON;
                    SelectedSach = SelectedItem.SACH;
                    SoLuong = SelectedItem.SoLuong;
                }
            }
        }

        private Model.HOADON _SelectedHoaDon;

        public Model.HOADON SelectedHoaDon
        {
            get => _SelectedHoaDon;
            set
            {
                _SelectedHoaDon = value;
                OnPropertyChanged();
            }
        }

        private Model.SACH _SelectedSach;

        public Model.SACH SelectedSach
        {
            get => _SelectedSach;
            set
            {
                _SelectedSach = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Các xử lý chính
        /// </summary>
        public ChiTietHoaDonViewModel()
        {
            ListChiTietHoaDon = new ObservableCollection<CT_HOADON>(DataProvider.Ins.DB.CT_HOADON);
            HoaDon = new ObservableCollection<HOADON>(DataProvider.Ins.DB.HOADON);
            Sach = new ObservableCollection<SACH>(DataProvider.Ins.DB.SACH);

            AddCommand = new RelayCommand<object>((p) =>
            {
                if ((SelectedItem == null) && (SelectedHoaDon != null && SelectedSach != null && SoLuong.ToString() != null))
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                if (DataProvider.Ins.DB.CT_HOADON.Find(SelectedHoaDon.SoHD, SelectedSach.MaSach) == null)
                {
                    var chitiethoadon = new Model.CT_HOADON() { SoHD = SelectedHoaDon.SoHD, MaSach = SelectedSach.MaSach, SoLuong = SoLuong };

                    DataProvider.Ins.DB.CT_HOADON.Add(chitiethoadon);
                    DataProvider.Ins.DB.SaveChanges();

                    ListChiTietHoaDon.Add(chitiethoadon);
                    MessageBox.Show("Chi tiết hóa đơn " + SelectedHoaDon.SoHD + " đã thêm thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    SelectedHoaDon = null;
                    SelectedSach = null;
                    //SoLuong = null;
                    SelectedItem = null;
                }
                else
                {
                    MessageBox.Show("Chi tiết hóa đơn " + SelectedHoaDon.SoHD + " và sách " + SelectedSach.MaSach + " đã tồn tại", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedSach == null || SelectedHoaDon == null || SoLuong.ToString() == null)
                    return false;

                var displayList = DataProvider.Ins.DB.CT_HOADON.Where(x => (x.SoHD == SelectedItem.SoHD && x.MaSach == SelectedItem.MaSach));
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;
            }, (p) =>
            {
                var chitietsach = DataProvider.Ins.DB.CT_HOADON.Where(x => (x.SoHD == SelectedItem.SoHD && x.MaSach == SelectedItem.MaSach)).SingleOrDefault();
                chitietsach.SoLuong = SoLuong;
                DataProvider.Ins.DB.SaveChanges();
                //SelectedItem.MaNV = MaNV;
                MessageBox.Show("Chi tiết hóa đơn  " + SelectedHoaDon.SoHD + " đã sửa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);

                SelectedHoaDon = null;
                SelectedSach = null;
                //SoLuong = null;
                SelectedItem = null;
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.CT_HOADON.Where(x => (x.SoHD == SelectedItem.SoHD && x.MaSach == SelectedItem.MaSach));
                if (displayList != null && displayList.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                var chitiethoadon = DataProvider.Ins.DB.CT_HOADON.Where(x => (x.SoHD == SelectedItem.SoHD && x.MaSach == SelectedItem.MaSach)).FirstOrDefault();

                DataProvider.Ins.DB.CT_HOADON.Remove(chitiethoadon);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Chi tiết hóa đơn " + SelectedItem.SoHD + " và sách " + SelectedItem.MaSach + " đã xóa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                ListChiTietHoaDon.Remove(chitiethoadon);

                SelectedHoaDon = null;
                SelectedSach = null;
                //SoLuong = null;
                SelectedItem = null;
            });
        }
    }
}