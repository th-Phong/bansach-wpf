   M S B A M L   `   `   `  ����B  >QL_SACH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QL_SACH.ViewQL_SACH.View  5          QL_SACH.View.TacGiaView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:QL_SACH.View     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      -   5        $
��auto��5	      $
��auto��5
         TacGiaVM  � DataContext#  [  5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5      .��5      � .+�5   
   � $��0q�6    � RowDefinitions 5      �� 5      $��50 �6    �� 5      $
��Auto �6    �� 5      .+�5      #  MaterialDesignThemes.Wpf.Card  .��5      � $��0��6   .+�5      �� $��Center=�5      $��Center=�5      $��17(�5      $
��Bold"�5      " Quản lý danh sách Tác giả5!      5"      5#      � 5%      $��1��6    5&      �� 5'      $
��Auto �6$   �� 5(      $
��Auto �6$   �� 5)      $
��Auto �6$   �� 5*      $
��Auto �6$    � ColumnDefinitions 5,      �� 5-      �� 5.      $��50 �6'   �� 5/      �� 50      $
��Auto �6'   .+�53      �� -   5         ��Name$ 
tbMaTacGia��54      $��0��55      $��0��56      $
��50,4q�57      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Mã tác giả��59      $��18(�5:       % !MaterialDesignFloatingHintTextBox#��[ 5;      {�58      �� *	IsEnabled+��5<      �� *
MaTacGia+ �� UpdateSourceTrigger$ PropertyChanged=��� 5=      -   5        $ tbTenTacGia��5>      $��0��5?      $��2��5@      $
��50,4q�5A      $ Tên tác giả��5B      $��18(�5C      #��[ 5D      ��5E      �� *	TenTacGia+$ PropertyChanged=��� 5G      -   5        $ 	tbQueQuan��5H      $��1��5I      $��0��5J      $
��50,4q�5K      $ 
Quê quán��5L      $��18(�5M      #��[ 5N      ��5O      �� *	QueQuan+$ PropertyChanged=��� 5Q      -   5         ��Name$ cbPhai��5R      $��1��5S      $��2��5T      $
��50,4q�5U      $ Phái��5V      $��18(�5W      	 �� 
IsEditable	 .   & "MaterialDesignFloatingHintComboBox#��[ 5Y      
 �� Text
 5Z      �� *Phai+$ PropertyChanged=�(  "System.Windows.Controls.DatePicker  5[      -   5          Name$ 
dpNgaySinh��5\      $��2��5]      $��0��5^      $
��50,4q�5_      $ Ngày sinh��5`      $��18(�5a       ( $MaterialDesignFloatingHintDatePicker#��[ 5c         SelectedDate 5b      �� *
NgaySinh+ �� StringFormat$ 
dd/MM/yyyy��$ PropertyChanged=�5c      �� 5e      -   5         ��Name$ btThem��5f      $��0��5g      $��3��5h      $��8,4,8,0q�5i      
��� � �
��� � �$
��Left=�5l       * &MaterialDesignFloatingActionMiniButton#��[ 5n       � ToolTip$ Thêm tác giả��5o      ��5m      �� *
AddCommand+.��5p      '  !MaterialDesignThemes.Wpf.PackIcon  $��24��5q      $��24��5r         Kind$
 Plus=�5s      5t      �� 5u      -   5        $ btSua��5v      $��1��5w      $��3��5x      $��8,4,8,0q�5y      ���#ffa000
��� ���$
��Left=�5|      #��[ 5~      $ Chỉnh sửa tác giả��5      ��5}      �� *EditCommand+.��5�        $��24��5�      $��24��5�      $ 
LeadPencil=�5�      5�      �� 5�      -	   5        $ btXoa��5�      $��2��5�      $��3��5�      $��8,4,8,0q�5�      
���  ��
���  ��$
��Left=�5�      #��[ 5�      $ Xóa tác giả��5�      ��5�      �� *DeleteCommand+.��5�        $��24��5�      $��24��5�      $ Delete=�5�      5�      5�      � 5�      $��2��6   $��10,20,10,10q�6    .+�5�        $��2��5�      $��5q�5�      $��Stretch=�5�      .��5�      �� -
   5         ��Name$ 
listTacGia��5�      ��5�      �� *
ListTacGia+ �� SelectedItem 6<   �� *SelectedItem+ �� Mode$ OneWayToSource=� �� View 5�      �� 5�      .P�5�   "   �� $��Mã tác giả��6[    �� DisplayMemberBinding 61   �� *
MaTacGia+6[   �� 5�   "   $��Tên tác giả��6\    61   �� *	TenTacGia+6\   �� 5�   "   $��
Ngày sinh��6v    61   �� *
NgaySinh+$ 
dd/MM/yyyy��6v   �� 5�   "   $��
Quê quán��6Z    61   �� *	QueQuan+6Z   �� 5�   "   $��Phái��6W    61   �� *Phai+6W   5�      5�      5�      5�      5�      5�      5�      