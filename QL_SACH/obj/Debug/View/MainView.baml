   M S B A M L   `   `   `  ����B  >QL_SACH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QL_SACH.ViewQL_SACH.View  5   	   +clr-namespace:QL_SACH.ViewQL_SACH.View  5	   	       QL_SACH.View.MainView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   &localclr-namespace:QL_SACH.View  5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   #ucclr-namespace:QL_SACH.View  5	   	   -   5        $��
mainWindow��5
   	     � Title$  Quản lý sách��5   	   $	��900��5   	   $	��700��5   	    
  MainVM � DataContext# [  5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadedWindowCommand+   CommandParameter 5   $   �� 	 �� ElementName$	 
mainWindow��5      
 � 	Resources
 5        MenuOpen �� 
TargetName �� TargetProperty9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	MenuClose��%�  &	       &	 �     �� 5   
   .��5      U� $ GridMenu��6,   $ (FrameworkElement.Width)�5   ,   .\�5        $ 0��6'   $ 60Q�5   '     5      $ 0:0:0.2��6'   $	 200Q�5    '   5!      5"      �� 5#   
   .��5$      U� $ GridMenu��6,   $ (FrameworkElement.Width)�5%   ,   .\�5&        $ 0��6'   $	 200Q�5'   '     5(      $ 0:0:0.2��6'   $ 60Q�5)   '   5*      5+      5,       � Triggers 5.      :� 5/   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ ButtonOpenMenu��50      .[�51      �� #��[ 6   52      :� 53   
   $ ButtonBase.Click��6   $ ButtonCloseMenu��54      .[�55      �� #��[ 6   56      .��59      �  � RowDefinitions 5:   
   �� 5;      $
��Auto �6   �� 5<      .+�5>   
   � $��0��6   .+�5?      !   QL_SACH.View.UserControlBar  
 � Tag 6    �� *Title+$	 
mainWindow��5@      � 5A   
   $��1��6   .+�5B      � -   5         �Name$ 	GridTitle��5B      $��60��5C      $	��Top=�5D      ���	#FF2E7ECD � ColumnDefinitions 5F      �� 5G      $��60 �6'   �� 5H      $
��283* �6'   �� 5I      $��60 �6'   .+�5L      � -   5        $ OpenCloseMenu��5L      $��0��5M      .+�5N      �� -   5         ��Name$ ButtonCloseMenu��5N      $��60��5O      $��60��5P      $��Right=�5Q      $	��Top=�5R      ���	#FF185693$y�	Collapsed=�5V      ��5T      Z� .��5W      '  !MaterialDesignThemes.Wpf.PackIcon  $��30��62   $��30��5X   2   
�������   Kind$ 	ArrowLeft=�5Z   2   5[      �� 5\      -   5        $ ButtonOpenMenu��5\      $��60��5]      $��60��5^      $��Right=�5_      $	��Top=�5`      ���	#FF185693��5b      Z� .��5d        $��30��62   $��30��5e   2   
�������$
 Menu=�5g   2   5h      5i      �� 5j      $��1��6   $��Center=�5k      $��Center=�5l      $��23(�5m      $��Quản lý sách��5n      �� 5o      $��2��6   $	��0,7q�5p      $��Right=�5q      $��Center=�5r       �� Orientation$ 
Horizontal=�5s      .+�5t      �� $��Center=�6    $��18(�5u       '  !MaterialDesignThemes.Wpf.PopupBox  5w      $��10q�6.   
�������   PlacementMode$ BottomAndAlignRightEdges=�5y   .      	StaysOpen .     PopupContent. 5{      �� $	��150��6%   .+�5|      �� $	��!!!��6%   $��17(�5}   %   �� 5~      $	��!!!��6%   $��17(�5   %   �� 5�      $	��!!!��6%   $��17(�5�   %   �� 5�      �� 5�      -   5        $ ButtonPopUpLogout��5�   %   $��Logout��5�   %   $��17(�5�   %   5�      5�      5�      5�      � 5�      -   5        $ GridData��5�      $��70,70,10,10q�5�      .+�5�      #	  MaterialDesignThemes.Wpf.Card	  .��5�      � -   5        $ GridPrincipal��5�      5�      5�      � 5�      -	   5        $ GridMenu��5�      $��60��5�      $��0,60,0,0q�5�      $
��Left=�5�      .+�5�      �� ���	#FFB2C9EA.+�5�      � $	��250��6   $
��Left=�5�      .+�5�      �� -
   5         ��Name$ ListViewMenu��5�   #   $��0,0,0,0q�5�   #   ���	#FF2E7ECD$��Disabled=�5�   #   5�      ?
  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent
  5�      -   5         
 Name$ TrainsitionContextSlide��5�   >   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 5�   >   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension     Kind$ SlideInFromLeft=�    Duration$  0:0:0.2X�.��5�      � -   5        $ 	GridCusor��5�   #   $��10��5�   #   $��60��5�   #   $��	0,0.4,0,0q�5�   #   $
��Left=�5�   #   $	��Top=�5�   #   ���	#FF0368CB5�   #   5�      5�      5�      5�      5�      5�      5�      