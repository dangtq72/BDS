   M S B A M L   `   `   `  ����  StartsInternational(    "StartsInternational.GroupUser_View   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$)  #Xem chi tiết nhóm người dùng��5   	      WindowFormStyle#���   6.   $	��470��5   	   $	��700��6    � WindowStartupLocation$ CenterScreen=�6"   .��5      �  � RowDefinitions 5   
   �� 5	      $	��115 �6   �� 5
      $��* �6   �� 5      $��40 �6   .+�5   
   �� -   5        $��	grbStatus��5   6   $%��Thông tin nhóm người dùng��6   $��6q�6G   $	��105��6R   .��5      � $��75��6    5      �� 5      $��25 �6$   �� 5      $��50 �6$    � ColumnDefinitions 5      �� 5      $	��135 �6'   �� 5      .+�5      �� $��Tên nhóm người dùng��6   $��Right=�66   $��0,0,5,0q�6R   $��Center=�6c   �� 5      $��Ghi chú��6   $��Right=�6*   $��0,0,5,0q�6F   $��Center=�6W   $��0��6r   $��1��6�   �� 5      -   5        $��txtName��5      $��Center=�6)   $��1��6D   $��0��6T   $��0,0,15,0q�6a   $��Stretch=�6s   $��1��6�    �� 	MaxLength$	 100��6�    �� 
IsReadOnly . 6�   �� 5      -   5        $��txtNotes��5   g   $��1��6   $��1��6'   $��Stretch=�67   $��0,0,15,0q�6U   $��Center=�6w   $��45��6�    �� TextWrapping$
 Wrap=�6�   $	 245��6�   $��2��6�    . 6�   5      5      �� 5    
   $��1��6   $��6,0,6,6q�6    $��Danh sách người dùng��61   .��5!      &   System.Windows.Controls.DataGrid  -   5        $��dgrUser��5!   U   $��3q�6      CanUserAddRows .     AutoGenerateColumns .  	   Columns	 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn
   
IsReadOnly
 .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6Y     CenterAlignStyle1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [ 6e     TextCell   	CellStyle# �  6�      Binding 6)   �� *	User_Name+   Header 5$      �� 5%      $��Tên đăng nhập��6$   $��Center=�6<   $��28��6W   $
��Bold"�6c   5'        5)      
 . $	 120 6X   # [ 6d   # �  6�    6)   �� *
FullName+ 5*      �� 5+      $��Tên đầy đủ��6$   $��Center=�69   $��28��6T   $
��Bold"�6`   5-        5/      
 . $	 120 6Z   # [ 6f   # �  6�    6)   �� *
Group_Name+ 50      �� 51      $��Nhóm người SD��6$   $��Center=�6<   $��28��6W   $
��Bold"�6c   53        55      
 . $	 250 6Z   # [ 6f   # �  6�    6)   �� *
Last_Login+ 56      �� 57      $&�� Lần đăng nhập cuối cùng��6$   $��Center=�6F   $��28��6a   $
��Bold"�6m   59      5;      5<      � 5>   
   $��2��6     
BottomGrid#���  6   $��0q�6A   .+�5?      �� -   5        $��	btnCancel��5?   &   $��Thoát��6   $��Center=�67   $��70��6R   $��Center=�6]   $��3��6�   5@      5B      5C      