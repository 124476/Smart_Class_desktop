   M S B A M L   `   `   `  ����B  >Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Desktop.PagesDesktop.Pages  5          Desktop.Pages.PageFoods   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Desktop.Pages     5      -   5          N� Title$  	PageFoods��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      6   �� 5      $
��auto �6   6,   .+�5   
   �� .+�5      �� $��23(�6   
����  �$	��5,0q�68   Питание6N   �� 5      -   5        $��TextAll��5      $	��5,0q�6'   Загрузка...6A   5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   .+�5      �� -   5        $��BtnList��5      $��40��6:   .��6E   📚6I   �� 5      -   5        $��BtnTable��5      $��40��6<   .��6G   🎞6K   5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5       $
��auto �6#   62   �� 5!      6%   �� 5"      $
��auto �6#   62   .+�5$      �� $ 
Horizontal=�6   $��30��62   .+�5%      �� $	��5,0q�6   Показать63   �� 5&      -   5        $��ComboSelected��5&      $��60��6b   6o   �� 5'      $	��5,0q�6   записей62   5(      �� 5*      -   5        $��Search��5*      $��1��6$   $��30��6U   $��10q�6a   6o   �� 5,      -   5        $��BtnAdd��5,      $��2��68   $��10q�6H   $	��200��6T   .��6`   Добавить6j   5-      �� 5/   
   -   5        $��	ListItems��5/      $��2��6$   ��50      �� 51      .R�52      � ��6    �� *ActualWidth+ �� RelativeSource ��  �� AncestorType$ ScrollContentPresenterL�6�   53      ��55      �� 56      .R�57      � 
�������.+�58      � $��10q�6   .+�59      �� $	��250��6)   .+�5:   "   �� ��6,   �� *name+6D   �� 5;   "   ��6,   �� *price+6E   �� 5<   "   $��BtnEdit��6)   -	   5        .��5<   N   Изменить6X   5=      5>      5?      5@      5B      &   System.Windows.Controls.DataGrid  5D   
   -
   5          Name$ 	DataItems��5D      $��2��6&    �� AlternationCount$ 2��63      RowStyle 5E      �� 5F      	 �� 
TargetType)  #System.Windows.Controls.DataGridRow"	  6   
 �� Triggers
 5G      P� 5H       P� Property �@ AlternationIndex P� Value$ 0��6>   . �5I      ��  �� Property � �� �� Value
 �����6J   5J      5L         Columns 5N      0  *System.Windows.Controls.DataGridTextColumn  5O      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *name+6R     5P      $ Цены��6%    63   �� *price+6O   4  .System.Windows.Controls.DataGridTemplateColumn  5Q      $ Действия��6)      CellTemplate 5R      �� 5S      .R�5T      �� $��BtnEdit��6%   -   5        .��5T   J   Изменить6T   5U      5W      5Y      �� 5[   
   -   5        $��TextVisible��5[      $��2��6'   $��10,40q�64   Загрузка...6P   �� 5]   
   -   5        $��	TextPages��5]      $��3��6%   Загрузка...6?   �� 5_   
   $ 
Horizontal=�6   $��3��6.   $��Right=�6;   .+�5`      �� -   5        $��BtnDown��5`      $��30��6:   .��6E   ◀️6I   �� 5a      -   5        $��TextNow��5a      $��30��6'    �� TextAlignment$ Center=�62   6K   �� 5b      -   5        $��BtnUp��5b      $��30��66   .��6A   ▶️6E   5c      5d      5e      