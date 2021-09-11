using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using QL_SACH.Model;

namespace QL_SACH.ViewModel
{
    public class TaiKhoanViewModel : BaseViewModel
    {
        private ObservableCollection<TAIKHOAN> _ListTaiKhoan;
        public ObservableCollection<TAIKHOAN> ListTaiKhoan { get => _ListTaiKhoan; set { _ListTaiKhoan = value; OnPropertyChanged(); } }

        private ObservableCollection<PHANQUYEN> _PhanQuyen;
        public ObservableCollection<PHANQUYEN> PhanQuyen { get => _PhanQuyen; set { _PhanQuyen = value; OnPropertyChanged(); } }

        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }

        private string _Pass;
        public string Pass { get => _Pass; set { _Pass = value; OnPropertyChanged(); } }

        /// <summary>
        /// Khai báo Command
        /// </summary>
        public ICommand AddCommand { get; set; }

        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        /// <summary>
        /// Thay đổi giá trị trong control khi chọn một đối tượng trong ListView
        /// </summary>
        private Model.TAIKHOAN _SelectedItem;

        public Model.TAIKHOAN SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    UserName = SelectedItem.UserName;
                    Pass = SelectedItem.Pass;
                    SelectedPhanQuyen = SelectedItem.PHANQUYEN;
                }
            }
        }

        private Model.PHANQUYEN _SelectedPhanQuyen;

        public Model.PHANQUYEN SelectedPhanQuyen
        {
            get => _SelectedPhanQuyen;
            set
            {
                _SelectedPhanQuyen = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Các xử lý chính
        /// </summary>
        public TaiKhoanViewModel()
        {
            ListTaiKhoan = new ObservableCollection<TAIKHOAN>(DataProvider.Ins.DB.TAIKHOAN);
            PhanQuyen = new ObservableCollection<PHANQUYEN>(DataProvider.Ins.DB.PHANQUYEN);

            AddCommand = new RelayCommand<object>((p) =>
            {
                if ((SelectedItem == null) && (UserName != null && Pass != null && SelectedPhanQuyen != null))
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                if (DataProvider.Ins.DB.TAIKHOAN.Find(UserName) == null)
                {
                    var taikhoan = new Model.TAIKHOAN() { UserName = UserName, MaQuyen = SelectedPhanQuyen.MaQuyen, Pass = Pass };

                    DataProvider.Ins.DB.TAIKHOAN.Add(taikhoan);
                    DataProvider.Ins.DB.SaveChanges();

                    ListTaiKhoan.Add(taikhoan);
                    MessageBox.Show("UserName " + UserName + " đã thêm thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    UserName = null;
                    Pass = null;
                    SelectedPhanQuyen = null;
                    SelectedItem = null;
                }
                else
                {
                    MessageBox.Show("UserName " + UserName + " đã tồn tại", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if ((SelectedPhanQuyen == null || UserName == null || Pass == null))
                    return false;

                var displayList = DataProvider.Ins.DB.TAIKHOAN.Where(x => x.UserName == SelectedItem.UserName);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;
            }, (p) =>
            {
                var taikhoan = DataProvider.Ins.DB.TAIKHOAN.Where(x => x.UserName == SelectedItem.UserName).SingleOrDefault();
                taikhoan.Pass = Pass;
                taikhoan.MaQuyen = SelectedPhanQuyen.MaQuyen;

                DataProvider.Ins.DB.SaveChanges();
                SelectedItem.UserName = UserName;
                MessageBox.Show("UserName " + UserName + " đã sửa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);

                UserName = null;
                Pass = null;
                SelectedPhanQuyen = null;
                SelectedItem = null;
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.TAIKHOAN.Where(x => x.UserName == SelectedItem.UserName);
                if (displayList != null && displayList.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                var taikhoan = DataProvider.Ins.DB.TAIKHOAN.Where(x => x.UserName == SelectedItem.UserName).FirstOrDefault();

                DataProvider.Ins.DB.TAIKHOAN.Remove(taikhoan);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("UserName " + UserName + " đã xóa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                ListTaiKhoan.Remove(taikhoan);
                UserName = null;
                Pass = null;
                SelectedPhanQuyen = null;
                SelectedItem = null;
            });
        }
    }
}