   M S B A M L   `   `   `  ����H  DAvalonDock, Version=1.3.3585.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock  5   	    StartsInternational.   (StartsInternational.Report.Report_QuaHan   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;ad,clr-namespace:AvalonDock;assembly=AvalonDock     5   	   -   5        $��frmReport_QuaHan��5   	      AvalonDock.ManagedContent    Title$"  Báo cáo trạng thái phí��5   	   $	��420��6(   $
��1024��65    � 	Resources 5	         Cmu m� InputGestureText��%�   &	        �� 5
   
   ���#D5DCE6.@�5      m� -   5        $
��View��5      $ F5��6%   
���   �6O   m� 5      -   5        $��Print��5      $  ��6&   
���   �6N   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $
��Left=�6I   .+�5      �� $��Trạng thái phí��6   $��Center=�6-   $
��Left=�6H   �� 5      -   5        $��cboFee��5   #   $	��180��6   $��5,0,0,0q�61   $��Center=�6B   $
��Left=�6]   �� 5      -   5        $��	btnSearch��5   (   $��Tìm kiếm��6   $	��100��6S   $��5,0,0,0q�6_   �� 5      -   5        $��	btnExport��5   (   $��Kết xuất��6   $	��100��6S   $��5,0,0,0q�6_   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgrContract��5      $��1��6'      AutoGenerateColumns .   � ContextMenu# [  6R      CanUserAddRows .  $��Bottom=�5    3      RowStyle 5!      �� 5"      	 �� 
TargetType)  #System.Windows.Controls.DataGridRow"	  6   .�5#      -   5        
 �� Triggers
 5$      P� 5%       P� Property �@ AlternationIndex P� Value$ 0��6>   . �5&      ��  �� Property � �� �� Value �	#FFEDEDED6;   5'      5)         Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Mã hợp đồng��6Y      MinWidth$	 200Q�6n   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Contract_Code+6n     5.       . $ 	Ngày ký��6q   $	 100Q�6�    6%   �� *Contract_Date+ �� StringFormat$ 
dd/MM/yyyy��6�     5/       . $! Trạng thái hợp đồng��6W   $	 150Q�6t    6%   �� *Status_Name+6t     50       . $ Bên YC môi giới��6W   $	 350Q�6p    6%   �� *Object_Name+6p   52      53      54      