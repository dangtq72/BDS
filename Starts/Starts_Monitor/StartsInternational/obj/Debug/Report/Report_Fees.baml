   M S B A M L   `   `   `  ����H  DAvalonDock, Version=1.3.3585.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock  5   	    StartsInternational,   &StartsInternational.Report.Report_Fees   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;ad,clr-namespace:AvalonDock;assembly=AvalonDock     5   	   -   5        $��frmReport_Fees��5   	      AvalonDock.ManagedContent    Title$   Báo cáo phí môi giới��5   	   $	��420��6&   $
��1024��63    � 	Resources 5	         Cmu m� InputGestureText��%�   &	        �� 5
   
   ���#D5DCE6.@�5      m� -   5        $
��YCTT��5      $ F8��6%   
���   �6O   m� 5      -   5        $��Print��5      $  ��6&   
���   �6N   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��Center=�6;   $
��Left=�6V   .+�5      �� $��Từ ngày   ��6   (  "System.Windows.Controls.DatePicker  5      -   5        $��
dpFromDate��5      $
��Left=�6+   $��Center=�6F   $	��120��6a   $��5,0,0,0q�6m   �� 5      $��Đến ngày��6   $��Center=�6'   $��5,0,0,0q�6B   $
��Left=�6S     5      -   5        $��dpToDate��5      $
��Left=�6)   $��Center=�6D   $	��120��6_   $��5,0,0,0q�6k   �� 5      $��Khách hàng��6   $��Center=�6)   $��5,0,0,0q�6D   $
��Left=�6U   �� 5      -   5        $��txtCustomer��5      $	��150��6)   $��5,0,0,0q�66   $��Center=�6G   $
��Left=�6b   5!      �� 5"   
   $ 
Horizontal=�6   $��1��6.   $��Center=�6;   $
��Left=�6V   .+�5$      �� $��Tài khoản��6   $��Center=�6(   $
��Left=�6C   �� 5%      -   5        $��cboCreatedBy��5%   #   $	��120��6   $��5,0,0,0q�67   $��Center=�6H   $
��Left=�6c   �� 5'      $��Mã BĐS   ��6   $��5,0,0,0q�6(   $��Center=�69   $
��Left=�6T   �� 5(      -   5        $��cboEsateCode��5(      $	��120��6+   $��5,0,0,0q�68   $��Center=�6I   $
��Left=�6d   �� 5*      $��Người SD��6   $��5,0,0,0q�6'   $��Center=�68   $
��Left=�6S   �� 5+      -	   5        $��txtUser��5+      $	��150��6%   $��15,0,0,0q�62   $��Center=�6D   $
��Left=�6_   �� 5-      -
   5        $��	btnSearch��5-   (   $��Tìm kiếm��6   $	��100��6S   $��10,0,0,0q�6_   �� 5.      -   5        $��	btnExport��5.   (   $��Kết xuất��6   $	��100��6S   $��5,0,0,0q�6_   5/      &   System.Windows.Controls.DataGrid  51   
   -   5        $��dgrContract��51      $��2��6'      AutoGenerateColumns .   � ContextMenu# [  6R      CanUserAddRows .  $��Bottom=�53   3      RowStyle 54      �� 55      	 �� 
TargetType)  #System.Windows.Controls.DataGridRow"	  6   .�56      -   5        
 �� Triggers
 57      P� 58       P� Property �@ AlternationIndex P� Value$ 0��6>   . �59      ��  �� Property � �� �� Value �	#FFEDEDED6;   5:      5<         Columns 5>      0  *System.Windows.Controls.DataGridTextColumn  5?      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Mã BĐS��6W      MinWidth$	 150Q�6g   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Estate_Code+6g     5@       . $ 	Tên BĐS��6W   $	 150Q�6h    6%   �� *Estate_Name+6h     5A       . $ Thời gian��6u   $	 100Q�6�    6%   �� *Contract_FromDate+ �� StringFormat$ 
dd/MM/yyyy��6�     5B       . $ Tên khách hàng��6Y   $	 150Q�6q    6%   �� *Customer_Name+6q     5C       . $ Tên NSD��6Q   $	 150Q�6b    6%   �� *Users+6b     5E       . $ Tiền môi giới��6i   $	 150Q�6�    6%   �� *	PhiMoiGio+$ #,##0��6�     5F       . $ Hạn chuyển tiền��6q   $	 100Q�6�    6%   �� *HanChuyenTien+$ 
dd/MM/yyyy��6�     5H       . $ Tiền đã về��6h   $	 150Q�6|    6%   �� *
TienDaVe+$ #,##0��6|     5I       . $ Tiền chưa về��6j   $	 150Q�6�    6%   �� *
TienChuaVe+$ #,##0��6�   5L      5M      5N      