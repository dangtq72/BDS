   M S B A M L   `   `   `  ����  StartsInternational%    StartsInternational.TraceDetail   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  CHI TIẾT THAY ĐỔI��5   	   $	��500��6#   $	��700��60    � WindowStartupLocation$ CenterScreen=�6<    � ShowInTaskbar .     WindowFormStyle#���   5   	   .��5      �  � RowDefinitions 5   
   �� 5	      �� 5
      $��40 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��grTraceDetail��5   5   $��0q�6      CanUserAddRows .     AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5        LeftAlignStyle1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# �  6C   ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly . 	   Header$	 Tên trường��6�   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 150 6�      Binding 6%   �� *	FieldName+6�     5      # �  6@    . $	 Thay đổi��6�   $

 320* 6�    6%   �� *Change+6�   5      � 5   
   $��1��6     
BottomGrid#���  6   .+�5      �� -   5        $��Center=�5      $��Center=�62   $��Thoát��6b   $��90��6r   5      5      5      