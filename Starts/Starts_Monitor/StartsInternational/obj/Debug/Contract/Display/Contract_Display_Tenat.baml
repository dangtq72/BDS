   M S B A M L   `   `   `  ����N  JStartsInternational, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:StartsInternationalStartsInternational  5   	   ]3clr-namespace:StartsInternational.CustomUserControl%StartsInternational.CustomUserControl  5   	   H DAvalonDock, Version=1.3.3585.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock 5   	   A    ;StartsInternational.Contract.Display.Contract_Display_Tenat   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   5convert!clr-namespace:StartsInternational     5   	   Bus3clr-namespace:StartsInternational.CustomUserControl     5   	   ;ad,clr-namespace:AvalonDock;assembly=AvalonDock     5   	   -   5           AvalonDock.DockableContent   Name$   frmContract_Display_Tenant��5   	     AvalonDock.ManagedContent   Title$' !HDMG với TÒA NHÀ / CHỦ NHÀ��5   	   $	��420��5	   	   $
��1024��6    � 	Resources 5
         Cmu m� InputGestureText��%  &	        �� 5   
   ���#D5DCE6.@�5      m� -   5        $��Thêm��5      $ F3��6%   
���   �6O   m� 5      -   5        $��Sửa��5      $ F4��6$   
���   �6M   m� 5      -   5        $
��Xóa��5      $	 Del��6$   
���   �6O   m� 5      -   5        $
��View��5      $ F5��6%   
���   �6O   m� 5      -   5        $��Thanh toán��5      $ F7��6+   
���   �6U   m� 5      -   5        $��Yc TT��5      $ F8��6&   
���   �6P   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      �� 5      $��35 �6    5   
   &   StartsInternational.Convert_Date  convert_date��%   &	         5      6#   5      .+�5    
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $
��Left=�6I   .+�5"      �� $��Mã HĐ��6   $��Center=�6$   $
��Left=�6?   ?   9StartsInternational.CustomUserControl.AutoCompleteTextBox  5#      -   5          Name$ txtCode��5#   %   $��Center=�66   $	��200��6Q   $��5,0,0,0q�6]   �� 5%      $��	Tòa nhà��6   $��Center=�6&   $
��Left=�6A   �� 5&      -	   5        $��cboBuilding��5&   #   $	��120��6   $��5,0,0,0q�66   $��Center=�6G   $
��Left=�6b   �� 5(      $��Bên YC môi giới��6   $��5,0,0,0q�6.   $��Center=�6?   $
��Left=�6Z   �� 5)      -
   5        $��txtObject_Name��5)   "   $	��150��6   $��5,0,0,0q�68   $��Center=�6I   $
��Left=�6d   �� 5+      $��Trạng thái HĐ��6   $��Center=�6,   $
��Left=�6G   �� 5,      -   5        $��	cboStatus��5,   #   $	��120��6   $��5,0,0,0q�64   $��Center=�6E   $
��Left=�6`   �� 5.      $��Trạng thái phí��6   $��5,0,0,0q�6-   $��Center=�6>   $
��Left=�6Y   �� 5/      -   5        $��cboFee��5/   #   $	��120��6   $��5,0,0,0q�61   $��Center=�6B   $
��Left=�6]   �� 51      -   5        $��	btnSearch��51   (   $��Tìm kiếm��6   $	��100��6S   $��5,0,0,0q�6_   �� 52      -   5        $��	btnExport��52   (   $��Kết xuất��6   $	��100��6S   $��5,0,0,0q�6_   53      &   System.Windows.Controls.DataGrid  55   
   -   5        $��dgrContract��55      $��1��6'      AutoGenerateColumns .   � ContextMenu# [  6R   	   CanUserAddRows	 .  $��Bottom=�57   3   
   RowStyle
 58      �� 59       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5:      -   5         �� Triggers 5;      P� 5<       P� Property �@ AlternationIndex P� Value$ 0��6>   . �5=      ��  �� Property � �� �� Value �	#FFEDEDED6;   5>      5@         Columns 5B      0  *System.Windows.Controls.DataGridTextColumn  5C      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Mã hợp đồng��6Y      MinWidth$	 150Q�6n   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6%   �� *Contract_Code+6n     5D       . $ Mã BĐS��6W   $	 150Q�6g    6%   �� *Estate_Code+6g     5E       . $ 	Tên BĐS��6W   $	 150Q�6h    6%   �� *Estate_Name+6h     5F       . $ 	Ngày ký��6q   $	 100Q�6�    6%   �� *Contract_Date+ �� StringFormat$ 
dd/MM/yyyy��6�     5G       . $ 
Từ ngày��6u   $	 100Q�6�    6%   �� *Contract_FromDate+$ 
dd/MM/yyyy��6�     5H       . $ Đến ngày��6v   $	 100Q�6�    6%   �� *Contract_ToDate_Ex+$ 
dd/MM/yyyy��6�     5I       . $! Trạng thái hợp đồng��6W   $	 150Q�6t    6%   �� *Status_Name+6t     5J       . $ Bên YC môi giới��6W   $	 200Q�6p    6%   �� *Object_Name+6p     5K       . $ Người tạo ��6V   $	 100Q�6j    6%   �� *
Created_By+6j     5L       . $ Ngày tạo��6�   $	 100Q�6�    6%   �� *Created_Date+ �� 	Converter# [ 6�     5M       . $ Người sửa��6U   $	 100Q�6h    6%   �� *	Modifi_By+6h     5N       . $ Ngày sửa��6   $	 100Q�6�    6%   �� *Modifi_Date+# [ 6�   5Q      � 5S   
   $��2��6     
BottomGrid#���  6   .+�5T      �� $ 
Horizontal=�6   $��Center=�62   $��Center=�6M   .+�5U      �� -   5        $��	btnInsert��5U      $��5,0,0,0q�6*   $��Center=�6;   $��Center=�6X   $��Thêm��6s   $��75��6�   6�   �� 5V      -   5        $��	btnUpdate��5V      $��5,0,0,0q�6*   $��Center=�6<   $��Center=�6Y   $��Sửa��6t   $��75��6�   6�   �� 5W      -   5        $��	btnDelete��5W      $��5,0,0,0q�6*   $��Center=�6<   $��Center=�6Y   $
��Xóa��6t   $��75��6�   6�   �� 5X      -   5        $��btnView��5X      $��5,0,0,0q�6(   $��Center=�6:   $��Center=�6W   $	��Xem��6r   $��75��6�   6�   �� 5Y      -   5        $��btnPay��5Y      $��5,0,0,0q�6'   $��Center=�69   $��Center=�6V   $��Thanh toán��6q   $��75��6�   6�   �� 5Z      -   5        $��btnRequestPay��5Z      $��5,0,0,0q�6.   $��Center=�6@   $��Center=�6]   $��YC TT��6x   $��75��6�   6�   5\      5]      5^      5`      