   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	       WpfApp2.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	     � Title$  Главная��5   	   $	��600��6   $
��1000��6&   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��100 �6   �� 5      �� 5      $	��100 �6   .+�5   
   �� -   5         ��Name$ searchTextgBox��5      $��0��6*   $��15q�67   $��20(�6C   $
��Bold"�6Q   �� 5   
   $��1��6   $��15q�6$   
�������.��5      �� -   5         ��Name$ cardsStackPanel��5      5      �� 5   
   -   5        $��mainStackPanel��5   ;   $��2��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� -   5        $��addPhoneButton��5   D   
�������   btn#��[  6'   $��Добавить��6w   �� 5      -   5         ��Name$ groupComboBox��5   )   
�������$��76��6@    �� SelectedValuePath$ id��6M    �� DisplayMemberPath$
 name��6d   $	��230��6�   �� 5      -   5        $��FilterButton��5   D   
�������#��[  6'   $��Фильтр��6s   $	��199��6�   �� 5      -   5        $��UpdateButton��5   D   
�������#��[  6'   $��Обновить��6s   $	��199��6�   5      5      5      