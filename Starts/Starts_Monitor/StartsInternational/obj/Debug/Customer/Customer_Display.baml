   M S B A M L   `   `   `  ����H  DAvalonDock, Version=1.3.3585.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock  5   	    StartsInternational2   ,StartsInternational.Display.Customer_Display   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;ad,clr-namespace:AvalonDock;assembly=AvalonDock     5   	   -   5            AvalonDock.DockableContent   Name$  frmCustomer_Display��5   	      AvalonDock.ManagedContent   Title$ Thông tin Khách hàng��5   	   $	��420��5   	   $
��1024��6    � 	Resources 5
         Cmu m� InputGestureText��%n  &	        �� 5   
   ���#D5DCE6.@�5      m� -   5        $��Thêm��5      $ F3��6%   
���   �6O   m� 5      -   5        $��Sửa��5      $ F4��6$   
���   �6M   m� 5      -   5        $
��Xóa��5      $	 Del��6$   
���   �6O   m� 5      -   5        $
��View��5      $ F5��6%   
���   �6O   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      �� 5      $��35 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $
��Left=�6I   .+�5      �� $��Tên khách hàng��6   $��Center=�6-   $
��Left=�6H   �� 5      -   5        $��txtRenterName��5      $	��150��6+   $��5,0,0,0q�67   $��Center=�6H   $
��Left=�6c   �� 5       $��Số đt��6   $��Center=�6$   $
��Left=�6?   �� 5!      -   5        $��txtPhone��5!      $	��150��6&   $��5,0,0,0q�62   $��Center=�6C   $
��Left=�6^   �� 5#      -   5        $��	btnSearch��5#   (   $��Tìm kiếm��6   $	��100��6S   $��5,0,0,0q�6_   �� 5$      -	   5        $��	btnExport��5$   (   $��Kết xuất��6   $	��100��6S   $��5,0,0,0q�6_   5&      &   System.Windows.Controls.DataGrid  5(   
   -
   5        $��	dgrRenter��5(      $��1��6%      AutoGenerateColumns .   � ContextMenu# �   6P      CanUserAddRows .  $��Bottom=�5*   3   	   RowStyle	 5+      �� 5,      
 �� 
TargetType)  #System.Windows.Controls.DataGridRow"
  6   .�5-      -   5         �� Triggers 5.      P� 5/       P� Property �@ AlternationIndex P� Value$ 0��6>   . �50      ��  �� Property � �� �� Value �	#FFEDEDED6;   51      53         Columns 55      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Tên khách hàng��6Y      Width5  /System.Windows.Controls.DataGridLengthConverter$	 350 6q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Customer_Name+6q     57       . $ Loại��6^   $	 150 6l    6%   �� *Customer_Type_Name+6l     58       . $ Số đt��6Q   $	 120 6`    6%   �� *Phone+6`     59       . $	 Fax��6O   $	 100 6\    6%   �� *Fax+6\     5:       . $ CMND/HC��6Y   $	 150 6j    6%   �� *Identity_Card+6j     5;       . $ Mã số thuế��6T   $	 150 6h    6%   �� *
Tax_Code+6h     5<       . $ Địa chỉ��6S   $ * 6d    6%   �� *	Address+6d   5>      � 5@   
   $��2��6     
BottomGrid#���  6   .+�5A      �� $ 
Horizontal=�6   $��Center=�62   $��Center=�6M   .+�5B      �� -   5        $��	btnInsert��5B      $��5,0,0,0q�6*   $��Center=�6<   $��Center=�6Y   $��Thêm mới��6t   $��75��6�   6�   �� 5C      -   5        $��	btnUpdate��5C      $��5,0,0,0q�6*   $��Center=�6<   $��Center=�6Y   $��Sửa��6t   $��75��6�   6�   �� 5D      -   5        $��	btnDelete��5D      $��5,0,0,0q�6*   $��Center=�6<   $��Center=�6Y   $
��Xóa��6t   $��75��6�   6�   �� 5E      -   5        $��btnView��5E      $��5,0,0,0q�6(   $��Center=�6:   $��Center=�6W   $	��Xem��6r   $��75��6�   6�   5F      5G      5H      5I      