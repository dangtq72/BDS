   M S B A M L   `   `   `  ����N  JStartsInternational, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:StartsInternational.CustomUserControl%StartsInternational.CustomUserControl  5   	   B    <StartsInternational.Contract.Display.Contract_HetHan_Display   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Bus3clr-namespace:StartsInternational.CustomUserControl     5   	   -   5          �Name$   frmContract_HetHan_Display��5   	    � Title$0 *Thông tin hợp đồng sắp hết hạn��5   	    � WindowStartupLocation$ CenterScreen=�5   	   $	��420��5   	   $
��1024��6      WindowFormStyle#���   6#    � 	Resources 5
        Cmu m� InputGestureText��%  &	       �� 5   
   ���#D5DCE6.@�5      m� -   5        $��Sửa��5      $ F4��6$   
���   �6M   m� 5      -   5        $
��View��5      $ F5��6%   
���   �6O   m� 5      -   5        $��Yc TT��5      $ F8��6&   
���   �6P   5      5      .��5      �  � RowDefinitions 5   
   �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dgrContract��5      $��1��6'      AutoGenerateColumns .   � ContextMenu# �  6R      CanUserAddRows .  $��Bottom=�5   3   	   RowStyle	 5      �� 5      
 �� 
TargetType)  #System.Windows.Controls.DataGridRow"
  6   .�5      -   5         �� Triggers 5      P� 5       P� Property �@ AlternationIndex P� Value$ 0��6>   . �5      ��  �� Property � �� �� Value �	#FFEDEDED6;   5       5"         Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Mã hợp đồng��6Y      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6n   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Contract_Code+6n     5&       . $ 	Ngày ký��6q   $	 100 6�    6%   �� *Contract_Date+ �� StringFormat$ 
dd/MM/yyyy��6�     5'       . $ 
Từ ngày��6u   $	 100 6�    6%   �� *Contract_FromDate+$ 
dd/MM/yyyy��6�     5(       . $ Đến ngày��6v   $	 100 6�    6%   �� *Contract_ToDate_Ex+$ 
dd/MM/yyyy��6�     5)       . $! Trạng thái hợp đồng��6W   $	 150 6t    6%   �� *Status_Name+6t     5*       . $ Bên YC môi giới��6W   $ * 6p    6%   �� *Object_Name+6p   5,      5.      50      