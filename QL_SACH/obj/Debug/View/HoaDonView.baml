   M S B A M L   `   `   `  ����B  >QL_SACH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QL_SACH.ViewQL_SACH.View  5          QL_SACH.View.HoaDonView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:QL_SACH.View     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      -   5        $
��auto��5	      $
��auto��5
         HoaDonVM  � DataContext#  [  5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5      .��5      � .+�5   
   � -   5        $��0q�5       � RowDefinitions 5      �� 5      $��50 �6    �� 5      $
��Auto �6    �� 5      .+�5      #  MaterialDesignThemes.Wpf.Card  .��5      � $��0��6   .+�5      �� $��Center=�5      $��Center=�5      $��17(�5      $
��Bold"�5       " Quản lý danh sách Hóa Đơn5"      5#      5$      � 5&      $��1��6    5'      �� 5(      $
��Auto �6$   �� 5)      $
��Auto �6$   �� 5*      $
��Auto �6$   �� 5+      $
��Auto �6$    � ColumnDefinitions 5-      �� 5.      �� 5/      $��50 �6'   �� 50      �� 51      $
��Auto �6'   .+�54      �� -   5         ��Name$ 
tbMaHoaDon��55      $��0��56      $��0��57      $
��50,4q�58      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Mã hóa đơn��59      $��18(�5:       % !MaterialDesignFloatingHintTextBox#��[ 5;      ��5<      �� *SoHD+ �� UpdateSourceTrigger$ PropertyChanged=��� 5=      -   5         ��Name$ 
cbNhanVien��5>      $��0��5?      $��2��5@      $
��50,4q�5A      $ Nhân viên��5B      	 �� DisplayMemberPath$	 TenNV��5C      $��18(�5D      
 �� IsTextSearchEnabled
 .  & "MaterialDesignFloatingHintComboBox#��[ 5H      ��5F      �� *
NhanVien+ �� SelectedItem 5G      �� *SelectedNhanVien+ �� Mode$ TwoWay=�$ PropertyChanged=�5H      �� 5J      -   5        $ cbKhachHang��5K      $��1��5L      $��0��5M      $
��50,4q�5N      $ Khách hàng��5O      $	 TenKhachHang��5P      $��18(�5Q      
 . #��[ 5U      ��5S      �� *	KhachHang+ 5T      �� *SelectedKhachHang+$ TwoWay=�$ PropertyChanged=�5U      (  "System.Windows.Controls.DatePicker  5W      -   5          Name$ dpHoaDon��5X      $��1��5Y      $��2��5Z      $
��50,4q�5[      $ Ngày hóa đơn��5\      $��18(�5]       ( $MaterialDesignFloatingHintDatePicker#��[ 5_         SelectedDate 5^      �� *
NgayHoaDon+ �� StringFormat$ 
dd/MM/yyyy��$ PropertyChanged=�5_      �� 5a      -   5        $ cbTrangThai��5b      $��2��5c      $��0��5d      $
��50,4q�5e      $ Trạng thái��5f      $��18(�5g       �� 
IsEditable .  
 . #��[ 5j       �� Text 5k      �� *	TrangThai+$ PropertyChanged=��� 5m      -   5         ��Name$ btThem��5n      $��0��5o      $��3��5p      $��8,4,8,0q�5q      $
��Left=�5r      
��� � �
��� � � * &MaterialDesignFloatingActionMiniButton#��[ 5v       � ToolTip$ Thêm hóa đơn��5w      ��5u      �� *
AddCommand+.��5x      '  !MaterialDesignThemes.Wpf.PackIcon  $��24��5y      $��24��5z         Kind$
 Plus=�5{      5|      �� 5}      -	   5        $ btSua��5~      $��1��5      $��3��5�      $��8,4,8,0q�5�      $
��Left=�5�      ���#ffa000
��� ���#��[ 5�      $ Chỉnh sửa hóa đơn��5�      ��5�      �� *EditCommand+.��5�        $��24��5�      $��24��5�      $ 
LeadPencil=�5�      5�      �� 5�      -
   5        $ btXoa��5�      $��2��5�      $��3��5�      $��8,4,8,0q�5�      $
��Left=�5�      
���  ��
���  ��#��[ 5�      $ Xóa hóa đơn��5�      ��5�      �� *DeleteCommand+.��5�        $��24��5�      $��24��5�      $ Delete=�5�      5�      5�      � 5�      $��2��6   $��10,20,10,10q�6    .+�5�        $��2��5�      $��5q�5�      $��Stretch=�5�      .��5�      �� -   5         ��Name$ 
listHoaDon��5�      ��5�      �� *
ListHoaDon+ 5�      �� *SelectedItem+$ OneWayToSource=� �� View 5�      �� 5�      .P�5�   "   �� $��Mã hóa đơn��6W    �� DisplayMemberBinding 61   �� *SoHD+6W   �� 5�   "   $��Tên nhân viên��6a    61   �� *NHANVIEN.TenNV+6a   �� 5�   "   $��Tên khách hàng��6i    61   �� *KHACHHANG.TenKhachHang+6i   �� 5�   "   $��Ngày hóa đơn��6x    61   �� *
NgayHoaDon+$ 
dd/MM/yyyy��6x   �� 5�   "   $��Trạng thái��6\    61   �� *	TrangThai+6\   5�      5�      5�      5�      5�      5�      5�      