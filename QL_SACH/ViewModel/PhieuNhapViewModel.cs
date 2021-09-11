using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using QL_SACH.Model;

namespace QL_SACH.ViewModel
{
    public class PhieuNhapViewModel : BaseViewModel
    {
        private ObservableCollection<PHIEUNHAPSACH> _ListPhieuNhap;
        public ObservableCollection<PHIEUNHAPSACH> ListPhieuNhap { get => _ListPhieuNhap; set { _ListPhieuNhap = value; OnPropertyChanged(); } }

        private ObservableCollection<NHANVIEN> _NhanVien;
        public ObservableCollection<NHANVIEN> NhanVien { get => _NhanVien; set { _NhanVien = value; OnPropertyChanged(); } }

        private string _SoPNS;
        public string SoPNS { get => _SoPNS; set { _SoPNS = value; OnPropertyChanged(); } }

        private DateTime? _NgayNhap;
        public DateTime? NgayNhap { get => _NgayNhap; set { _NgayNhap = value; OnPropertyChanged(); } }

        /// <summary>
        /// Khai báo Command
        /// </summary>
        public ICommand AddCommand { get; set; }

        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        /// <summary>
        /// Thay đổi giá trị trong control khi chọn một đối tượng trong ListView
        /// </summary>
        private Model.PHIEUNHAPSACH _SelectedItem;

        public Model.PHIEUNHAPSACH SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    SoPNS = SelectedItem.SoPNS;
                    SelectedNhanVien = SelectedItem.NHANVIEN;
                    NgayNhap = SelectedItem.NgayNhap;
                }
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

        public PhieuNhapViewModel()
        {
            ListPhieuNhap = new ObservableCollection<PHIEUNHAPSACH>(DataProvider.Ins.DB.PHIEUNHAPSACH);
            NhanVien = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIEN.Where(x => x.TrangThai.Equals("Đang đi làm")));

            AddCommand = new RelayCommand<object>((p) =>
            {
                if ((SelectedItem == null) && (SoPNS != null && SelectedNhanVien != null && NgayNhap != null))
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                if (DataProvider.Ins.DB.PHIEUNHAPSACH.Find(SoPNS) == null)
                {
                    var phieunhap = new Model.PHIEUNHAPSACH() { SoPNS = SoPNS, MaNV = SelectedNhanVien.MaNV, NgayNhap = NgayNhap };

                    DataProvider.Ins.DB.PHIEUNHAPSACH.Add(phieunhap);
                    DataProvider.Ins.DB.SaveChanges();

                    ListPhieuNhap.Add(phieunhap);
                    MessageBox.Show("Phiếu nhập: " + SoPNS + " đã thêm thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    SoPNS = null;
                    SelectedNhanVien = null;
                    NgayNhap = null;
                    SelectedItem = null;
                }
                else
                {
                    MessageBox.Show("Số phiếu nhập " + SoPNS + " đã tồn tại", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if ((SelectedNhanVien == null || NgayNhap == null) || SoPNS == null)
                    return false;

                var displayList = DataProvider.Ins.DB.PHIEUNHAPSACH.Where(x => x.SoPNS == SelectedItem.SoPNS);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;
            }, (p) =>
            {
                var phieunhap = DataProvider.Ins.DB.PHIEUNHAPSACH.Where(x => x.SoPNS == SelectedItem.SoPNS).SingleOrDefault();
                phieunhap.MaNV = SelectedNhanVien.MaNV;
                phieunhap.NgayNhap = SelectedItem.NgayNhap;
                DataProvider.Ins.DB.SaveChanges();
                //SelectedItem.MaNV = MaNV;
                MessageBox.Show("Phiếu nhập " + SoPNS + " đã sửa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);

                SoPNS = null;
                SelectedNhanVien = null;
                NgayNhap = null;
                SelectedItem = null;
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.PHIEUNHAPSACH.Where(x => x.SoPNS == SelectedItem.SoPNS);
                if (displayList != null && displayList.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                var phieunhap = DataProvider.Ins.DB.PHIEUNHAPSACH.Where(x => x.SoPNS == SelectedItem.SoPNS).FirstOrDefault();

                DataProvider.Ins.DB.PHIEUNHAPSACH.Remove(phieunhap);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Phiếu nhập " + SoPNS + " đã xóa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                ListPhieuNhap.Remove(phieunhap);

                SoPNS = null;
                SelectedNhanVien = null;
                NgayNhap = null;
                SelectedItem = null;
            });
        }
    }
}