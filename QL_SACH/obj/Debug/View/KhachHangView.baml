   M S B A M L   `   `   `  ����B  >QL_SACH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QL_SACH.ViewQL_SACH.View  5           QL_SACH.View.KhachHangView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:QL_SACH.View     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      $
��auto��5      $
��auto��5	         KhachHangVM  � DataContext#  [  5
      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5      .��5      � .+�5   
   � $��0q�6    � RowDefinitions 5      �� 5      $��50 �6    �� 5      $
��Auto �6    �� 5      .+�5      #  MaterialDesignThemes.Wpf.Card  .��5      � $��0��6   .+�5      �� $��Center=�6    $��Center=�5       $��17(�5       $
��Bold"�5       $"Quản lý danh sách Khách Hàng5      5      5       � 5"      $��1��6    5#      �� 5$      $
��Auto �6$   �� 5%      $
��Auto �6$   �� 5&      $
��Auto �6$   �� 5'      $
��Auto �6$    � ColumnDefinitions 5)      �� 5*      �� 5+      $��50 �6'   �� 5,      �� 5-      $��50 �6'   �� 5.      �� 5/      $
��Auto �6'   .+�52      �� -   5         ��Name$ tbMaKH��52      $��0��53      $��0��54      $
��50,4q�55      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Mã khách hàng��56      $��18(�57       % !MaterialDesignFloatingHintTextBox#��[ 58      ��59      �� *MaKhachHang+ �� UpdateSourceTrigger$ PropertyChanged=��� 5;      -   5        $ tbTenKH��5;      $��0��5<      $��2��5=      $
��50,4q�5>      $ Tên khách hàng��5?      $��18(�5@      #��[ 5A      ��5B      �� *TenKhachHang+$ PropertyChanged=��� 5D      -   5         ��Name$ cbPhai��5D      $��0��5E      $��4��5F      $
��50,4q�5G      $ Phái��5H      $��18(�5I      	 �� 
IsEditable	 .   & "MaterialDesignFloatingHintComboBox#��[ 5K      
 �� Text
 5L      �� *Phai+$ PropertyChanged=��� 5N      -   5        $ tbDiaChi��5N      $��1��5O      $��0��5P      $
��50,4q�5Q      $ Địa chỉ��5R      $��18(�5S      #��[ 5T      ��5U      �� *DiaChi+$ PropertyChanged=��� 5V      -   5        $ tbSDT��5V      $��1��5W      $��2��5X      $
��50,4q�5Y      $ Số điện thoại��5Z      $��18(�5[      #��[ 5\      ��5]      �� *SDT+$ PropertyChanged=��� 5^      -   5        $ tbEmail��5^      $��1��5_      $��4��5`      $
��50,4q�5a      $ Email��5b      $��18(�5c      #��[ 5d      ��5e      �� *Email+$ PropertyChanged=�(  "System.Windows.Controls.DatePicker  5g      -   5          Name$ 
dpNgaySinh��5g      $��2��5h      $��0��5i      $
��50,4q�5j      $ Ngày sinh��5k      $��18(�5l       ( $MaterialDesignFloatingHintDatePicker#��[ 5n         SelectedDate 5m      �� *
NgaySinh+ �� StringFormat$ 
dd/MM/yyyy��$ PropertyChanged=�5n      �� 5p      -   5         ��Name$ btThem��5p      $��0��5q      $��5��5r      $��8,4,8,0q�5s      $
��Left=�5t      
��� � �
��� � � * &MaterialDesignFloatingActionMiniButton#��[ 5x       � ToolTip$ Thêm khách hàng��5y      ��5w      �� *
AddCommand+.��5z      '  !MaterialDesignThemes.Wpf.PackIcon  $��24��6.   $��24��5{   .      Kind$
 Plus=�5|   .   5}      �� 5~      -	   5        $ btSua��5~      $��1��5      $��5��5�      $��8,4,8,0q�5�      $
��Left=�5�      ���#ffa000
��� ���#��[ 5�      $+ %Chỉnh sửa thông tin khách hàng��5�      ��5�      �� *EditCommand+.��5�        $��24��6.   $��24��5�   .   $ 
LeadPencil=�5�   .   5�      �� 5�      -
   5        $ btXoa��5�      $��2��5�      $��5��5�      $��8,4,8,0q�5�      $
��Left=�5�      
���  ��
���  ��#��[ 5�      $ Xóa khách hàng��5�      ��5�      �� *DeleteCommand+.��5�        $��24��6.   $��24��5�   .   $ Delete=�5�   .   5�      5�      � 5�      $��2��6   $��10,20,10,10q�5�      .+�5�        $��2��6&   $��5q�5�   &   $��Stretch=�5�   &   .��5�      �� -   5         ��Name$ listKhachHang��5�      ��5�      �� *ListKhachHang+ �� SelectedItem 5�      �� *SelectedItem+ �� Mode$ OneWayToSource=� �� View 5�      �� 5�      .P�5�   "   �� $��Mã khách hàng��5�   1    �� DisplayMemberBinding 5�   1   �� *MaKhachHang+5�   1   �� 5�   "   $��Tên khách hàng��5�   1    5�   1   �� *TenKhachHang+5�   1   �� 5�   "   $��Phái��5�   1    5�   1   �� *Phai+5�   1   �� 5�   "   $��Địa chỉ��5�   1    5�   1   �� *DiaChi+5�   1   �� 5�   "   $��Điện thoại��5�   1    5�   1   �� *SDT+5�   1   �� 5�   "   $��Email��5�   1    5�   1   �� *Email+5�   1   �� 5�   "   $��
Ngày sinh��5�   1    5�   1   �� *
NgaySinh+$ 
dd/MM/yyyy��5�   1   5�       � ContextMenu 5�      �� 5�      .@�5�   "   m� $	��Add��5�   +    m� Command 5�   +   �� *
AddCommand+5�   +   m� 5�   "   $
��Edit��5�   +    5�   +   �� *EditCommand+5�   +   m� 5�   "   $��Delete��5�   +    5�   +   �� *DeleteCommand+5�   +   5�      5�      5�      5�      5�      5�      5�      