   M S B A M L   `   `   `  ����H  DAvalonDock, Version=1.3.3585.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock  5   	    StartsInternational3   -StartsInternational.Building.Building_Display   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;ad,clr-namespace:AvalonDock;assembly=AvalonDock     5   	   -   5            AvalonDock.DockableContent   Name$  frmBuilding_Display��5   	      AvalonDock.ManagedContent   Title$ Thông tin tòa nhà��5   	   $	��420��5   	   $
��1024��6    � 	Resources 5	         Cmu m� InputGestureText��%n  &	        �� 5
   
   ���#D5DCE6.@�5      m� -   5        $��Thêm��5      $ F3��6%   
���   �6O   m� 5      -   5        $��Sửa��5      $ F4��6$   
���   �6M   m� 5      -   5        $
��View��5      $ F5��6%   
���   �6O   m� 5      -   5        $
��Xóa��5      $	 Del��6$   
���   �6O   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      �� 5      $��35 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $
��Left=�6I   .+�5      �� $��Mã tòa nhà��6   $��Center=�6)   $
��Left=�6D   �� 5      -   5        $��txtBuildingName��5      $	��150��6-   $��5,0,0,0q�69   $��Center=�6J   $
��Left=�6e   �� 5      -   5        $��	btnSearch��5   (   $��Tìm kiếm��6   $	��100��6S   $��5,0,0,0q�6_   �� 5      -   5        $��	btnExport��5   (   $��Kết xuất��6   $	��100��6S   $��5,0,0,0q�6_   5!      &   System.Windows.Controls.DataGrid  5#   
   -	   5        $��	dgrRenter��5#      $��1��6%      AutoGenerateColumns .     CanUserAddRows .  $��Bottom=�5%   3      RowStyle 5&      �� 5'      	 �� 
TargetType)  #System.Windows.Controls.DataGridRow"	  6   .�5(      -
   5        
 �� Triggers
 5)      P� 5*       P� Property �@ AlternationIndex P� Value$ 0��6>   . �5+      ��  �� Property � �� �� Value �	#FFEDEDED6;   5,      5.         Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Mã tòa nhà��6Y      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6m   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Building_Code+6m     53       . $ Địa chỉ��6S   $	 250 6d    6%   �� *	Address+6d     54       . $ Ghi chú��6P   $ * 6a    6%   �� *Note+6a   56      � 58   
   $��2��6     
BottomGrid#���  6   .+�59      �� $ 
Horizontal=�6   $��Center=�62   $��Center=�6M   .+�5:      �� -   5        $��	btnInsert��5:      $��5,0,0,0q�6*   $��Center=�6;   $��Center=�6X   $��Thêm��6s   $��75��6�   6�   �� 5;      -   5        $��	btnUpdate��5;      $��5,0,0,0q�6*   $��Center=�6<   $��Center=�6Y   $��Sửa��6t   $��75��6�   6�   �� 5<      -   5        $��	btnDelete��5<      $��5,0,0,0q�6*   $��Center=�6<   $��Center=�6Y   $
��Xóa��6t   $��75��6�   6�   �� 5=      -   5        $��btnView��5=      $��5,0,0,0q�6(   $��Center=�6:   $��Center=�6W   $	��Xem��6r   $��75��6�   6�   5>      5?      5@      5A      