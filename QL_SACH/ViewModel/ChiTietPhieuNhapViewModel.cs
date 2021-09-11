using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using QL_SACH.Model;

namespace QL_SACH.ViewModel
{
    public class ChiTietPhieuNhapViewModel : BaseViewModel
    {
        private ObservableCollection<CHITIETPHIEUNHAP> _ListChiTietPhieuNhap;
        public ObservableCollection<CHITIETPHIEUNHAP> ListChiTietPhieuNhap { get => _ListChiTietPhieuNhap; set { _ListChiTietPhieuNhap = value; OnPropertyChanged(); } }

        private ObservableCollection<PHIEUNHAPSACH> _PhieuNhapSach;
        public ObservableCollection<PHIEUNHAPSACH> PhieuNhapSach { get => _PhieuNhapSach; set { _PhieuNhapSach = value; OnPropertyChanged(); } }

        private ObservableCollection<SACH> _Sach;
        public ObservableCollection<SACH> Sach { get => _Sach; set { _Sach = value; OnPropertyChanged(); } }

        private int _SoLuongNhap;
        public int SoLuongNhap { get => _SoLuongNhap; set { _SoLuongNhap = value; OnPropertyChanged(); } }

        private decimal _DonGiaNhap;
        public decimal DonGiaNhap { get => _DonGiaNhap; set { _DonGiaNhap = value; OnPropertyChanged(); } }

        /// <summary>
        /// Khai báo Command
        /// </summary>
        public ICommand AddCommand { get; set; }

        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        /// <summary>
        /// Thay đổi giá trị trong control khi chọn một đối tượng trong ListView
        /// </summary>
        private Model.CHITIETPHIEUNHAP _SelectedItem;

        public Model.CHITIETPHIEUNHAP SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    SelectedPhieuNhapSach = SelectedItem.PHIEUNHAPSACH;
                    SelectedSach = SelectedItem.SACH;
                    SoLuongNhap = SelectedItem.SoLuongNhap;
                    DonGiaNhap = SelectedItem.DonGiaNhap;
                }
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

        private Model.PHIEUNHAPSACH _SelectedPhieuNhapSach;

        public Model.PHIEUNHAPSACH SelectedPhieuNhapSach
        {
            get => _SelectedPhieuNhapSach;
            set
            {
                _SelectedPhieuNhapSach = value;
                OnPropertyChanged();
            }
        }

        public ChiTietPhieuNhapViewModel()
        {
            ListChiTietPhieuNhap = new ObservableCollection<CHITIETPHIEUNHAP>(DataProvider.Ins.DB.CHITIETPHIEUNHAP);
            PhieuNhapSach = new ObservableCollection<PHIEUNHAPSACH>(DataProvider.Ins.DB.PHIEUNHAPSACH);
            Sach = new ObservableCollection<SACH>(DataProvider.Ins.DB.SACH);

            AddCommand = new RelayCommand<object>((p) =>
            {
                if ((SelectedItem == null) && (SelectedPhieuNhapSach != null && SelectedSach != null && SoLuongNhap.ToString() != null && DonGiaNhap.ToString() != null))
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                if (DataProvider.Ins.DB.CHITIETPHIEUNHAP.Find(SelectedItem.SoLuongNhap, SelectedItem.MaSach) == null)
                {
                    var chitietphieunhap = new Model.CHITIETPHIEUNHAP() { SoPNS = SelectedPhieuNhapSach.SoPNS, MaSach = SelectedSach.MaSach, SoLuongNhap = SoLuongNhap, DonGiaNhap = DonGiaNhap };

                    DataProvider.Ins.DB.CHITIETPHIEUNHAP.Add(chitietphieunhap);
                    DataProvider.Ins.DB.SaveChanges();

                    ListChiTietPhieuNhap.Add(chitietphieunhap);
                    MessageBox.Show("Chi tiết Phiếu nhập: " + SelectedItem.SoPNS + " đã thêm thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);

                    SelectedPhieuNhapSach = null;
                    SelectedSach = null;
                    SelectedItem = null;
                    //SoLuongNhap = null;
                    //DonGiaNhap = null;
                }
                else
                {
                    MessageBox.Show("Số phiếu nhập " + SelectedItem.SoPNS + " và " + SelectedItem.MaSach + " đã tồn tại", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if ((SelectedPhieuNhapSach == null || SelectedSach == null) || SoLuongNhap.ToString() == null || DonGiaNhap.ToString() == null)
                    return false;

                var displayList = DataProvider.Ins.DB.CHITIETPHIEUNHAP.Where(x => (x.SoPNS == SelectedItem.SoPNS && x.MaSach == SelectedItem.MaSach));
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;
            }, (p) =>
            {
                var chitietphieunhap = DataProvider.Ins.DB.CHITIETPHIEUNHAP.Where(x => x.SoPNS == SelectedItem.SoPNS).SingleOrDefault();
                chitietphieunhap.SoLuongNhap = SelectedItem.SoLuongNhap;
                chitietphieunhap.DonGiaNhap = SelectedItem.DonGiaNhap;
                DataProvider.Ins.DB.SaveChanges();
                //SelectedItem.MaNV = MaNV;
                MessageBox.Show("Chi tiết Phiếu nhập " + SelectedItem.SoPNS + " đã sửa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);

                SelectedPhieuNhapSach = null;
                SelectedSach = null;
                SelectedItem = null;
                //SoLuongNhap = null;
                //DonGiaNhap = null;
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.CHITIETPHIEUNHAP.Where(x => (x.SoPNS == SelectedItem.SoPNS && x.MaSach == SelectedItem.MaSach));
                if (displayList != null && displayList.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                var chitietphieunhap = DataProvider.Ins.DB.CHITIETPHIEUNHAP.Where(x => (x.SoPNS == SelectedItem.SoPNS && x.MaSach == SelectedItem.MaSach)).FirstOrDefault();

                DataProvider.Ins.DB.CHITIETPHIEUNHAP.Remove(chitietphieunhap);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Phiếu nhập " + SelectedItem.SoPNS + " và " + SelectedSach.MaSach + " đã xóa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                ListChiTietPhieuNhap.Remove(chitietphieunhap);

                SelectedPhieuNhapSach = null;
                SelectedSach = null;
                SelectedItem = null;
                //SoLuongNhap = null;
                //DonGiaNhap = null;
            });
        }
    }
}