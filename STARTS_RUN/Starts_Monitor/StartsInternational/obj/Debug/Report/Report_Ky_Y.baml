   M S B A M L   `   `   `  ����H  DAvalonDock, Version=1.3.3585.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock  5   	   N JStartsInternational, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:StartsInternational.CustomUserControl%StartsInternational.CustomUserControl 5   	   ,   &StartsInternational.Report.Report_Ky_Y   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;ad,clr-namespace:AvalonDock;assembly=AvalonDock     5   	   Bus3clr-namespace:StartsInternational.CustomUserControl     5   	   -   5        $��frmReport_Ky_Y��5   	      AvalonDock.ManagedContent    Title$'  !Báo cáo gia hạn hợp đồng��5   	   $	��420��6*   $
��1024��67    � 	Resources 5
         Cmu m� InputGestureText��%�   &	        �� 5   
   ���#D5DCE6.@�5      m� -   5        $
��View��5      $ F5��6%   
���   �6O   m� 5      -   5        $��Print��5      $  ��6&   
���   �6N   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $
��Left=�6I   .+�5      �� $��Mã HĐ��6   $��Center=�6$   $
��Left=�6?   ?  9StartsInternational.CustomUserControl.AutoCompleteTextBox  5      -   5          Name$ txtCode��5   %   $��Center=�66   $	��150��6Q   $��5,0,0,0q�6]   �� 5      $��	Tòa nhà��6   $��Center=�6&   $
��Left=�6A   �� 5      -   5        $��cboBuilding��5   #   $	��120��6   $��5,0,0,0q�66   $��Center=�6G   $
��Left=�6b   �� 5      $��Trạng thái HĐ��6   $��Center=�6,   $
��Left=�6G   �� 5      -   5        $��	cboStatus��5   #   $	��120��6   $��5,0,0,0q�64   $��Center=�6E   $
��Left=�6`   �� 5!      -   5        $��	btnSearch��5!   (   $��Tìm kiếm��6   $	��100��6S   $��5,0,0,0q�6_   �� 5"      -   5        $��	btnExport��5"   (   $��Kết xuất��6   $	��100��6S   $��5,0,0,0q�6_   5#      &   System.Windows.Controls.DataGrid  5%   
   -	   5        $��dgrContract��5%      $��1��6'      AutoGenerateColumns .   � ContextMenu# [  6R      CanUserAddRows .  $��Bottom=�5'   3   	   RowStyle	 5(      �� 5)      
 �� 
TargetType)  #System.Windows.Controls.DataGridRow"
  6   .�5*      -
   5         �� Triggers 5+      P� 5,       P� Property �@ AlternationIndex P� Value$ 0��6>   . �5-      ��  �� Property � �� �� Value �	#FFEDEDED6;   5.      50         Columns 52      0  *System.Windows.Controls.DataGridTextColumn  53      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Mã hợp đồng��6Y      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6n   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Contract_Code+6n     54       . $ Số lần gia hạn��6m   $	 100 6�     ElementStyle   ElementStyle# �  6�    6%   �� *Number_Extend+ �� StringFormat$ #,##0��6�     55       . $ 	Ngày ký��6q   $	 100 6�    6%   �� *Contract_Date+$ 
dd/MM/yyyy��6�     56       . $! Trạng thái hợp đồng��6W   $	 150 6t    6%   �� *Status_Name+6t     57       . $ Bên YC môi giới��6W   $	 350 6p    6%   �� *Object_Name+6p   59      5:      5;      