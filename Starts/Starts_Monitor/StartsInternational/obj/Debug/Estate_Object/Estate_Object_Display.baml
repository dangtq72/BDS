   M S B A M L   `   `   `  ����H  DAvalonDock, Version=1.3.3585.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock  5   	    StartsInternational=   7StartsInternational.Estate_Object.Estate_Object_Display   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   ;ad,clr-namespace:AvalonDock;assembly=AvalonDock     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5            AvalonDock.DockableContent   Name$  frmEstate_Object_Display��5   	      AvalonDock.ManagedContent   Title$) #Đối tượng bất động sản��5   	   $	��420��5   	   $
��1024��6    � 	Resources 5	         Cmu m� InputGestureText��%n  &	        �� 5
   
   ���#D5DCE6.@�5      m� -   5        $��Thêm��5      $ F3��6%   
���   �6O   m� 5      -   5        $��Sửa��5      $ F4��6$   
���   �6M   m� 5      -   5        $
��Xóa��5      $	 Del��6$   
���   �6O   m� 5      -   5        $
��View��5      $ F5��6%   
���   �6O   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      �� 5      $��35 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $
��Left=�6I   .+�5      �� $��	Mã BĐS:��6   $��Center=�6&   $
��Left=�6A   �� 5      -   5        $��txtCode��5      $	��150��6%   $��5,0,0,0q�61   $��Center=�6B   $
��Left=�6]   �� 5      $��Loại:��6   $��5,0,0,0q�6$   $��Center=�65   $
��Left=�6P   �� 5       -   5        $��cboType��5    #   $	��150��6   $��5,0,0,0q�62   $��Center=�6C   $
��Left=�6^   �� 5"      $��Trạng thái:��6   $��Center=�6*   $
��Left=�6E   �� 5#      -   5        $��	cboStatus��5#   #   $	��120��6   $��5,0,0,0q�64   $��Center=�6E   $
��Left=�6`   �� 5%      -	   5        $��	btnSearch��5%   (   $��Tìm kiếm��6   $	��100��6Q   $��5,0,0,0q�6]   �� 5&      -
   5        $��	btnExport��5&   (   $��Kết xuất��6   $	��100��6Q   $��5,0,0,0q�6]   5'      &   System.Windows.Controls.DataGrid  5)   
   -   5        $��	dgrEstate��5)      $��1��6%      AutoGenerateColumns .   � ContextMenu# [  6P      CanUserAddRows .  $��Bottom=�5+   3   	   RowStyle	 5,      �� 5-      
 �� 
TargetType)  #System.Windows.Controls.DataGridRow"
  6   .�5.      -   5         �� Triggers 5/      P� 50       P� Property �@ AlternationIndex P� Value$ 0��6>   . �51      ��  �� Property � �� �� Value �	#FFEDEDED6;   52      54         Columns 56      0  *System.Windows.Controls.DataGridTextColumn  57      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ 	Tên BĐS��6W      MinWidth$	 250Q�6h   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Estate_Name+6h     58       . $ Mã BĐS��6W   $	 100Q�6g    6%   �� *Estate_Code+6g     59       . $ 	Tòa nhà��6Y   $	 150Q�6j    6%   �� *Building_Name+6j     5:       . $ Loại��6\   $	 150Q�6j    6%   �� *Estate_Type_Name+6j     5;       . $ Trạng thái��6W   $	 150Q�6k    6%   �� *Status_Name+6k     5<       . $ Diện tích��6P   $	 150Q�6c    6%   �� *Area+6c     5=       . $ Ghi chú��6P   $	 200Q�6a    6%   �� *Note+6a   5@      � 5B   
   $��2��6     
BottomGrid#���  6   .+�5C      �� $ 
Horizontal=�6   $��Center=�62   $��Center=�6M   .+�5D      �� -   5        $��	btnInsert��5D      $��5,0,0,0q�6*   $��Center=�6;   $��Center=�6X   $��Thêm��6s   $��75��6�   6�   �� 5E      -   5        $��	btnUpdate��5E      $��5,0,0,0q�6*   $��Center=�6<   $��Center=�6Y   $��Sửa��6t   $��75��6�   6�   �� 5F      -   5        $��	btnDelete��5F      $��5,0,0,0q�6*   $��Center=�6<   $��Center=�6Y   $
��Xóa��6t   $��75��6�   6�   �� 5G      -   5        $��btnView��5G      $��5,0,0,0q�6(   $��Center=�6:   $��Center=�6W   $	��Xem��6r   $��75��6�   6�   5H      5I      5J      5K      