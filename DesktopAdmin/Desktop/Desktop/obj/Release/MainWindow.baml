   M S B A M L   `   `   `  ���� B  >Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DesktopDesktop      Desktop.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:Desktop       � Title$  Умная школа��$	��450��$	��800��$	��450��$	��800�� � Icon$# /Imports/smart_class_icon.png��.���  � RowDefinitions �� $
��auto ��� -    �Name$ 	RowHeader��$��0 ���  � ColumnDefinitions �� -    ��Name$ ColNav��$��0 ��� .+�� 
���   �$��1��$��3��$��3���� $.��(/Imports/smart_class_icon_trans_back.png��$��2��$
��Left=�$��50���� -   $��BtnMenu��$��2��$��Right=�$y�	Collapsed=�.����  �� Orientation$ 
Horizontal=�.+��� $��40��$��40������ *Photo+�� .+��� ���� *	FirstName+�� ���� *Email+ � ContextMenu �� .@�m� $#��🙍‍ Мой профиль��m� $��🔒 Мои сессии��m� -   $��	BtnLogout��$�� ⭕ Выход���� -   $��StackNav��$��1��$��2�����#1d2127$	��280��.+��� 
�������$	��5,0q�Навигация�� $
��10,5q�.+��� -   $��BtnMain�� 
  BtnNav#��[  .��🔍 Главная�� -   $��BtnUsers��#��[  .��👥 Пользователи�� -   $��BtnNews��#��[  .��📰 Новости�� -	   $��BtnProblems��#��[  .��'%⚠️ Технич. проблемы9�  
 ExpNav#��[ $��RightToLeft=����� 
�������$��LeftToRight=�$	��235��🍽️ Столовая.���� $��LeftToRight=�$��10q�.+��� -
   $��BtnFoods��#��[  .��🥙 Питание�� -   $��BtnFoodworks��#��[  .��*(🍴 Расписание питания9� #��[ $��RightToLeft=����� 
�������$��LeftToRight=�$	��235��+)⚙️ Администрирование.���� $��LeftToRight=�$��10q�.+��� -   $��BtnClassses��#��[  .��🏫 Классы�� -   $��BtnComputers��#��[  .��💻 Компьютеры�� -   $��BtnNav��$��1��$��Right=�#��[  $��30��
���   �$��Center=�.��🎞�� $��1��$��1��
�������$
��10,0q�Умная школа�� -   $��TextNav��$��1��$��1��
�������$��Right=�$
��10,0q� � -   $��MyFrame��$��2��$��1��
�������  � NavigationUIVisibility$ Hidden=��� -   $��
StackToast��$��2��$��3��$��Right=�$	��Top=�