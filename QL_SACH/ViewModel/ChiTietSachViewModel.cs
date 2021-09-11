using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using QL_SACH.Model;

namespace QL_SACH.ViewModel
{
    public class ChiTietSachViewModel : BaseViewModel
    {
        private ObservableCollection<CHITIETSACH> _ListChiTietSach;
        public ObservableCollection<CHITIETSACH> ListChiTietSach { get => _ListChiTietSach; set { _ListChiTietSach = value; OnPropertyChanged(); } }
        private ObservableCollection<SACH> _Sach;
        public ObservableCollection<SACH> Sach { get => _Sach; set { _Sach = value; OnPropertyChanged(); } }

        private string _MaSach;
        public string MaSach { get => _MaSach; set { _MaSach = value; OnPropertyChanged(); } }

        private string _TenSach;
        public string TenSach { get => _TenSach; set { _TenSach = value; OnPropertyChanged(); } }

        private decimal _DonGiaBan;
        public decimal DonGiaBan { get => _DonGiaBan; set { _DonGiaBan = value; OnPropertyChanged(); } }

        private int _SoLuongTon;
        public int SoLuongTon { get => _SoLuongTon; set { _SoLuongTon = value; OnPropertyChanged(); } }

        private int _LanTaiBan;
        public int LanTaiBan { get => _LanTaiBan; set { _LanTaiBan = value; OnPropertyChanged(); } }

        private short _SoTrang;
        public short SoTrang { get => _SoTrang; set { _SoTrang = value; OnPropertyChanged(); } }

        private string _LoaiBia;
        public string LoaiBia { get => _LoaiBia; set { _LoaiBia = value; OnPropertyChanged(); } }

        private DateTime? _NgayXuatBan;
        public DateTime? NgayXuatBan { get => _NgayXuatBan; set { _NgayXuatBan = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private Model.CHITIETSACH _SelectedItem;

        public Model.CHITIETSACH SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    SelectedSach = SelectedItem.SACH;
                    TenSach = SelectedItem.TenSach;
                    DonGiaBan = SelectedItem.DonGiaBan;
                    SoLuongTon = SelectedItem.SoLuongTon;
                    LanTaiBan = SelectedItem.LanTaiBan;
                    SoTrang = SelectedItem.SoTrang;
                    LoaiBia = SelectedItem.LoaiBia;
                    NgayXuatBan = SelectedItem.NgayXuatBan;
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

        public ChiTietSachViewModel()
        {
            ListChiTietSach = new ObservableCollection<CHITIETSACH>(DataProvider.Ins.DB.CHITIETSACH);

            AddCommand = new RelayCommand<object>((p) =>
            {
                if ((SelectedItem == null) && (SelectedSach != null && TenSach != null && DonGiaBan.ToString() != null && SoLuongTon.ToString() != null && LanTaiBan.ToString() != null && SoTrang.ToString() != null && LoaiBia != null && NgayXuatBan != null))
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                if (DataProvider.Ins.DB.CHITIETSACH.Find(MaSach) == null)
                {
                    var chitietsach = new Model.CHITIETSACH() { MaSach = SelectedSach.MaSach, TenSach = TenSach, DonGiaBan = DonGiaBan, SoLuongTon = SoLuongTon, LanTaiBan = LanTaiBan, SoTrang = SoTrang, LoaiBia = LoaiBia, NgayXuatBan = NgayXuatBan };

                    DataProvider.Ins.DB.CHITIETSACH.Add(chitietsach);
                    DataProvider.Ins.DB.SaveChanges();

                    ListChiTietSach.Add(chitietsach);
                    MessageBox.Show("Chi tiết sách " + MaSach + " đã thêm thành công !!!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    SelectedSach = null;
                    SelectedItem = null;
                }
                else
                {
                    MessageBox.Show("Mã sách " + MaSach + " đã tồn tại chi tiết sách !!! ", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if ((SelectedSach == null || TenSach == null || DonGiaBan.ToString() == null || SoLuongTon.ToString() == null) || LanTaiBan.ToString() == null || SoTrang.ToString() == null || LoaiBia == null || NgayXuatBan == null)
                    return false;

                var displayList = DataProvider.Ins.DB.CHITIETSACH.Where(x => x.MaSach == SelectedItem.MaSach);
                if (displayList != null && displayList.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                var chitietsach = DataProvider.Ins.DB.CHITIETSACH.Where(x => x.MaSach == SelectedItem.MaSach).SingleOrDefault();
                //chitietsach.MaSach = SelectedSach.MaSach;
                chitietsach.TenSach = TenSach;
                chitietsach.DonGiaBan = DonGiaBan;
                chitietsach.SoLuongTon = SoLuongTon;
                chitietsach.LanTaiBan = LanTaiBan;
                chitietsach.SoTrang = SoTrang;
                chitietsach.LoaiBia = LoaiBia;
                chitietsach.NgayXuatBan = NgayXuatBan;
                DataProvider.Ins.DB.SaveChanges();
                SelectedItem.MaSach = MaSach;
                MessageBox.Show("Chi tiết sách " + TenSach + " đã sửa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);

                MaSach = null;
                SelectedSach = null;
                SelectedItem = null;
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.CHITIETSACH.Where(x => x.MaSach == SelectedItem.MaSach);
                if (displayList != null && displayList.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                var chitietsach = DataProvider.Ins.DB.CHITIETSACH.Where(x => x.MaSach == SelectedItem.MaSach).FirstOrDefault();

                DataProvider.Ins.DB.CHITIETSACH.Remove(chitietsach);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Sách " + TenSach + " đã xóa thành công !!!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                ListChiTietSach.Remove(chitietsach);
                MaSach = null;
                SelectedSach = null;
                SelectedItem = null;
            });
        }
    }
}