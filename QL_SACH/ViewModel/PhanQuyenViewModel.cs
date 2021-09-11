using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using QL_SACH.Model;

namespace QL_SACH.ViewModel
{
    public class PhanQuyenViewModel : BaseViewModel
    {
        private ObservableCollection<PHANQUYEN> _ListPhanQuyen;
        public ObservableCollection<PHANQUYEN> ListPhanQuyen { get => _ListPhanQuyen; set { _ListPhanQuyen = value; OnPropertyChanged(); } }
        private string _MaQuyen;
        public string MaQuyen { get => _MaQuyen; set { _MaQuyen = value; OnPropertyChanged(); } }

        private string _TenQuyen;
        public string TenQuyen { get => _TenQuyen; set { _TenQuyen = value; OnPropertyChanged(); } }

        private string _Mota;
        public string Mota { get => _Mota; set { _Mota = value; OnPropertyChanged(); } }

        /// <summary>
        /// Khai báo Command
        /// </summary>
        public ICommand AddCommand { get; set; }

        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private Model.PHANQUYEN _SelectedItem;

        public Model.PHANQUYEN SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    MaQuyen = SelectedItem.MaQuyen;
                    TenQuyen = SelectedItem.TenQuyen;
                    Mota = SelectedItem.Mota;
                }
            }
        }

        /// <summary>
        /// Các xử lý chính
        /// </summary>
        public PhanQuyenViewModel()
        {
            ListPhanQuyen = new ObservableCollection<PHANQUYEN>(DataProvider.Ins.DB.PHANQUYEN);

            AddCommand = new RelayCommand<object>((p) =>
            {
                if ((SelectedItem == null) && (MaQuyen != null && TenQuyen != null && Mota != null))
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                if (DataProvider.Ins.DB.PHANQUYEN.Find(MaQuyen) == null)
                {
                    var phanquyen = new Model.PHANQUYEN() { MaQuyen = MaQuyen, TenQuyen = TenQuyen, Mota = Mota };

                    DataProvider.Ins.DB.PHANQUYEN.Add(phanquyen);
                    DataProvider.Ins.DB.SaveChanges();

                    ListPhanQuyen.Add(phanquyen);
                    MessageBox.Show("Phân quyền " + TenQuyen + " đã thêm thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    MaQuyen = null;
                    TenQuyen = null;
                    Mota = null;
                    SelectedItem = null;
                }
                else
                {
                    MessageBox.Show("Mã quyền " + MaQuyen + " đã tồn tại", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (MaQuyen == null || TenQuyen == null || Mota == null)
                    return false;
                var displayList = DataProvider.Ins.DB.PHANQUYEN.Where(x => x.MaQuyen == SelectedItem.MaQuyen);
                if (displayList != null && displayList.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                var phanquyen = DataProvider.Ins.DB.PHANQUYEN.Where(x => x.MaQuyen == SelectedItem.MaQuyen).SingleOrDefault();
                phanquyen.TenQuyen = TenQuyen;
                phanquyen.Mota = Mota;
                DataProvider.Ins.DB.SaveChanges();
                //SelectedItem.MaKhachHang = MaKhachHang;
                MessageBox.Show("Phân quyền" + TenQuyen + " đã sửa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                MaQuyen = null;
                TenQuyen = null;
                Mota = null;
                SelectedItem = null;
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.PHANQUYEN.Where(x => x.MaQuyen == SelectedItem.MaQuyen);
                if (displayList != null && displayList.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                var phanquyen = DataProvider.Ins.DB.PHANQUYEN.Where(x => x.MaQuyen == SelectedItem.MaQuyen).FirstOrDefault();

                DataProvider.Ins.DB.PHANQUYEN.Remove(phanquyen);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Mã quyền " + MaQuyen + " đã xóa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                ListPhanQuyen.Remove(phanquyen);
                MaQuyen = null;
                TenQuyen = null;
                Mota = null;
                SelectedItem = null;
            });
        }
    }
}