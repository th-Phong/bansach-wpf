   M S B A M L   `   `   `  ����B  >QL_SACH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QL_SACH.ViewQL_SACH.View  5      !    QL_SACH.View.UserControlBar   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      &localclr-namespace:QL_SACH.View  5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      -   5        $��ucControlBar��5	         UserControlBarVM  � DataContext#  [  5
      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ MouseLeftButtonDown��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *MouseMoveWindowCommand+   CommandParameter 5   $   ��  �� ElementName$ ucControlBar��5      .��5      � .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  $
��32px��6#      Mode$ PrimaryLight=�5   #   .��5      ]� ��5      �� 5       �� 
StartPoint$ 0.5,0&�6*   	 �� EndPoint$	 0.5,1&�5   *   .��5      � 
 � Offset$
 0Q�6'    � Color$ White��5   '   � 5      $
 2Q�6'   $ White��5   '   5      .+�5      �� 
������ $��Right=�5        �� Orientation$ 
Horizontal=�5!       � 	Resources 5"       �� 
TargetType �� Property �� Value��%   '��       �� 5#      " ��6    .�5$      ��  � ��$	 2,4q�5%   %   �� 5&       � ��$ 40��5'   %   5(      5)      .+�5+      �� $
��22px��6   $
��22px��5,      $��0,5,0,5q�5-      ���#ffcc00 / +MaterialDesignFloatingActionMiniLightButton#��[ 52       c� OverflowMode$ AsNeeded=�53       � ToolTip$ Minimize��54      ��5/      Z� ��50      �� *MinimizeWindowCommand+��51      �� $ ucControlBar��.��55      '  !MaterialDesignThemes.Wpf.PackIcon  $
��15px��62   $
��15px��56   2      Kind$ WindowMinimize=�57   2   58      �� 59      $
��22px��6   $
��22px��5:      $��	25,5,25,5q�5;      
��� � �#��[ 5@      $ AsNeeded=�5A      $ Maximize��5B      ��5=      Z� ��5>      �� *MaximizeWindowCommand+��5?      �� $ ucControlBar��.��5C        $
��15px��62   $
��15px��5D   2   $ WindowMaximize=�5E   2   5F      �� 5G      $
��22px��6   $
��22px��5H      $��0,5,10,5q�5I      
���  ��#��[ 5N      $ AsNeeded=�5O      $ Close��5P      ��5K      Z� ��5L      �� *CloseWindowCommand+��5M      �� $ ucControlBar��.��5Q        $
��15px��62   $
��15px��5R   2   $ WindowClose=�5S   2   5T      5U      �� 5W      $
��Left=�6   $ 
Horizontal=�5X      .+�5Y      �� -   5        $��	imgAvatar��5Y      $��22��5Z      $��22��5[      $��7,0,0,0q�5\      $-��'/QL_SACH;component/Images/Icon/Icon.ico��5]      $
��Fill=�5^      �� 5_      $��10,0,0,0q�6    $��Center=�5`       $
��18px(�5a       $
��Bold"�5b       ��5c       �� *Tag+$ ucControlBar��5d      5e      5f      5g      5h      