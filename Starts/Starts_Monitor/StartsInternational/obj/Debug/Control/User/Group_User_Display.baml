   M S B A M L   `   `   `  ����H  DAvalonDock, Version=1.3.3585.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock  5   	    StartsInternational,   &StartsInternational.Group_User_Display   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;ad,clr-namespace:AvalonDock;assembly=AvalonDock     5   	   -   5            AvalonDock.DockableContent   Name$  frmGroupUser��5   D      AvalonDock.ManagedContent   Title$% DANH SÁCH NHÓM NGƯỜI DÙNG��6	   $	��300��6+   $	��900��68    � 	Resources 5       ��Name   Cmu m�Name m� InputGestureText*  $System.Windows.Controls.DataGridCell �� 
TargetType��%�  &	        '  P    �� 5	   
   $ cmuUser��67   ���#D5DCE6.@�5
      m� $ Cmu_Add��6?   -   5        $��Thêm mới��5
      $ F3��6)   6P   m� 5      $ 
Cmu_Update��6?   -   5        $��Cập nhật��5      $ F4��6)   6S   m� 5      $ Cmu_View��6:   -   5        $	��Xem��5      $ F5��6$   6L   m� 5      $ Cmu_DelCorporateInfo��6N   -   5        $
��Xóa��5      $	 Del��6$   
���   �6l   �� 5      ���#B9B9B96   m� 5      $ Cmu_SetRight��6T   -   5        $��Phân quyền��5      $ F7��6+   
���   �6j   5      �� 5   
   "  6   .�5      -   5        5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��0 �6   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dgrGroupUser��5       $��1��6   $��Stretch=�64   $��1,0,1,0q�6P    � ContextMenu# [  6a   	   CanUserAddRows	 .  
   AutoGenerateColumns
 .  $��3��5   o      RowStyle 5       �� 5!      )  #System.Windows.Controls.DataGridRow"  6   .�5"      -	   5         �� Triggers 5#      P� 5$       P� Property �@ AlternationIndex P� Value$ 0��6>   . �5%      ��  �� Property � �� �� Value �	#FFEDEDED6;   5&      5(         Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5,         
FontWeight$
 Bold"�6%   ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 180 6b     CenterAlignStyle1	  +System.Windows.Controls.DataGridBoundColumn 	  ElementStyle# [ 6n     TextCell   	CellStyle# �  6�    	  Binding 67   �� *Name+   Header 5-      �� 5.      $%��Tên nhóm người sử dụng��6    $��Center=�6A   $��28��6\   $
��Bold"�6h   50        51      $
 Bold"�6%    . $ * 6b   # [ 6l   # �  6�    67   �� *Note+ 52      �� 53      $��Ghi chú��6    $��Center=�62   $��28��6M   $
��Bold"�6Y   55      57      � 59   
   $��2��6     
BottomGrid#���  6   $��0q�6A   .+�5:      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Center=�6O   .+�5;      �� -
   5        $��btnPhanQuyen��5;   u   $��Phân quyền��6   $
��Left=�6.   $��Center=�6I   $��0,0,0,0q�6d   $��4��6�     Button90#���  6�   �� 5<      -   5        $��btnView��5<   o   $	��Xem��6   $
��Left=�6'   $��Center=�6B   $��10,0,0,0q�6]   $��5��6�   #���  6�   �� 5=      -   5        $��btnThem��5=   Y   $��Thêm mới��6   $
��Left=�6,   $��10,0,0,0q�6G   $��Center=�6h   $��6��6�   #���  6�   �� 5>      -   5        $��btnSua��5>   Y   $��Cập nhật��6   $
��Left=�6,   $��10,0,0,0q�6G   $��Center=�6g   $��7��6�   #���  6�   �� 5?      -   5        $��btnXoa��5?   T   $
��Xóa��6   $
��Left=�6'   $��10,0,0,0q�6B   $��Center=�6b   $��8��6�   #���  6�   �� 5@      -   5        $��btnThoat��5@   V   $��Thoát��6   $
��Left=�6)   $��10,0,0,0q�6D   $��Center=�6f   $��9��6�   #���  6�   5A      5B      5C      5D      