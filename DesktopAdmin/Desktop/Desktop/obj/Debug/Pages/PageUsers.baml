   M S B A M L   `   `   `  ����B  >Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Desktop.PagesDesktop.Pages  5          Desktop.Pages.PageUsers   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Desktop.Pages     5      -   5          N� Title$  	PageUsers��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      6   �� 5      $
��auto �6   6,   .+�5   
   �� .+�5      �� $��23(�6   
����  �$	��5,0q�68   Пользователи6S   �� 5      -   5        $��TextAll��5      $	��5,0q�6'   Загрузка...6A   5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   .+�5      �� -   5        $��BtnList��5      $��40��6:   .��6E   📚6I   �� 5      -   5        $��BtnTable��5      $��40��6<   .��6G   🎞6K   5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5       $
��auto �6#   62   �� 5!      6%   .+�5#      �� $ 
Horizontal=�6   $��30��62   .+�5$      �� $	��5,0q�6   Показать63   �� 5%      -   5        $��ComboSelected��5%      $��60��6b   6o   �� 5&      $	��5,0q�6   записей62   5'      �� 5)      -   5        $��Search��5)      $��1��6$   $��30��6U   $��10q�6a   6o   5*      �� 5,   
   -   5        $��	ListItems��5,      $��2��6$   ��5-      �� 5.      .R�5/      � ��6    �� *ActualWidth+ �� RelativeSource ��  �� AncestorType$ ScrollContentPresenterL�6�   50      ��52      �� 53      .R�54      � 
�������.+�55      � $��10q�6    56      �� 57   "   65   �� 58   "   65   .+�5:      �� $	��250��6)   .+�5;   "   �� ��6,   �� *	FirstName+6I   �� 5<   "   ��6,   �� *
LastName+6H   �� 5=   "   ��6,   �� *
Username+6H   �� 5>   "   ��6,   �� *Email+6E   5?      �� 5@      $��1��6(   ��68   �� *	RolesName+6U   5A      5B      5C      5E      &   System.Windows.Controls.DataGrid  5G   
   -   5          Name$ 	DataItems��5G      $��2��6&    �� AlternationCount$ 2��63      RowStyle 5H      �� 5I      	 �� 
TargetType)  #System.Windows.Controls.DataGridRow"	  6   
 �� Triggers
 5J      P� 5K       P� Property �@ AlternationIndex P� Value$ 0��6>   . �5L      ��  �� Property � �� �� Value
 �����6J   5M      5O         Columns 5Q      0  *System.Windows.Controls.DataGridTextColumn  5R      ,  &System.Windows.Controls.DataGridColumn   Header$ Фамилия��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *	FirstName+6V     5S      $ Имя��6%    62   �� *
LastName+6Q     5T      $ 
Логин��6%    64   �� *
Username+6S     5U      $ 
Почта��6%    64   �� *Email+6P     5V      $ Роли��6%    63   �� *	RolesName+6S   5X      �� 5Z   
   -	   5        $��TextVisible��5Z      $��2��6'   $��10,40q�64   Загрузка...6P   �� 5\   
   -
   5        $��	TextPages��5\      $��3��6%   Загрузка...6?   �� 5^   
   $ 
Horizontal=�6   $��3��6.   $��Right=�6;   .+�5_      �� -   5        $��BtnDown��5_      $��30��6:   .��6E   ◀️6I   �� 5`      -   5        $��TextNow��5`      $��30��6'    �� TextAlignment$ Center=�62   6K   �� 5a      -   5        $��BtnUp��5a      $��30��66   .��6A   ▶️6E   5b      5c      5d      