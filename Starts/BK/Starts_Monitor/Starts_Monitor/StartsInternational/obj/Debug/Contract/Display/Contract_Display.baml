   M S B A M L   `   `   `  ����N  JStartsInternational, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:StartsInternational.CustomUserControl%StartsInternational.CustomUserControl  5   	   9!clr-namespace:StartsInternationalStartsInternational  5   	   H DAvalonDock, Version=1.3.3585.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock 5   	   ;    5StartsInternational.Contract.Display.Contract_Display   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Bus3clr-namespace:StartsInternational.CustomUserControl     5   	   5convert!clr-namespace:StartsInternational     5   	   ;ad,clr-namespace:AvalonDock;assembly=AvalonDock     5   	   -   5           AvalonDock.DockableContent   Name$  frmContract_Display��5   	     AvalonDock.ManagedContent   Title$ HDMG với KHÁCH��5   	   $	��420��5	   	   $
��1024��6    � 	Resources 5
         Cmu m� InputGestureText��%  &	        �� 5   
   ���#D5DCE6.@�5      m� -   5        $��Thêm��5      $ F3��6%   
���   �6O   m� 5      -   5        $��Sửa��5      $ F4��6$   
���   �6M   m� 5      -   5        $
��Xóa��5      $	 Del��6$   
���   �6O   m� 5      -   5        $
��View��5      $ F5��6%   
���   �6O   m� 5      -   5        $��Print��5      $ Print��6&   
���   �6S   m� 5      -   5        $��Yc TT��5      $ F8��6&   
���   �6P   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      �� 5      $��35 �6    5   
   &   StartsInternational.Convert_Date  convert_date��%   &	         5      6#   5      .+�5!   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $
��Left=�6I   .+�5#      �� $��Mã HĐ��6   $��Center=�6$   $
��Left=�6?   ?   9StartsInternational.CustomUserControl.AutoCompleteTextBox  5$      -   5          Name$ txtCode��5$   %   $��Center=�66   $	��150��6Q   $��5,0,0,0q�6]   �� 5&      $��	Tòa nhà��6   $��Center=�6&   $
��Left=�6A   �� 5'      -	   5        $��cboBuilding��5'   #   $	��120��6   $��5,0,0,0q�66   $��Center=�6G   $
��Left=�6b   �� 5)      $��Bên YC môi giới��6   $��5,0,0,0q�6.   $��Center=�6?   $
��Left=�6Z   �� 5*      -
   5        $��txtCustomer_Name��5*   "   $	��150��6   $��5,0,0,0q�6:   $��Center=�6K   $
��Left=�6f   �� 5,      $��Trạng thái HĐ��6   $��Center=�6,   $
��Left=�6G   �� 5-      -   5        $��	cboStatus��5-   #   $	��120��6   $��5,0,0,0q�64   $��Center=�6E   $
��Left=�6`   �� 5/      $��Trạng thái thanh toán��6   $��5,0,0,0q�64   $��Center=�6E   $
��Left=�6`   �� 50      -   5        $��cboStatusPay��50   #   $	��120��6   $��5,0,0,0q�67   $��Center=�6H   $
��Left=�6c   �� 52      -   5        $��	btnSearch��52   (   $��Tìm kiếm��6   $	��100��6S   $��5,0,0,0q�6_   �� 53      -   5        $��	btnExport��53   (   $��Kết xuất��6   $	��100��6S   $��5,0,0,0q�6_   54      &   System.Windows.Controls.DataGrid  56   
   -   5        $��dgrContract��56      $��1��6'      AutoGenerateColumns .   � ContextMenu# [  6R   	   CanUserAddRows	 .  $��Bottom=�58   3   
   RowStyle
 59      �� 5:       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5;      -   5         �� Triggers 5<      P� 5=       P� Property �@ AlternationIndex P� Value$ 0��6>   . �5>      ��  �� Property � �� �� Value �	#FFEDEDED6;   5?      5A         Columns 5C      0  *System.Windows.Controls.DataGridTextColumn  5D      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Mã hợp đồng��6Y      MinWidth$	 150Q�6n   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6%   �� *Contract_Code+6n     5E       . $ Mã BĐS��6W   $	 150Q�6g    6%   �� *Estate_Code+6g     5F       . $ 	Tên BĐS��6W   $	 150Q�6h    6%   �� *Estate_Name+6h     5G       . $ 	Ngày ký��6�   $	 100Q�6�    6%   �� *Contract_Date+ �� 	Converter# [ 6�     5H       . $ 
Từ ngày��6�   $	 100Q�6�    6%   �� *Contract_FromDate+# [ 6�     5I       . $ Đến ngày��6�   $	 100Q�6�    6%   �� *Contract_ToDate_Ex+# [ 6�     5J       . $! Trạng thái hợp đồng��6W   $	 150Q�6t    6%   �� *Status_Name+6t     5K       . $ Bên YC môi giới��6W   $	 200Q�6p    6%   �� *Object_Name+6p     5M       . $ Người tạo ��6V   $	 100Q�6j    6%   �� *
Created_By+6j     5N       . $ Ngày tạo��6�   $	 100Q�6�    6%   �� *Created_Date+# [ 6�     5O       . $ Người sửa��6U   $	 100Q�6h    6%   �� *	Modifi_By+6h     5P       . $ Ngày sửa��6�   $	 100Q�6�    6%   �� *Modifi_Date+# [ 6�   5S      � 5U   
   $��2��6     
BottomGrid#���  6   .+�5V      �� $ 
Horizontal=�6   $��Center=�62   $��Center=�6M   .+�5W      �� -   5        $��	btnInsert��5W      $��5,0,0,0q�6*   $��Center=�6;   $��Center=�6X   $��Thêm��6s   $��75��6�   6�   �� 5X      -   5        $��	btnUpdate��5X      $��5,0,0,0q�6*   $��Center=�6<   $��Center=�6Y   $��Sửa��6t   $��75��6�   6�   �� 5Y      -   5        $��	btnDelete��5Y      $��5,0,0,0q�6*   $��Center=�6<   $��Center=�6Y   $
��Xóa��6t   $��75��6�   6�   �� 5Z      -   5        $��btnView��5Z      $��5,0,0,0q�6(   $��Center=�6:   $��Center=�6W   $	��Xem��6r   $��75��6�   6�   �� 5[      -   5        $��btnRequestPay��5[      $��5,0,0,0q�6.   $��Center=�6@   $��Center=�6]   $��YC TT��6x   $��75��6�   6�   5\      5]      5^      5`      