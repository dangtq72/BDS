   M S B A M L   `   `   `  ����H  DAvalonDock, Version=1.3.3585.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock  5   	    StartsInternational-   'StartsInternational.Display.UserDisplay   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;ad,clr-namespace:AvalonDock;assembly=AvalonDock     5   	   -   5            AvalonDock.DockableContent   Name$  frmUserDisplay��5   	      AvalonDock.ManagedContent   Title$% Thông tin người sử dụng��5      $	��420��5   	   $
��1024��6    � 	Resources 5         Cmu m� InputGestureText m�Name��%b  &	        �� 5	   
   ���#D5DCE6.@�5
      m� -   5        $��_Thêm mới��5
      $ F3��6*   
���   �6T   m� 5      -   5        $��Sửa��5      $ F4��6$   
���   �6M   m� 5      -   5        $
��Xóa��5      $	 Del��6$   
���   �6O   m� 5      -   5        $
��View��5      $ F5��6%   
���   �6O   m� 5      -   5        $��Reset mật khẩu��5      $ F6��6/   
���   �6Y   �� 5      ���#B9B9B96   m� 5      $ Cmu_SetRight��6T   -   5        $��Phân quyền��5      $ F7��6+   
���   �6j   5      5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��35 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dgrUser��5      $��0��6#      AutoGenerateColumns .   � ContextMenu# [  6N      CanUserAddRows .  $��Bottom=�5   3   	   RowStyle	 5      �� 5      
 �� 
TargetType)  #System.Windows.Controls.DataGridRow"
  6   .�5       -	   5         �� Triggers 5!      P� 5"       P� Property �@ AlternationIndex P� Value$ 0��6>   . �5#      ��  �� Property � �� �� Value �	#FFEDEDED6;   5$      5&         Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Tên đăng nhập��6U      MinWidth$	 150Q�6l   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	User_Name+6l     5*       . $ Tên đầy đủ��6T   $	 200Q�6h    6%   �� *
FullName+6h     5+       . $ Nhóm người dùng��6V   $	 200Q�6o    6%   �� *
Group_Name+6o     5,       . $&  Lần đăng nhập gần nhất��6w   $	 200Q�6�    6%   �� *
Last_Login+ �� StringFormat$ dd/MM/yyyy:HH:MM:SS��6�   5.      � 50   
   $��1��6     
BottomGrid#���  6   .+�51      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Center=�6M   .+�52      �� -
   5        $��btnRight��52      $��5,0,0,0q�6)   $��Center=�6:   $��Center=�6W   $��Phân quyền��6r   $��75��6�   6�   �� 53      -   5        $��	btnInsert��53      $��5,0,0,0q�6*   $��Center=�6;   $��Center=�6X   $��Thêm mới��6s   $��75��6�   6�   �� 54      -   5        $��	btnUpdate��54      $��5,0,0,0q�6*   $��Center=�6<   $��Center=�6Y   $��Cập nhật��6t   $��75��6�   6�   �� 55      -   5        $��	btnDelete��55      $��5,0,0,0q�6*   $��Center=�6<   $��Center=�6Y   $
��Xóa��6t   $��75��6�   6�   �� 56      -   5        $��btnReset��56      $��5,0,0,0q�6)   $��Center=�6;   $��Center=�6X   $��Reset mật khẩu��6s   $��95��6�   6�   �� 57      -   5        $��btnView��57      $��5,0,0,0q�6(   $��Center=�6:   $��Center=�6W   $	��Xem��6r   $��75��6�   6�   58      59      5:      5<      