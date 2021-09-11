using System.Linq;
using System.Windows.Input;
using QL_SACH.Model;
using System.Collections.ObjectModel;
using System.Windows;

namespace QL_SACH.ViewModel
{
    public class TheLoaiViewModel : BaseViewModel
    {
        private ObservableCollection<THELOAI> _ListTheLoai;
        public ObservableCollection<THELOAI> ListTheLoai { get => _ListTheLoai; set { _ListTheLoai = value; OnPropertyChanged(); } }

        private string _MaTheLoai;
        public string MaTheLoai { get => _MaTheLoai; set { _MaTheLoai = value; OnPropertyChanged(); } }

        private string _TenTheLoai;
        public string TenTheLoai { get => _TenTheLoai; set { _TenTheLoai = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private Model.THELOAI _SelectedItem;

        public Model.THELOAI SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    MaTheLoai = SelectedItem.MaTheLoai;
                    TenTheLoai = SelectedItem.TenTheLoai;
                }
            }
        }


        /// <summary>
        /// Làm mới dữ liệu trong các control
        /// </summary>
        public void Reset()
        {
            SelectedItem = null;
            MaTheLoai = null;
            TenTheLoai = null;
        }
        public TheLoaiViewModel()
        {
            ListTheLoai = new ObservableCollection<THELOAI>(DataProvider.Ins.DB.THELOAI);
            //Thêm Thể loại
            AddCommand = new RelayCommand<object>((p) =>
            {
                if ((SelectedItem == null) && (MaTheLoai != null && TenTheLoai != null))
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                if (DataProvider.Ins.DB.THELOAI.Find(MaTheLoai) == null)
                {
                    var theloai = new Model.THELOAI() { MaTheLoai = MaTheLoai, TenTheLoai = TenTheLoai };

                    DataProvider.Ins.DB.THELOAI.Add(theloai);
                    DataProvider.Ins.DB.SaveChanges();

                    ListTheLoai.Add(theloai);
                    MessageBox.Show("Thể loại " + TenTheLoai + " đã thêm thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);

                    Reset();
                }
                else
                {
                    MessageBox.Show("Mã thể loại " + MaTheLoai + " đã tồn tại", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });
            //Sửa Thể Loại
            EditCommand = new RelayCommand<object>((p) =>
            {
                if ((MaTheLoai == null || TenTheLoai == null) || SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.THELOAI.Where(x => x.MaTheLoai == SelectedItem.MaTheLoai);
                if (displayList != null && displayList.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                var FixRecord = MessageBox.Show("Bạn có chắc chắn muốn sửa Thể loại Sách: " + SelectedItem.TenTheLoai+ " không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (FixRecord == MessageBoxResult.Yes)
                {
                    var theloai = DataProvider.Ins.DB.THELOAI.Where(x => x.MaTheLoai == SelectedItem.MaTheLoai).SingleOrDefault();
                    theloai.TenTheLoai = TenTheLoai;
                    DataProvider.Ins.DB.SaveChanges();
                    SelectedItem.MaTheLoai = MaTheLoai;
                    MessageBox.Show("Thể loại " + TenTheLoai + " đã sửa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    //ListTheLoai = new ObservableCollection<THELOAI>(DataProvider.Ins.DB.THELOAI);
                    Reset();
                }
            });

            //Xóa thể loại
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.THELOAI.Where(x => x.MaTheLoai == SelectedItem.MaTheLoai);
                if (displayList != null && displayList.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                var DeleteRecord = MessageBox.Show("Bạn có chắc chắn muốn xóa Thể loại Sách: " + SelectedItem.TenTheLoai + " không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (DeleteRecord == MessageBoxResult.Yes)
                {
                    var theloai = DataProvider.Ins.DB.THELOAI.Where(x => x.MaTheLoai == SelectedItem.MaTheLoai).FirstOrDefault();
                    DataProvider.Ins.DB.THELOAI.Remove(theloai);
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Thể loại " + TenTheLoai + " đã xóa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    ListTheLoai.Remove(theloai);
                    Reset();
                }
            });
        }
    }
}