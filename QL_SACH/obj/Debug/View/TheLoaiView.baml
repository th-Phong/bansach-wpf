   M S B A M L   `   `   `  ����B  >QL_SACH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QL_SACH.ViewQL_SACH.View  5          QL_SACH.View.TheLoaiView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:QL_SACH.View     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      $
��auto��5      $
��auto��5	         	TheLoaiVM  � DataContext#  [  5
      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5      .��5      � .+�5   
   � $��0q�6    � RowDefinitions 5      �� 5      $��50 �6    �� 5      $
��Auto �6    �� 5      .+�5      #  MaterialDesignThemes.Wpf.Card  .��5      � $��0��6   .+�5      �� $��Center=�6    $��Center=�5       $��17(�5       $
��Bold"�5       *(Quản lý danh sách Thể loại sách5      5       5!      � 5#      $��1��6    5$      �� 5%      $
��Auto �6$   �� 5&      $
��Auto �6$   �� 5'      $
��Auto �6$   �� 5(      $
��Auto �6$    � ColumnDefinitions 5*      �� 5+      �� 5,      $��50 �6'   �� 5-      �� 5.      $
��Auto �6'   .+�51      �� -   5         ��Name$ tbMaTheLoai��51      $��1��52      $��0��53      $
��50,4q�54      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Mã thể loại��55      $��18(�56       % !MaterialDesignFloatingHintTextBox#��[ 57      ��58      �� *	MaTheLoai+ �� UpdateSourceTrigger$ PropertyChanged=��� 59      -   5        $ tbTenTheLoai��59      $��1��5:      $��2��5;      $
��50,4q�5<      $ Tên thể loại��5=      $��18(�5>      #��[ 5?      ��5@      �� *
TenTheLoai+$ PropertyChanged=��� 5B      -   5         ��Name$ btThem��5B      $��0��5C      $��3��5D      $��8,4,8,0q�5E      $
��Left=�5F       * &MaterialDesignFloatingActionMiniButton#��[ 5H      	 � ToolTip$	 Thêm thể loại��5I      ��5G      �� *
AddCommand+.��5J      '  !MaterialDesignThemes.Wpf.PackIcon  $��24��6.   $��24��5K   .   
   Kind$

 Plus=�5L   .   5M      �� 5N      -   5        $ btSua��5N      $��1��5O      $��3��5P      $��8,4,8,0q�5Q      $
��Left=�5R      #��[ 5T      $ 	 Chỉnh sửa thể loại��5U      ��5S      �� *EditCommand+.��5V        $��24��6.   $��24��5W   .   $
 
LeadPencil=�5X   .   5Y      �� 5Z      -   5        $ btXoa��5Z      $��2��5[      $��3��5\      $��8,4,8,0q�5]      $
��Left=�5^      #��[ 5`      $	 Xóa thể loại��5a      ��5_      �� *DeleteCommand+.��5b        $��24��6.   $��24��5c   .   $
 Delete=�5d   .   5e      5f      � 5h      $��2��6   $��10,20,10,10q�5i      .+�5j        $��2��6&   $��5q�5k   &   $��Stretch=�5l   &   .��5n      �� ��6   �� *ListTheLoai+ �� SelectedItem 5o      �� *SelectedItem+ �� Mode$ OneWayToSource=� �� View 5p      �� 5q      .P�5r   "   ��  �� Width$	 250��61   $��Mã thể loại��5t   1    �� DisplayMemberBinding 5s   1   �� *	MaTheLoai+5t   1   �� 5u   "   $��Tên thể loại��5v   1    5u   1   �� *
TenTheLoai+5v   1   5w      5y      5z      5{      5|      5}      5~      