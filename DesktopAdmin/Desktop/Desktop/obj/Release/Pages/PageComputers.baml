   M S B A M L   `   `   `  ���� B  >Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Desktop.PagesDesktop.Pages  !    Desktop.Pages.PageComputers   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:Desktop.Pages     -     N� Title$  PageComputers��.���  � RowDefinitions �� $
��auto ��� $
��auto ��� �� $
��auto �.+��� .+��� $��23(�
����  �$	��5,0q�Компьютеры�� -   $��TextAll��$	��5,0q�Загрузка...��  �� Orientation$ 
Horizontal=�$��Right=�.+��� -   $��BtnList��$��40��.��📚�� -   $��BtnTable��$��40��.��🎞� $��1�� � ColumnDefinitions �� $
��auto ��� �� $
��auto �.+��� $ 
Horizontal=�$��30��.+��� $	��5,0q�Показать�� -   $��ComboSelected��$��60���� $	��5,0q�записей�� -   $��Search��$��1��$��30��$��10q��� -   $��BtnAdd��$��2��$��10q�$	��200��.��Добавить�� -   $��	ListItems��$��2������ .R�� ���� *ActualWidth+ �� RelativeSource ��  �� AncestorType$ ScrollContentPresenterL����� .R�� 
�������.+�� $��10q�.+��� $	��250��.+��� ���� *name+�� ���� *
class_name+��  ��Name$ BtnUse��-	   .��Управление�� $ 
Horizontal=�.+��� $��BtnEdit��-
   $	��✏��
����  ��� $��	BtnRemove��-   $
��🗑��
���  ��&   System.Windows.Controls.DataGrid  -     Name$ 	DataItems��$��2�� �� AlternationCount$ 2��	   RowStyle	 �� 
 �� 
TargetType)  #System.Windows.Controls.DataGridRow"
   �� Triggers P�  P� Property �@ AlternationIndex P� Value$ 0��. ���  �� Property � �� �� Value
 �����   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Название��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *name+  $ 
Класс�� �� *
class_name+4  .System.Windows.Controls.DataGridTemplateColumn  $ Управление��   CellTemplate �� .R��� $ BtnUse��-   .��Управление  $ Действия�� �� .R��� $ 
Horizontal=�.+��� $��BtnEdit��-   $	��✏��
����  ��� $��	BtnRemove��-   $
��🗑��
���  ���� -   $��TextVisible��$��2��$��10,40q�Загрузка...�� -   $��	TextPages��$��3��Загрузка...�� $ 
Horizontal=�$��3��$��Right=�.+��� -   $��BtnDown��$��30��.��◀️�� -   $��TextNow��$��30�� �� TextAlignment$ Center=��� -   $��BtnUp��$��30��.��▶️