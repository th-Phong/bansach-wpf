   M S B A M L   `   `   `  ����B  >QL_SACH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QL_SACH.ViewQL_SACH.View  5      5clr-namespace:QL_SACH.ViewModelQL_SACH.ViewModel  5          QL_SACH.View.SachView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:QL_SACH.View     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      /	viewModelclr-namespace:QL_SACH.ViewModel  5      $
��auto��5	      $
��auto��5
         ChiTietSachVM  � DataContext#  [  5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5      .��5      � .+�5   
   �� -   5        $��listSach��5      $��2,85,2,0q�5      
������ 
������ $��Center=�5      ��5      �� *ListChiTietSach+��5      �� 5      .R�5      A�  A� Columns$ 6��6"    A� Rows$ 2��5   "   5      ��5       �� 5!      .R�5"      ��  �� Orientation$ Vertical=�6!   .+�5#      ��  J� Effect 5$      3  -System.Windows.Media.Effects.DropShadowEffect  5%   "      
BlurRadius$ 10Q�63      	Direction$	 270Q�5&   3   	   ShadowDepth$	 1Q�5'   3   
   Color$
 Black��5(   3   ._�5*      �� $	��120��6$   $	��120��5+   $   $��Center=�5,   $   $��UniformToFill=�5.   $   ��5-   $   ��  �� Path$ 	ImagePath� J� Clip 5/   "   @� 50   &    @� Center$ 60,60&�66    @� RadiusX$ 60Q�51   6    @� RadiusY$ 60Q�52   6   54      55      �� 56      $	��120��6$   $��Center=�57   $   $��13(�58   $   $
��Bold"�59   $    �� TextAlignment$ Center=�5;   $   $
��Wrap=�5<   $   ��5:   $   �� $ TenSach�5<   $   �� 5=       �� Padding$ 1q�6$   $��Center=�5>   $   
���  ��$��11(�5@   $   
���������5B   $   �� $ 	DonGiaBan��� 5C      .�6#   .�5D   "   B� .�6,   đ6/   5E      5F      5G      5H      5J      �� 5O   
   -   5        $��editSearchProduct��5O      $	��195��5P      $��0,45,600,10q�5Q      $	��Top=�5R      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$# Tìm kiếm tên sản phẩm��5S      $��Sitka Subheading)�5T      $��13(�5U      �� 5X   
   -   5        $��btnSearchProduct��5X      $��70��5Y      $��25��5Z      $��0,45,310,10q�5[      $��1q�5\      $	��Top=�5]      
���"�"�$��Tìm kiếm��5_      $��Sitka Subheading)�5`      $��13(�5a      $
��Bold"�5b      
�������  MaterialDesignRaisedButton#��[ 5d      �� 5g   
   -   5        $��comboProductArrange��5g      $��
0,49,68,10q�5h      $��2q�5i      $��Center=�5j      $	��Top=�5k      $  Sắp xếp theo giá cả��5l      $��Sitka Subheading)�5m      $��13(�5n      $��Italic$�5o      �� 5r   
   -   5        $��editFilterFrom��5r      $��80��5s      $��
200,32,0,0q�5t      $	��Top=�5u         FloatingOffset$ 0,-15&�5v         FloatingScale$	 .95Q�5w      $
 Từ��5x      $��Sitka Subheading)�5y      $��13(�5z       % !MaterialDesignFloatingHintTextBox#��[ 5{      �� 5~   
   -   5        $��editFilterTo��5~      $��80��5      $��
390,32,0,0q�5�      $	��Top=�5�      $ 0,-15&�5�      $	 .95Q�5�      $ Đến��5�      $��Sitka Subheading)�5�      $��13(�5�      #��[ 5�      �� 5�   
   -   5        $��comboPageIndex��5�      $��560,49,0,10q�5�      $��2q�5�      $��Center=�5�      $	��Top=�5�      $��0,0,0,0q�5�      $��Sitka Subheading)�5�      $��13(�5�      $��Italic$�5�      $
��Bold"�5�      �� 5�   
   $��25��6   $��25��5�      $��
650,50,0,0q�5�      $	��Top=�5�      
������ ���#303030 / +MaterialDesignFloatingActionMiniLightButton#��[ 5�      .��5�      '  !MaterialDesignThemes.Wpf.PackIcon  $��20��6&   $��20��5�   &      Kind$ KeyboardArrowLeft=�5�   &   5�      �� 5�   
   $��25��6   $��25��5�      $��
710,50,0,0q�5�      $	��Top=�5�      
������ ���#303030#��[ 5�      .��5�        $��20��6&   $��20��5�   &   $ KeyboardArrowRight=�5�   &   5�      �� 5�   
   $��60��6   $��30��5�      $��	0,15,15,0q�5�      $��0q�5�      $��Right=�5�      $	��Top=�5�      
���"�"�$��IMPORT��5�      $��10(�5�      $
��Bold"�5�      
�������#��[ 5�      �� 5�   
   $��60��6   $��30��5�      $��	0,15,90,0q�5�      $��0q�5�      $��Right=�5�      $	��Top=�5�      
���"�"�$��EXPORT��5�      $��10(�5�      $
��Bold"�5�      
�������#��[ 5�      �� 5�   
   $��60��6   $��30��5�      $��
0,15,170,0q�5�      $��0q�5�      $��Right=�5�      $	��Top=�5�      
���"�"�$��THÊM��5�      $��10(�5�      $
��Bold"�5�      
�������#��[ 5�      5�      5�      