   M S B A M L   `   `   `  ����B  >Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Desktop.PagesDesktop.Pages  5          Desktop.Pages.PageObjects   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Desktop.Pages     5      -   5          N� Title$  PageObjects��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      6   �� 5      $
��auto �6   6,   .+�5   
   �� .+�5      �� $��23(�6   
����  �$	��5,0q�68   Предметы6O   �� 5      -   5        $��TextAll��5      $	��5,0q�6'   Загрузка...6A   5      � 5   
   $��2��6   
������� � ColumnDefinitions 5      �� 5      6%   �� 5      $
��auto �6#   62   .+�5      �� -   5        $��	ListItems��5      ��5       �� 5!      .R�5"      � ��6$   �� *ActualWidth+ �� RelativeSource ��  �� AncestorType$ ScrollContentPresenterL�6�   5#      ��5%      �� 5&      .R�5'      � 
�������.+�5(      � $��10q�6#   .+�5)   "   �� $	��250��6-   .+�5*   &   �� ��60   �� *name+6H   �� 5+   &   $��	BtnTopics��6-   -   5        .��5+   V   Разделы6_   �� 5,   &    �� Orientation$ 
Horizontal=�61   .+�5-   *   �� $��BtnEdit��6O   -   5        $	��✏��5-   4   
����  �6z   �� 5.   *   $��	BtnRemove��6S   -   5        $
��🗑��5.   4   
���  ��6�   5/   '   50   #   51      52      53      55      �� 57      -   5        $��	StackForm��57   )   $��1��6   $	��200��6:   $y�	Collapsed=�6F   $��Center=�6]   $��10q�6x   .+�58      �� -   5        $��TextForm��58      $��Center=�6,   $��21(�6I   Добавление6c   �� 59      Название6&   �� 5:      $��0,0,0,10q�60   ��6   �� *name+6D   �� 5;      -	   5        $��BtnSave��5;      .��6>   Добавить6H   5<      �� 5>      -
   5        $��BtnForm��5>      $��1��6$   $	��Top=�6J   $
��Left=�6b   .��6}   	🎞️6�   5?      �� 5A   
   -   5        $��TextVisible��5A      $��2��6'   $��10,40q�64   Загрузка...6P   5B      5C      