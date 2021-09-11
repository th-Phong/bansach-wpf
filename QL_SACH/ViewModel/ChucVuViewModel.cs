using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using QL_SACH.Model;

namespace QL_SACH.ViewModel
{
    public class ChucVuViewModel : BaseViewModel
    {
        private ObservableCollection<ChucVu> _ListChucVu;
        public ObservableCollection<ChucVu> ListChucVu { get => _ListChucVu; set { _ListChucVu = value; OnPropertyChanged(); } }

        private string _MaChucVu;
        public string MaChucVu { get => _MaChucVu; set { _MaChucVu = value; OnPropertyChanged(); } }

        private string _TenChucVu;
        public string TenChucVu { get => _TenChucVu; set { _TenChucVu = value; OnPropertyChanged(); } }

        /// <summary>
        /// Khai báo Command
        /// </summary>
        public ICommand AddCommand { get; set; }

        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        /// <summary>
        /// Thay đổi giá trị trong control khi chọn một đối tượng trong ListView
        /// </summary>
        private Model.ChucVu _SelectedItem;

        public Model.ChucVu SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    MaChucVu = SelectedItem.MaChucVu;
                    TenChucVu = SelectedItem.TenChucVu;
                }
            }
        }

        /// <summary>
        /// Các xử lý chính
        /// </summary>
        public ChucVuViewModel()
        {
            ListChucVu = new ObservableCollection<ChucVu>(DataProvider.Ins.DB.ChucVu);

            AddCommand = new RelayCommand<object>((p) =>
            {
                if ((SelectedItem == null) && (MaChucVu != null && TenChucVu != null))
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                if (DataProvider.Ins.DB.ChucVu.Find(MaChucVu) == null)
                {
                    var chucvu = new Model.ChucVu() { MaChucVu = MaChucVu, TenChucVu = TenChucVu };

                    DataProvider.Ins.DB.ChucVu.Add(chucvu);
                    DataProvider.Ins.DB.SaveChanges();

                    ListChucVu.Add(chucvu);
                    MessageBox.Show("Chức vụ " + TenChucVu + " đã thêm thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    MaChucVu = null;
                    TenChucVu = null;
                    SelectedItem = null;
                }
                else
                {
                    MessageBox.Show("Mã chức vụ " + MaChucVu + " đã tồn tại", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (MaChucVu == null || TenChucVu == null)
                    return false;
                var displayList = DataProvider.Ins.DB.ChucVu.Where(x => x.MaChucVu == SelectedItem.MaChucVu);
                if (displayList != null && displayList.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                var chucvu = DataProvider.Ins.DB.ChucVu.Where(x => x.MaChucVu == SelectedItem.MaChucVu).SingleOrDefault();
                chucvu.TenChucVu = TenChucVu;
                DataProvider.Ins.DB.SaveChanges();
                //SelectedItem.MaKhachHang = MaKhachHang;
                MessageBox.Show("Chức vụ" + MaChucVu + " đã sửa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                MaChucVu = null;
                TenChucVu = null;
                SelectedItem = null;
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.ChucVu.Where(x => x.MaChucVu == SelectedItem.MaChucVu);
                if (displayList != null && displayList.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                var chucvu = DataProvider.Ins.DB.ChucVu.Where(x => x.MaChucVu == SelectedItem.MaChucVu).FirstOrDefault();

                DataProvider.Ins.DB.ChucVu.Remove(chucvu);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Chức vụ " + TenChucVu + " đã xóa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                ListChucVu.Remove(chucvu);
                MaChucVu = null;
                TenChucVu = null;
                SelectedItem = null;
            });
        }
    }
}