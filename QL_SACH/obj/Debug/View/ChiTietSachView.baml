   M S B A M L   `   `   `  ����B  >QL_SACH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QL_SACH.ViewQL_SACH.View  5      "    QL_SACH.View.ChiTietSachView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:QL_SACH.View     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      $
��auto��5	      $
��auto��5
         ChiTietSachVM  � DataContext#  [  5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5      .��5      � $��0q�6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $
��Auto �6   �� 5      .+�5   
   #  MaterialDesignThemes.Wpf.Card  .��5      � $��0��6   .+�5      �� $��Center=�5      $��Center=�5      $��17(�5      $
��Bold"�5      Quản lý Chi tiết sách5       5!      5"      � 5$   
   $��1��6    5%      �� 5&      $
��Auto �6    �� 5'      $
��Auto �6    �� 5(      $
��Auto �6    �� 5)      $
��Auto �6     � ColumnDefinitions 5+      �� 5,      �� 5-      $��50 �6#   �� 5.      �� 5/      $
��Auto �6#   .+�52      �� -   5         ��Name$ tbMaSach��53      $��0��54      $��0��55      $
��50,4q�56      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Mã sách��57      $��18(�58       % !MaterialDesignFloatingHintTextBox#��[ 5:      {�59      ��  �� Path$ 
IsSelected� �� RelativeSource �� *FindAncestor+	 �� AncestorType"	 ����5;      �� *MaSach+
 �� UpdateSourceTrigger$
 PropertyChanged=��� 5<      -   5         ��Name$ 
cbMaTacGia��5=      $��0��5>      $��2��5?      $
��50,4q�5@      $ 
Tác giả��5A       �� DisplayMemberPath$ 	TenTacGia��5B      $��18(�5C       �� 
IsEditable .   & "MaterialDesignFloatingHintComboBox#��[ 5G      ��5E      �� *TacGia+ �� SelectedItem 5F      �� *SelectedTacGia+ �� Mode$ TwoWay=�$
 PropertyChanged=�5G      �� 5I      -   5        $ 	cbTheLoai��5J      $��1��5K      $��0��5L      $
��50,4q�5M      $ Thể loại��5N      $ 
TenTheLoai��5O      $��18(�5P       .  #��[ 5T      ��5R      �� *	TheLoai+ 5S      �� *SelectedTheLoai+$ TwoWay=�$
 PropertyChanged=�5T      �� 5U      -   5        $ cbNhaXuatBan��5V      $��1��5W      $��2��5X      $
��50,4q�5Y      $ Nhà xuất bản��5Z      $ TenNhaXuatBan��5[      $��18(�5\       .  #��[ 5`      ��5^      �� *
NhaXuatBan+ 5_      �� *SelectedNhaXuatBan+$ TwoWay=�$
 PropertyChanged=�5`      �� 5a      -   5        $ cbKhuyenMai��5b      $��2��5c      $��0��5d      $
��50,4q�5e      $ Khuyến mãi��5f      $ TenChuongTrinh��5g      $��18(�5h       .  #��[ 5l      ��5j      �� *	KhuyenMai+ 5k      �� *SelectedKhuyenMai+$ TwoWay=�$
 PropertyChanged=�5l      �� 5n      -   5         ��Name$ btThem��5o      $��0��5p      $��3��5q      $��8,4,8,0q�5r      $
��Left=�5s       * &MaterialDesignFloatingActionMiniButton#��[ 5u       � ToolTip$ Thêm sách��5v      ��5t      �� *
AddCommand+.��5w      '  !MaterialDesignThemes.Wpf.PackIcon  $��24��5x      $��24��5y         Kind$
 Plus=�5z      5|      �� 5}      -   5        $ btSua��5~      $��1��5      $��3��5�      $��8,4,8,0q�5�      $
��Left=�5�      #��[ 5�      $ Chỉnh sửa sách��5�      ��5�      �� *EditCommand+.��5�        $��24��5�      $��24��5�      $ 
LeadPencil=�5�      5�      �� 5�      -   5        $ btXoa��5�      $��2��5�      $��3��5�      $��8,4,8,0q�5�      $
��Left=�5�      #��[ 5�      $ 
Xóa sách��5�      ��5�      �� *DeleteCommand+.��5�        $��24��5�      $��24��5�      $ Delete=�5�      5�      5�      � 5�   
   $��2��6   $��10,20,10,10q�6   .+�5�        $��2��5�      $��5q�5�      $��Stretch=�5�      .��5�      �� ��6   �� *
ListSach+ 6<   �� *SelectedItem+$ OneWayToSource=� �� View 5�      �� 5�      .P�5�      �� $��	Mã sách��6U    �� DisplayMemberBinding 6-   �� *MaSach+6U   �� 5�      $��
Tác giả��6_    6-   �� *TACGIA.TenTacGia+6_   �� 5�      $��Thể loại��6a    6-   �� *THELOAI.TenTheLoai+6a   �� 5�      $��Nhà xuất bản��6g    6-   �� *NHAXUATBAN.TenNhaXuatBan+6g   �� 5�      $��Khuyên mãi��6g    6-   �� *KHUYENMAI.TenChuongTrinh+6g   5�      5�      5�      5�      5�      5�      