   M S B A M L   `   `   `  ����H  DAvalonDock, Version=1.3.3585.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock  5   	    StartsInternational&    StartsInternational.TraceDisplay   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;ad,clr-namespace:AvalonDock;assembly=AvalonDock     5   	   -   5            AvalonDock.DockableContent   Name$  frmtracedisplay��5   	      AvalonDock.ManagedContent   Title$ Thông tin thay đổi��5   	   $	��500��5   "   $
��1024��6/   .��5      � ���#F4F4F5 � RowDefinitions 5	   
   �� 5
      $��35 �6   �� 5      $��* �6   �� 5      $��35 �6   .+�5   
   �� ���#171e28$��1,1,1,0q�6'   ._�5      � -   5        $��grdtop��5         
BottomGrid#���   6!   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�66   .+�5      �� $��Center=�6   $��Tên bảng:��67   $��10,0,0,0q�6K   �� 5      -   5         ��Name$ 
cboTenbang��5      $��Stretch=�5      $��Center=�6=   $��Center=�6X   $��1��5   3   $	��150��6@   �� 5      $��Center=�6   $��Người thực hiện:��67   $��10,0,0,0q�6R   �� 5      -   5        $ cboNguoidung��5      $��Center=�5      $��Center=�6:   $��2��5   5   $	��120��6B   �� 5      $��Center=�6   $��Từ ngày:��67   $��10,0,0,0q�6J   (  "System.Windows.Controls.DatePicker  5      -   5        $��dtTungay��5   =   $��5��6!   $	��100��61   $��Center=�6M   �� 5      $��Center=�6   $��Đến ngày:��67   $��10,0,0,0q�6K     5      -   5        $��	dtDenngay��5   =   $��7��6!   $	��100��61   $��Center=�6N   �� 5       -   5        $��btnTim��5    J   $��Center=�6   $��10,0,0,0q�68   $��7��5!      $��Tìm kiếm��6?   $��70��6R   �� 5"      -   5        $��btnRefreshMsgOut��5"      $��
Làm mới��65   $��35,0,0,0q�6G   $��75��6Y   $��Center=�5#      $y�	Collapsed=�6X   5%      5&      5'      &   System.Windows.Controls.DataGrid  5)   
   -	   5        $��	gridtrace��5*      $��0,0,0,0q�5)         CanUserAddRows .  $��1��6<      AutoGenerateColumns .     RowHeaderWidth$ 30Q�6g      RowStyle 5,      �� 5-      	 �� 
TargetType)  #System.Windows.Controls.DataGridRow"	  6   .�5.      -
   5        5/      
   Columns
 52      0  *System.Windows.Controls.DataGridTextColumn  53        LeftAlignStyle1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# �  6B   ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ UserID��6�      Width5	  /System.Windows.Controls.DataGridLengthConverter$ 50	 6�      
Visibility$ Hidden=�6�      Binding 6%   �� *
Trace_Id+6�     54      $ Tên Bảng��6%   # �  6Y    .    MinWidth$	 250Q�6�    67   �� *Trace_Object+6�     55      $ Tên Thủ Tục��6%   # �  6^    . $	 250Q�6�    6:   �� *Trace_Procedure+6�     56      $ Người Thực Hiện��6%   # �  6^    . $	 200	 6�    6>   �� *
Trace_User+6�     57      $ Thời Gian��6%     CenterAlignStyle# �  6s    . $
 100*	 6�    68   �� *Trace_Datetime+ �� StringFormat$ 
dd/MM/yyyy��6�   59      �� 5;   
   $��2��6   ���#171e28$��1,0,1,1q�64   ._�5<      � #���   6   .+�5=      �� -   5        $��lblTotalPage��5=      $��Tổng số trang:��6,   $
��Left=�6E   $��Center=�6`   �� 5>      $ 
Horizontal=�6   $��Center=�66   $��Center=�6Q   .+�5?      �� -   5        $��btnPrivewMsgOut��5?      $��<��64   $��30��6C   $��Center=�6N   $��Center=�6i   6�   �� 5@      -   5        $��
txtPageOut��5@      $��5,0,0,0q�60   $��50��6A    �� 
IsReadOnly . $��Center=�6^   $��Center=�6�   $��Center=�6�   �� 5A      -   5        $��btnNextMsgOut��5A      $��5,0,0,0q�62   $��>��6C   $��30��6R   $��Center=�6]   6x   5B      �� 5C      $��0,0,60,0q�6   $'��!Số bản ghi trên một trang:��6*   $��Right=�6O   $��Center=�6k   �� 5D      -   5        $��cboTotalRow��5D      $��50��60   $��Right=�6;   $��Center=�6X   $��0,0,10,0q�6s   6�   5E      5F      5G      5H      