using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using QL_SACH.Model;

namespace QL_SACH.ViewModel
{
    public class TacGiaViewModel : BaseViewModel
    {
        private ObservableCollection<TACGIA> _ListTacGia;
        public ObservableCollection<TACGIA> ListTacGia { get => _ListTacGia; set { _ListTacGia = value; OnPropertyChanged(); } }

        private string _MaTacGia;
        public string MaTacGia { get => _MaTacGia; set { _MaTacGia = value; OnPropertyChanged(); } }

        private string _TenTacGia;
        public string TenTacGia { get => _TenTacGia; set { _TenTacGia = value; OnPropertyChanged(); } }

        private DateTime? _NgaySinh;
        public DateTime? NgaySinh { get => _NgaySinh; set { _NgaySinh = value; OnPropertyChanged(); } }

        private string _QueQuan;
        public string QueQuan { get => _QueQuan; set { _QueQuan = value; OnPropertyChanged(); } }

        private string _Phai;
        public string Phai { get => _Phai; set { _Phai = value; OnPropertyChanged(); } }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private Model.TACGIA _SelectedItem;

        public Model.TACGIA SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    MaTacGia = SelectedItem.MaTacGia;
                    TenTacGia = SelectedItem.TenTacGia;
                    NgaySinh = SelectedItem.NgaySinh;
                    QueQuan = SelectedItem.QueQuan;
                    Phai = SelectedItem.Phai;
                }
            }
        }


        /// <summary>
        /// Làm mới dữ liệu trong các control
        /// </summary>
        public void Reset()
        {
            SelectedItem = null;
            MaTacGia = null;
            TenTacGia = null;
            NgaySinh = null;
            QueQuan = null;
            Phai = null;
        }
        public TacGiaViewModel()
        {
            ListTacGia = new ObservableCollection<TACGIA>(DataProvider.Ins.DB.TACGIA);

            //Thêm Tác giả
            AddCommand = new RelayCommand<object>((p) =>
            {
                //Bật tắt TextBox Mã sách
                if (SelectedItem == null)
                    IsEnabled = true;
                else
                    IsEnabled = false;
                //Bật tắt nút
                if ((SelectedItem == null) && (MaTacGia != null))// && TenTacGia != null && NgaySinh != null && QueQuan != null && Phai != null))
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                if (DataProvider.Ins.DB.TACGIA.Find(MaTacGia) == null)
                {
                    if (CheckNull() == false)
                    {
                        var AddRecord = MessageBox.Show("Bạn có chắc chắn muốn thêm tác giả " + TenTacGia + " không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (AddRecord == MessageBoxResult.Yes)
                        {
                            var tacgia = new Model.TACGIA() { MaTacGia = MaTacGia, TenTacGia = TenTacGia, NgaySinh = NgaySinh, QueQuan = QueQuan, Phai = Phai };

                            DataProvider.Ins.DB.TACGIA.Add(tacgia);
                            DataProvider.Ins.DB.SaveChanges();

                            ListTacGia.Add(tacgia);
                            MessageBox.Show("Tác giả " + TenTacGia + " đã thêm thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                            Reset();
                        }
                    }
                    else
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin tất cả thông tin !!!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show("Mã tác giả " + MaTacGia + " đã tồn tại", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    SelectedItem = null;
                }
            });
            //Sửa tác giả
            EditCommand = new RelayCommand<object>((p) =>
            {
                if ((TenTacGia == null || NgaySinh == null || QueQuan == null || Phai == null) || SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.TACGIA.Where(x => x.MaTacGia == SelectedItem.MaTacGia);
                if (displayList != null)// && displayList.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                if (TenTacGia != null && NgaySinh != null && QueQuan != null && Phai != null)
                {
                    var FixRecord = MessageBox.Show("Bạn có chắc chắn muốn sửa Thông tin tác giả " + SelectedItem.TenTacGia + " không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (FixRecord == MessageBoxResult.Yes)
                    {
                        var tacgia = DataProvider.Ins.DB.TACGIA.Where(x => x.MaTacGia == SelectedItem.MaTacGia).SingleOrDefault();
                        tacgia.TenTacGia = TenTacGia;
                        tacgia.NgaySinh = NgaySinh;
                        tacgia.QueQuan = QueQuan;
                        tacgia.Phai = Phai;
                       
                        DataProvider.Ins.DB.SaveChanges();
                        SelectedItem.MaTacGia = MaTacGia;
                        MessageBox.Show("Tác giả " + TenTacGia + " đã sửa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        Reset();
                    }
                }
                else
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin tất cả thông tin !!!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            });
            //Xóa tác giả
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.TACGIA.Where(x => x.MaTacGia == SelectedItem.MaTacGia);
                if (displayList != null && displayList.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                var DeleteRecord = MessageBox.Show("Bạn có chắc chắn muốn xóa Thông tin tác giả " + SelectedItem.TenTacGia + " không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
               
                if (DeleteRecord == MessageBoxResult.Yes)
                {
                    var tacgia = DataProvider.Ins.DB.TACGIA.Where(x => x.MaTacGia == SelectedItem.MaTacGia).FirstOrDefault();
                    var tacgia_in_sach = DataProvider.Ins.DB.SACH.Where(x => x.MaTacGia == SelectedItem.MaTacGia).FirstOrDefault();
                    if (tacgia_in_sach != null)
                    {
                        MessageBox.Show("Tác giả " + TenTacGia + " đã tồn tại trong dữ liệu sách đã nhập trước đó - Vui lòng kiểm tra lại !!!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        DataProvider.Ins.DB.TACGIA.Remove(tacgia);
                        DataProvider.Ins.DB.SaveChanges();
                        MessageBox.Show("Tác giả " + TenTacGia + " đã xóa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        ListTacGia.Remove(tacgia);
                        Reset();
                    }
                }
            });
        }
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
        //Kiểm tra rỗng
        public bool CheckNull()
        {
            if (MaTacGia != null && TenTacGia != null && NgaySinh != null && QueQuan != null && Phai != null)
                return false;
            else
                return true;
        }
    }
}