   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5      B >Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Desktop.PagesDesktop.Pages 5         Desktop.Pages.PageMain   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Gcharts4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      -localclr-namespace:Desktop.Pages     5        N� Title$  PageMain��5
      .��5      �� .��5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    60   �� 5      6"   .+�5      �� $��10q�6   $��21(�6$   -+Личный кабинет. Главная6K   � 5      -   5        $��	ListForms��5      $��1��6)   .+�5      � -   5         J� 	AllowDrop . 
�������$	��250��5   O   $	��200��6[   $��10q�6h    5      �� 5      $
��auto �6(   68   �� 5      6*   .+�5      ��  �� Padding$ 5q�6    1/Количество пользователей6F   � 5      
�������$��1��6.   .+�5         LiveCharts.Wpf.PieChart  -   5        $��UsersPieChart��5   *      InnerRadius$ 60Q�6?   &    LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Bottom=�6P   6j   5       5!      � 5"      -   5         . 
�������$	��250��5"   O   $	��200��6[   $��10q�6h    5#      �� 5$      $
��auto �6(   68   �� 5%      6*   .+�5'      �� $ 5q�6    0.Среднее время активности6F   � 5)      
�������$��1��6.   .+�5*      !   LiveCharts.Wpf.AngularGauge  -   5        $��ActivityGauge��5*   .      
NeedleFill
 � � �   Sections 5,   "   #   LiveCharts.Wpf.AngularSection     	FromValue$ 0Q�68   	   ToValue$		 100Q�6F   6V   5.      5/      50      � 51      -   5         . 
�������$	��250��51   O   $	��200��6[   $��10q�6h    52      �� 53      $
��auto �6(   68   �� 54      6*   .+�56      �� $ 5q�6    Активность ПК6;   � 58      
�������$��1��6.   .+�59      #   LiveCharts.Wpf.CartesianChart  -   5        $��ErrorBarChart��59   0   
   AxisX
 5;   "      LiveCharts.Wpf.Axis     Title$ Статус��6.      Labels9   3LiveCharts.Wpf.Converters.StringCollectionConverter$ Ошибки,Всего 6=      AxisY 5>   "     $ Количество��6.   5@      5A      5B      � 5C      -   5         . 
�������$	��520��5C   O   $	��200��6[   $��10q�6h    5D      �� 5E      $
��auto �6(   68   �� 5F      6*   .+�5H      �� $ 5q�6    dbДинамика подключения компьютеров за последние 10 дней6c   � 5J      
�������$��1��6.   .+�5K        -	   5          Name$ TabChart��5K   =   $��1��60   
 5M   "         LiveCharts.Wpf.DefaultAxes   CleanSeparator   	Separator# Z 6.   6i   5O      5P      5Q      � 5R      -
   5         . 
�������$	��250��5R   O   $	��200��6[   $��10q�6h    5S      �� 5T      $
��auto �6(   68   �� 5U      6*   .+�5W      �� $ 5q�6    %#Эффективность сети6@   � 5Y      
�������$��1��6.   .+�5Z        -   5        $��RoomLoadChart��5Z   0   $��10q�6E   
 5\   "     $ Кабинет��6.      LabelsRotation$ 15Q�6>    5_   "     $ Количество ПК��6.   5a      5b      5c      5d      5e      5f      5g      