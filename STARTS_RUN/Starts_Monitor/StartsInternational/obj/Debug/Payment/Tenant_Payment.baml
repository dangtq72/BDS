   M S B A M L   `   `   `  ����  StartsInternational0    *StartsInternational.Payment.Tenant_Payment   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5        $��frmTenant_Payment��5   	     � Title$"  Thanh toán phí môi giới��5   	   $	��450��6)   $	��750��66    � WindowStartupLocation$ CenterScreen=�5   /      WindowFormStyle#���   5   	   .��5      �  � RowDefinitions 5	   
   �� 5
      �� 5      $��35 �6   .+�5   
   �  5      �� 5      �� 5      $��85 �6    .+�5      � $��0��6   .+�5      �� $.��(Lịch sử thanh toán phí môi giới��6   .��5      &   System.Windows.Controls.DataGrid  -   5        $��dgrFee��5         AutoGenerateColumns .     CanUserAddRows .  $��Bottom=�5   3      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Lần TT��6f      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6v    " ElementStyle_VerticalAlignment1  +System.Windows.Controls.DataGridBoundColumn	   ElementStyle#	 �  6�   
   Binding
 61   �� *Number_Payment+6�     5       . $ Thời gian TT��6�   $	 110 6�     ElementStyle#	 �  6�   
 61   �� *Pay_Date_Expected+ �� StringFormat$ 
dd/MM/yyyy��6�     5       . $ Số tiền phải TT��6x   $	 140 6�     ElementStyle_Number#	 �  6�   
 61   �� *Fee_Expected+$ #,##0��6�     5       . $ Số tiền đã TT��6o   $	 140 6�   #	 �  6�   
 61   �� *Fee+$ #,##0��6�     5       . $ 	Còn nợ��6x   $	 130 6�   #	 �  6�   
 61   �� *Debit_Amount+$ #,##0��6�     5       . $ Trạng thái TT��6g   $ * 6~   
 61   �� *Pay_Status_Name+	 5   "   �� 5    &    �� 
TargetType" ��6,   .�5!   *   ��  �� Property �@��TextAlignment �� Value$
 Left=�6J   �� 5"   *    � ��$ 5,0,0,0q�6C   �� 5#   *    � ��$ Center=�6N   �� 5$   *    � ��$
 Bold"�6G    �� Triggers 5%   *   �� 5&   .    �� Binding 6:   ��  �� Path$ 
Pay_Status� �� Value 16^   .a�5'   2   ��  � ��
 � � �6O   5(   /   �� 5)   .    6:   �� $ 
Pay_Status� 06^   .a�5*   2   ��  � ��
 �  ��6O   5+   /   5-   '   5/      51      52      53      � 55      $��1��6   .+�56      �� $��Thanh toán trong kỳ��6   .��57      �  � ColumnDefinitions 58      �� 59      $	��130 �6/   �� 5:      $��* �6/    5<      �� 5=      $��25 �6,   �� 5>      $��25 �6,   �� 5?      $��25 �6,   .+�5B      �� $��Số tiền phải TT��6    $��0��6:   $��0��6J   $��Right=�6W   $��0,0,3,0q�6s   $��Center=�6�   �� 5C      -   5        $��txtFeeExpected��5C   4   {�.  $��1��6J   $	��120��6Z   $��0��6f   $
��Left=�6s   $��0,0,3,0q�6�   $��Center=�6�   6�   �� 5E      $��Ngày TT mong đợi��6    $��1��6;   $��0��6K   $
��Left=�6X   $��	135,0,0,0q�6s   $��Center=�6�   �� 5F      -   5        $��txtPay_Date_Expected��5F   4   {�.  $��1��6P   $��0��6`   $
��Left=�6m   $��Center=�6�   $	��120��6�   $��	240,0,3,0q�6�   �� 5H      $��Số tiền TT��6    $��0��65   $��1��6E   $��Right=�6R   $��0,0,3,0q�6n   $��Center=�6   �� 5I      -   5        $��	txtFeePay��5I   "   $��1��63   $	��120��6C   $��1��6O   $
��Left=�6\   $��0,0,3,0q�6w   $��Center=�6�   6�   �� 5K      $��Ngày TT��6    $��1��62   $��1��6B   $
��Left=�6O   $��	135,0,0,0q�6j   $��Center=�6}   (  "System.Windows.Controls.DatePicker  5L      -   5        $��
dpPay_Date��5L   %   $��1��67   $��1��6G   $
��Left=�6T   $��Center=�6o   $	��120��6�   $��	240,0,3,0q�6�   5N      5O      5P      5Q      � 5S   
   -   5        $��	grdButton��5S   L   $��1��6     
BottomGrid#���  6   $��0q�6A   .+�5T      � $��Center=�6   $��Center=�60   .+�5U      �� -   5        $��btnChapNhan��5U   n   $��Chấp nhận��6   $��90��6-   $
��Left=�68   $��Center=�6S   $��0,0,0,0q�6�   6�   �� 5V      -	   5        $��btnHuy��5V   b   $��Thoát��6   $��90��6)   $
��Left=�64   $��	100,0,0,0q�6O   $��Center=�6p   6�   5W      5X      5Y      5Z      