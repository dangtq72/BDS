   M S B A M L   `   `   `  ����H  DAvalonDock, Version=1.3.3585.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock  5   	    StartsInternational0   *StartsInternational.Display.Renter_Display   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;ad,clr-namespace:AvalonDock;assembly=AvalonDock     5   	   -   5            AvalonDock.DockableContent   Name$  frmRenter_Display��5   	      AvalonDock.ManagedContent   Title$ Thông tin Khách hàng��5   	   $	��420��5   	   $
��1024��6   .��5	      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      �� 5      $��35 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $
��Left=�6I   .+�5      �� $��Tên khách hàng��6   $��Center=�6-   $
��Left=�6H   �� 5      -   5        $��txtRenterName��5      $	��150��6+   $��5,0,0,0q�67   $��Center=�6H   $
��Left=�6c   �� 5      $��Số đt��6   $��Center=�6$   $
��Left=�6?   �� 5      -   5        $��txtPhone��5      $	��150��6&   $��5,0,0,0q�62   $��Center=�6C   $
��Left=�6^   �� 5      -   5        $��	btnSearch��5   (   $��Tìm kiếm��6   $	��100��6S   $��5,0,0,0q�6_   �� 5      -   5        $��	btnExport��5   (   $��Kết xuất��6   $	��100��6S   $��5,0,0,0q�6_   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��	dgrRenter��5      $��1��6%      AutoGenerateColumns .     CanUserAddRows .  $��Bottom=�5    3      RowStyle 5!      �� 5"       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5#      -   5         �� Triggers 5$      P� 5%      	 P� Property	 �@ AlternationIndex
 P� Value$
 0��6>   . �5&      ��  �� Property � �� �� Value �	#FFEDEDED6;   5'      5)         Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Tên khách hàng��6Y      Width5  /System.Windows.Controls.DataGridLengthConverter$	 250 6q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Customer_Name+6q     5-       . $ Loại��6^   $	 250 6l    6%   �� *Customer_Type_Name+6l     5.       . $ Địa chỉ��6S   $	 200 6d    6%   �� *	Address+6d     5/       . $ Số đt��6Q   $	 120 6`    6%   �� *Phone+6`     50       . $	 Fax��6O   $	 100 6\    6%   �� *Fax+6\     51       . $ CMND/HC��6Y   $	 150 6j    6%   �� *Identity_Card+6j     52       . $ Mã số thuế��6T   $	 150 6h    6%   �� *
Tax_Code+6h   54      � 56   
   $��2��6      
BottomGrid#���   6   .+�57      �� $ 
Horizontal=�6   $��Center=�62   $��Center=�6M   .+�58      �� -   5        $��btnView��58      $��5,0,0,0q�6(   $��Center=�6:   $��Center=�6W   $	��Xem��6r   $��75��6�   6�   59      5:      5;      5<      