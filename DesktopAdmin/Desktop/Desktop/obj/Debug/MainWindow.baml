   M S B A M L   `   `   `  ����B  >Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DesktopDesktop  5   	       Desktop.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Desktop     5   	     � Title$  Умная школа��5   	   $	��450��6   $	��800��6*   $	��450��5	   	   $	��800��6    � Icon$# /Imports/smart_class_icon.png��5
   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      -   5         �Name$ 	RowHeader��5   '   $��0 �6   6:   �� 5      6    � ColumnDefinitions 5   
   �� 5      -   5         ��Name$ ColNav��5   )   $��0 �6   6;   �� 5      6!   .+�5   
   � 
���   �$��1��6"   $��3��6/   $��3��6@   6V   �� 5   
   $.��(/Imports/smart_class_icon_trans_back.png��6   $��2��6B   $
��Left=�6V   $��50��6q   �� 5   
   -   5        $��BtnMenu��5      $��2��6    $��Right=�64   $y�	Collapsed=�6f   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��40��61   $��40��6<   ��6   �� *Photo+6J   �� 5      .+�5      �� ��6    �� *	FirstName+6=   �� 5      ��6    �� *Email+69   5       5!       � ContextMenu 5"      �� 5#      .@�5$      m� $#��🙍‍ Мой профиль��6   6:   m� 5%      $��🔒 Мои сессии��6   68   m� 5&      -   5        $��	BtnLogout��5&   1   $�� ⭕ Выход��6   6\   5'      5)      �� 5+   
   -   5        $��StackNav��5+      $��1��6%   $��2��62   ���#1d2127$	��280��6X   .+�5,      �� 
�������$	��5,0q�6+   Навигация6C   �� 5-      $
��10,5q�6   .+�5.      �� -   5        $��BtnMain��5.       
  BtnNav#��[  6>   .��6^   🔍 Главная6j   �� 5/      -   5        $��BtnUsers��5/   9   #��[  6   .��6`   👥 Пользователи6q   �� 50      -   5        $��BtnNews��50   9   #��[  6   .��6^   📰 Новости6j   �� 51      -	   5        $��BtnObjeccts��51   9   #��[  6   .��6f   (&🏫 Карточки обучения6|   �� 52      -
   5        $��BtnProblems��52   9   #��[  6   .��6f   '%⚠️ Технич. проблемы6{   9� 53       
 ExpNav#��[ 6   $��RightToLeft=�6;   ��54      �� 55      
�������$��LeftToRight=�67   $	��235��6S   🍽️ Столовая6m   .��57      �� $��LeftToRight=�6!   $��10q�6=   .+�58      �� -   5        $��BtnFoods��58   A   #��[  6!   .��6h   🥙 Питание6t   �� 59      -   5        $��BtnFoodworks��59   A   #��[  6!   .��6p   *(🍴 Расписание питания6�   5:      5;      9� 5=      #��[ 6   $��RightToLeft=�6;   ��5>      �� 5?      
�������$��LeftToRight=�67   $	��235��6S   +)⚙️ Администрирование6u   .��5A      �� $��LeftToRight=�6!   $��10q�6=   .+�5B      �� -   5        $��BtnClassses��5B   A   #��[  6!   .��6n   🏫 Классы6y   �� 5C      -   5        $��BtnComputers��5C   A   #��[  6!   .��6p   💻 Компьютеры6   5D      5E      5F      5G      �� 5I   
   -   5        $��BtnNav��5I      $��1��64   $��Right=�6A   #��[  6]   $��30��6}   
���   �$��Center=�5J   $   .��6H   🎞6L   �� 5L   
   $��1��6   $��1��6!   
�������$
��10,0q�6D   Умная школа6_   �� 5N   
   -   5        $��TextNav��5N   D   $��1��6   $��1��6!   
�������$��Right=�6S   $
��10,0q�6o   6    � 5P   
   -   5        $��MyFrame��5P      $��2��6   $��1��6,   
�������  � NavigationUIVisibility$ Hidden=�6S   6�   �� 5R   
   -   5        $��
StackToast��5R      $��2��6'   $��3��67   $��Right=�6H   $	��Top=�6d   6~   5S      5T      