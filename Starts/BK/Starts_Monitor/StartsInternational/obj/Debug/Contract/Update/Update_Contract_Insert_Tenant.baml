   M S B A M L   `   `   `  ����N  JStartsInternational, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:StartsInternational.ContractStartsInternational.Contract  5   	   9    3StartsInternational.Contract.Update_Contract_Tenant   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   <local*clr-namespace:StartsInternational.Contract     5   	   -   5        $��frmContract_Insert_Tenant��5   	     � Title$J  DSỬA HỢP ĐỒNG MÔI GIỚI BẤT ĐỘNG SẢN (cho thuê nhà)��5   	   $	��780��6C    � 
ResizeMode$ NoResize=�5   	    � SizeToContent$ Height=�6    � WindowStartupLocation$ CenterScreen=�66      WindowFormStyle#���   5	   	    � 	Resources 5
      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value:  4System.Windows.Controls.Primitives.DatePickerTextBox��%#  '        '  �     �� 5   
   "  6   .�5      ��  � ��$
 Bold"�6+   �� 5       � ��$ Center=�69   �� 5       � ��$ Center=�6;   �� 5       � ��$ 30��6'   5      �� 5   
   "  6   .�5      ��  �@��
IsReadOnly . 6+   5      5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��35 �6   .+�5   
   �� $��0��6   .@�5      �� -   5        $��tabContract��5   (   $��Hợp đồng��6   .��5      � $��0��6    5      �� 5      $	��135 �6(   �� 5      $	��165 �6(   �� 5       $	��190 �6(   .+�5#      �� $��0��6   $��5,0,0,0q�6,   $4��.Thông tin đối tượng bất động sản��6=   .��5$      � 	 � ColumnDefinitions	 5%      �� 5&   "   $	��130 �63   �� 5'   "   $��* �63    5)      �� 5*   "   $��25 �60   �� 5+   "   $��25 �60   �� 5,   "   $��25 �60   �� 5-   "   $��25 �60   �� 5.   "   $��25 �60   .+�51      �� $��Tên căn hộ:��6$   $��0��6:   $��0��6J   $��Right=�6W   $��0,0,3,0q�6s   $��Center=�6�   �� 52      $��Mã căn hộ:��6$   $��0��69   $��1��6I   $��Right=�6V   $��0,0,3,0q�6r   $��Center=�6�   �� 53      $��Kiểu nhà:��6$   $��0��68   $��2��6H   $��Right=�6U   $��0,0,3,0q�6q   $��Center=�6�   �� 54      $��Diện tích:��6$   $��1��69   $��2��6I   $
��Left=�6V   $��	200,0,3,0q�6q   $��Center=�6�   �� 55      $��
Vị trí:��6$   $��0��66   $��3��6F   $��Right=�6S   $��0,0,3,0q�6o   $��Center=�6�   �� 57      -   5        $��lbl_Estate_Name��57   $   $�� ��6;   $��1��6F   $��0��6V   $
��Left=�6c   $��0,0,3,0q�6~   $��Center=�6�   �� 58      -   5        $��lbl_Estate_Code��58   $   $�� ��6;   $��1��6F   $��1��6V   $
��Left=�6c   $��0,0,3,0q�6~   $��Center=�6�   �� 59      -   5        $��lbl_Estate_Type_Name��59   $   $�� ��6@   $��1��6K   $��2��6[   $
��Left=�6h   $��0,0,3,0q�6�   $��Center=�6�   �� 5:      -   5        $��lbl_Estate_Area��5:   $   $�� ��6;   $��1��6F   $��2��6V   $
��Left=�6c   $��	250,0,3,0q�6~   $��Center=�6�   �� 5;      -   5        $��lbl_Address��5;   $   $��1��69   $��3��6I   $
��Left=�6V   $��0,0,3,0q�6q   $��Center=�6�   5=      5>      �� 5@      $��1��6   $	��155��6,   $��5,10,0,0q�69   $*��$Bên B - BÊN YÊU CẦU MÔI GIỚI��6K   .��5A      � 	 5B      �� 5C   "   $	��130 �63   �� 5D   "   $��* �63    5F      �� 5G   "   $��25 �60   �� 5H   "   $��25 �60   �� 5I   "   $��25 �60   �� 5J   "   $��25 �60   �� 5K   "   $��25 �60   �� 5L   "   $��25 �60   .+�5O      �� $&�� Tên tổ chức / Cá nhân(*):��6$   $��0��6H   $��0��6X   $��Right=�6e   $��0,0,3,0q�6�   $��Center=�6�   �� 5P      -   5        $��txtRenter_Name��5P   &   
 J� IsHitTestVisible
 .  |�.  $��1��6g   $��0��6w   $��Stretch=�6�   $��0,0,3,0q�6�   $��Center=�6�   �� 5R      $��Địa chỉ(*):��6$   $��0��6:   $��1��6J   $��Right=�6W   $��0,0,3,0q�6s   $��Center=�6�   �� 5S      -	   5        $��
txtAddress��5S   &   
 .  |�.  $��1��6c   $��1��6s   $��Stretch=�6�   $��0,0,3,0q�6�   $��Center=�6�   �� 5U      $��Chức vụ:��6$   $��0��67   $��2��6G   $��Right=�6T   $��0,0,3,0q�6p   $��Center=�6�   �� 5V      -
   5        $��txtPosition��5V   &   
 .  |�.  $��1��6d   $��2��6t   $
��Left=�6�   $	��220��6�   $��0,0,3,0q�6�   $��Center=�6�   �� 5X      $��Mã số thuế:��6$   $��1��6:   $��2��6J   $
��Left=�6W   $��	300,0,3,0q�6r   $��Center=�6�   �� 5Y      -   5        $��
txtTaxCode��5Y   &   
 .  |�.  $��1��6c   $��2��6s   $
��Left=�6�   $	��227��6�   $��	370,0,3,0q�6�   $��Center=�6�   �� 5[      $��Điện thoại(*):��6$   $��0��6=   $��3��6M   $��Right=�6Z   $��0,0,3,0q�6v   $��Center=�6�   �� 5\      -   5        $��txtPhone��5\   &   
 .  |�.  $��1��6a   $��3��6q   $
��Left=�6~   $	��220��6�   $��0,0,3,0q�6�   $��Center=�6�   �� 5^      $
��Fax:��6$   $��1��63   $��3��6C   $
��Left=�6P   $��	300,0,3,0q�6k   $��Center=�6~   �� 5_      -   5        $��txtFax��5_   &   
 .  |�.  $��1��6_   $��3��6o   $
��Left=�6|   $	��227��6�   $��	370,0,3,0q�6�   $��Center=�6�   �� 5a      $��CMND/HC:��6$   $��0��67   $��4��6G   $��Right=�6T   $��0,0,3,0q�6p   $��Center=�6�   �� 5b      -   5        $��txtIdentity_Card��5b   &   
 .  |�.  $��1��6i   $��4��6y   $
��Left=�6�   $	��220��6�   $��0,0,3,0q�6�   $��Center=�6�   5c      5d      �� 5f      $��2��6   $	��180��6,   $��5,10,0,0q�69   $��Thông tin hợp đồng��6K   .��5g      � 	 5h      �� 5i   "   $	��130 �63   �� 5j   "   $��* �63    5l      �� 5m   "   $��25 �60   �� 5n   "   $��25 �60   �� 5o   "   $��25 �60   �� 5p   "   $��25 �60   �� 5q   "   $��25 �60   �� 5r   "   $��25 �60   .+�5t      �� $��Mã hợp đồng(*)��6$   $��0��6=   $��0��6M   $��Right=�6Z   $��0,0,3,0q�6v   $��Center=�6�   �� 5u      $��Tên hợp đồng(*)��6$   $y�	Collapsed=�6>   $��0��6U   $��1��6e   $��Right=�6r   $��0,0,3,0q�6�   $��Center=�6�   �� 5w      -   5        $��txtContract_Code��5w   &   $��1��6>   $��0��6N   $��Stretch=�6[   $��0,0,3,0q�6y   $��Center=�6�   �� 5x      -   5        $��txtContract_Name��5x   &   $y�	Collapsed=�6>   $��1��6U   $��1��6e   $��Stretch=�6r   $��0,0,3,0q�6�   $��Center=�6�   �� 5z      $ ��Ngày ký hợp đồng(*)��6$   $��0��6B   $��1��6R   $��Right=�6_   $��0,0,3,0q�6{   $��Center=�6�   (  "System.Windows.Controls.DatePicker  5{      -   5        $��dpContractDate��5{   )   $��1��6�   $��1��6�   $
��Left=�6�   $��Center=�6�   $	��120��6�   $��0,0,3,0q�6�   �� 5}      $��Loại tiền��6$   $��1��68   $��1��6H   $
��Left=�6U   $��	150,0,0,0q�6p   $��Center=�6�   �� 5~      -   5        $��cboCurrency��5~   '   $	��120��6:   $��1��6F   $��1��6V   $
��Left=�6c   $��	250,0,3,0q�6~   $��Center=�6�   �� 5�      $��Thời gian thuê từ(*)��6$   $��0��6C   $��2��6S   $��Right=�6`   $��0,0,3,0q�6|   $��Center=�6�     5�      -   5        $��
dpFromDate��5�   )   $��1��6;   $��2��6K   $
��Left=�6X   $��Center=�6s   $	��120��6�   $��0,0,3,0q�6�   �� 5�      $��đến ngày(*)��6$   $��1��6:   $��2��6J   $
��Left=�6W   $��	150,0,3,0q�6r   $��Center=�6�     5�      -   5        $��dpToDate��5�   )   $��1��69   $��2��6I   $
��Left=�6V   $��Center=�6q   $	��120��6�   $��	250,0,3,0q�6�   �� 5�      $��Trạng thái HĐ��6$   $��0��6<   $��3��6L   $��Right=�6Y   $��0,0,3,0q�6u   $��Center=�6�   �� 5�      -   5        $��cboStatusContract��5�   '   $��1��6v   $��3��6�   $
��Left=�6�   $��Center=�6�   $	��120��6�   $��0,0,3,0q�6�   �� 5�      $��Người SD:��6$   $��0��68   $��4��6H   $��Right=�6U   $��0,0,3,0q�6q   $��Center=�6�   �� 5�      -   5        $��txtUsers��5�   &   $��1��66   $��4��6F   $��Stretch=�6S   $��0,0,3,0q�6q   $��Center=�6�   �� 5�      $��Đại diện(*):��6$   $��0��6;   $��5��6K   $��Right=�6X   $��0,0,3,0q�6t   $��Center=�6�   �� 5�      -   5        $��txtRepresentive��5�   '   $��1��6>   $��5��6N   $��Stretch=�6[   $��0,0,3,0q�6y   $��Center=�6�   5�      5�      5�      5�      �� 5�      -   5        $��tabFee��5�   ,   $��Phí môi giới��6   .��5�      �  5�      �� 5�      �� 5�       5�        StatusDataProvider S� 
ObjectType0   *StartsInternational.Contract.StatusPayment S� 
MethodName  DateTemplate �� StringFormat  EditingDateTemplate   SelectedDate��%:  &	       &	 -     &	 �    S� 5�      "  6H   $ 	GetStatus��6r   �� 5�      .R�5�      �� $��20��6)   $��30��64   .+�5�   "   �� 
����ح�
���   �$��1q�6T   ._�5�   &   �� $��8(�6k   $��Center=�6x   ��60   �� *Pay_Date_Expected+$ {0:MMM}��6x   5�   #   �� 5�   "   
�������
���   �$��1q�6P   ._�5�   &   �� $��8(�6l   $
��Bold"�6y   $��Center=�6�   ��60   �� *Pay_Date_Expected+$ {0:yyyy}��6�   5�   #   5�      5�      �� 5�      .R�5�         6)   �� *Pay_Date_Expected+5�      5�      .+�5�      �� $��0��6   $��75��6,   $��5,10,0,0q�68   $!��Thông tin Phí môi giới��6J   .��5�      � 	 5�      �� 5�   "   $	��130 �63   �� 5�   "   $��* �63    5�      �� 5�   "   $��25 �60   �� 5�   "   $��25 �60   .+�5�      �� $��Phí môi giới(*)��6$   $��0��6>   $��0��6N   $��Right=�6[   $��0,0,3,0q�6w   $��Center=�6�   �� 5�      -   5        $��txtFee��5�   &   $��1��6o   $	��120��6   $��0��6�   $
��Left=�6�   $��0,0,3,0q�6�   $��Center=�6�   �� 5�      $��Kỳ hạn thanh toán��6$   $��0��6@   $��1��6P   $��Right=�6]   $��0,0,0,0q�6y   $��Center=�6�   �� 5�      -   5        $��cboTerm��5�   '   $��1��66   $��1��6F   $
��Left=�6S   $��Center=�6n   $	��120��6�   $��0,0,0,0q�6�   6�   �� 5�      -   5        $��	lblFeePay��5�   ?   $��Số tiền 1 lần TT��6$   $��1��6P   $��0��6`   $
��Left=�6m   $��	135,0,3,0q�6�   $��Center=�6�   �� 5�      -   5        $��txtFeeOnePay��5�   &   {�.  $	��120��6n   $��1��6z   $��0��6�   $
��Left=�6�   $��	235,0,3,0q�6�   $��Center=�6�   �� 5�      -   5        $��lblNumberPay��5�   W   $��Số lần thanh toán��6$   $y�	Collapsed=�6@   $��1��6k   $��1��6{   $
��Left=�6�   $��	360,0,0,0q�6�   $��Center=�6�   �� 5�      -   5        $��txtNumberPay��5�   &   $y�	Collapsed=�6:   $	��120��6s   $��1��6   $��1��6�   $
��Left=�6�   $��	460,0,3,0q�6�   $��Center=�6�   �� 5�      -   5        $��btnCall��5�   M   $��
Tính phí��6%   $y�Visible=�68   
���  ��$
��Bold"�6�   $	��120��6�   $
��Left=�6�   $��1��6�   $��1��6�   $��Center=�6�   $��	235,0,0,0q�6�   5�      5�      �� 5�      $��1��6   $	��250��6,   $��5,10,0,0q�69   $��Thông tin thanh toán��6L   .��5�      � .+�5�      &   System.Windows.Controls.DataGrid  -    5        $��dgrFee��5�   '   $	��220��65      CanUserAddRows .     AutoGenerateColumns .     Columns 5�   "   0  *System.Windows.Controls.DataGridTextColumn  5�   &      
FontWeight$
 Bold"�69   ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6�     CenterAlignStyle1	  +System.Windows.Controls.DataGridBoundColumn 	  ElementStyle# [ 6�     TextCell   	CellStyle# �  6�    	  Binding 6K   �� *Number_Payment+   Header 5�   *   �� 5�   .   $��Lần TT��64   $��Center=�6E   $��28��6`   $
��Bold"�6l   5�   '   4
  .System.Windows.Controls.DataGridTemplateColumn
  5�   &   $	 120 6=    5�   *   �� 5�   .   $��Thời gian TT��64   $
��Bold"�6K    
  CellTemplate 5�   *   �� 5�   .   .R�5�   2   �� $��Center=�6<   $��Center=�6W   $��4q�6t   ��6   �� *Pay_Date_Expected+$ 
dd/MM/yyyy��5�   /    
  CellEditingTemplate 5�   *   �� 5�   .   .R�5�   2      6=   �� *Pay_Date_Expected+$ d��5�   /   5�   '     5�   &   $
 Bold"�69   $	 140 6�     RightAlignStyle# [ 5�   5    5�   K   �� *Fee_Expected+ �� Mode$ TwoWay=�$ #,##0�� 5�   *   �� 5�   .   $��Số tiền phải TT��64   $��Center=�6N   $��28��6i   $
��Bold"�6u   5�   '     5�   &   $
 Bold"�69   $	 140 6�   # [ 5�   5    5�   K   �� *Fee+$ TwoWay=�$ #,##0�� 5�   *   �� 5�   .   $��Số tiền đã TT��64   $��Center=�6L   $��28��6g   $
��Bold"�6s   5�   '     5�   &   $
 Bold"�69   $	 130 6�   # [ 5�   5    .  5�   K   �� *Debit_Amount+$ #,##0�� 5�   *   �� 5�   .   $��	Còn nợ��64   $��Center=�6E   $��28��6`   $
��Bold"�6l   5�   '   4  .System.Windows.Controls.DataGridComboBoxColumn  5�   &   $	 125 6i      SelectedValuePath$ StatusId��6u      DisplayMemberPath$ 
StatusName��5�   ,      SelectedValueBinding 5�   =   �� *
Pay_Status+   ItemsSource 5�   K   ��   �� Source#  [  5�   *   �� 5�   .   $��Trạng thái TT��64   $
��Bold"�6L   5�   '   5     5     5     5     5     �� 5
     -!   5        $��	tabExtend��5
  0   $��Gia hạn hợp đồng��6   .��5     �  5     �� 5     �� 5      5       StatusDataProvider_Extend  DateTemplate_Extend 	 EditingDateTemplate_Extend��%:  &	       &	 -     &		 �    S� 5     "  6O   $ 	GetStatus��6y   �� 5     .R�5     �� $��20��6)   $��30��64   .+�5  "   �� 
����ح�
���   �$��1q�6T   ._�5  &   �� $��8(�6k   $��Center=�6x   ��60   �� *Pay_Date_Expected+$ {0:MMM}��6x   5  #   �� 5  "   
�������
���   �$��1q�6P   ._�5  &   �� $��8(�6l   $
��Bold"�6y   $��Center=�6�   ��60   �� *Pay_Date_Expected+$ {0:yyyy}��6�   5  #   5     5     �� 5     .R�5        6)   �� *Pay_Date_Expected+5      5!     .+�5#     �� $��0��6   $	��105��6,   $��5,10,0,0q�69   $ ��Phí môi giới gia hạn��6K   .��5$     � 	 5%     �� 5&  "   $	��130 �63   �� 5'  "   $��* �63    5)     �� 5*  "   $��25 �60   �� 5+  "   $��25 �60   �� 5,  "   $��25 �60   .+�5.     �� $��Thời gian thuê từ(*)��6$   $��0��6C   $��0��6S   $��Right=�6`   $��0,0,3,0q�6|   $��Center=�6�     5/     -"   5        $��dpFromDate_Extend��5/  )   $��1��6B   $��0��6R   $
��Left=�6_   $��Center=�6z   $	��120��6�   $��0,0,3,0q�6�   �� 51     $��đến ngày(*)��6$   $��1��6:   $��0��6J   $
��Left=�6W   $��	150,0,3,0q�6r   $��Center=�6�     52     -#   5        $��dpToDate_Extend��52  )   $��1��6@   $��0��6P   $
��Left=�6]   $��Center=�6x   $	��120��6�   $��	235,0,3,0q�6�   �� 54     $��Phí môi giới(*)��6$   $��0��6>   $��1��6N   $��Right=�6[   $��0,0,3,0q�6w   $��Center=�6�   �� 55     -$   5        $��txtFee_Extend��55  &   $��1��6}   $	��120��6�   $��1��6�   $
��Left=�6�   $��0,0,3,0q�6�   $��Center=�6�   �� 57     -%   5        $��lblFeePay_Extend��57  ?   $��Số tiền 1 lần TT��6$   $��1��6W   $��1��6g   $
��Left=�6t   $��	135,0,3,0q�6�   $��Center=�6�   �� 58     -&   5        $��txtFeeOnePay_Extend��58  &   {�.  $	��120��6u   $��1��6�   $��1��6�   $
��Left=�6�   $��	235,0,3,0q�6�   $��Center=�6�   �� 5;     $��Kỳ hạn thanh toán��6$   $��0��6@   $��2��6P   $��Right=�6]   $��0,0,0,0q�6y   $��Center=�6�   �� 5<     -'   5        $��cboTerm_Extend��5<  '   $��1��6=   $��2��6M   $
��Left=�6Z   $��Center=�6u   $	��120��6�   $��0,0,0,0q�6�   6�   �� 5?     -(   5        $��lblNumberPay_Extend��5?  W   $��Số lần thanh toán��6$   $y�	Collapsed=�6@   $��1��6r   $��2��6�   $
��Left=�6�   $��	360,0,0,0q�6�   $��Center=�6�   �� 5@     -)   5        $��txtNumberPay_Extend��5@  &   $y�	Collapsed=�6A   $	��120��6z   $��1��6�   $��2��6�   $
��Left=�6�   $��	460,0,3,0q�6�   $��Center=�6�   �� 5B     -*   5        $��btnCall_Extend��5B  M   $��
Tính phí��6%   $y�Visible=�68   
���  ��$
��Bold"�6�   $	��120��6�   $
��Left=�6�   $��1��6�   $��2��6�   $��Center=�6�   $��	235,0,0,0q�6  5C     5D     �� 5F     $��1��6   $	��250��6,   $��5,10,0,0q�69   $*��$Thông tin thanh toán gia hạn HĐ��6L   .��5G     � .+�5H       -+   5        $��dgrFee_Extend��5H  '   $	��220��6<    .   .   5J  "     5L  &   $
 Bold"�69    . $ 60 6�   # [ 6�   # �  6�    6K   �� *Number_Payment+ 5M  *   �� 5N  .   $��Lần TT��64   $��Center=�6E   $��28��6`   $
��Bold"�6l   5P  '   
  5S  &   $	 120 6=    5T  *   �� 5U  .   $��Thời gian TT��64   $
��Bold"�6K    5W  *   �� 5X  .   .R�5Y  2   �� $��Center=�6<   $��Center=�6W   $��4q�6t   ��5Z  <   �� *Pay_Date_Expected+$ 
dd/MM/yyyy��5[  /    5]  *   �� 5^  .   .R�5_  2      6=   �� *Pay_Date_Expected+$ d��5`  /   5b  '     5d  &   $
 Bold"�69   $	 140 6�   # [ 5e  5    5d  K   �� *Fee_Expected+$ TwoWay=�$ #,##0�� 5f  *   �� 5g  .   $��Số tiền phải TT��64   $��Center=�6N   $��28��6i   $
��Bold"�6u   5i  '     5k  &   $
 Bold"�69   $	 140 6�   # [ 5l  5    5k  K   �� *Fee+$ TwoWay=�$ #,##0�� 5m  *   �� 5n  .   $��Số tiền đã TT��64   $��Center=�6L   $��28��6g   $
��Bold"�6s   5p  '     5r  &   $
 Bold"�69   $	 130 6�   # [ 5s  5    .  5r  K   �� *Debit_Amount+$ #,##0�� 5t  *   �� 5u  .   $��	Còn nợ��64   $��Center=�6E   $��28��6`   $
��Bold"�6l   5w  '     5y  &   $	 125 6i   $ StatusId��6u   $ 
StatusName��5z  ,    5y  =   �� *
Pay_Status+ 5z  K   �� #  [  5{  *   �� 5|  .   $��Trạng thái TT��64   $
��Bold"�6L   5~  '   5�     5�     5�     5�     5�     5�     � 5�  
   -,   5        $��	grdButton��5�  L   $��1��6    
 
BottomGrid#��� 
 6   $��0q�6A   .+�5�     � $��Center=�6   $��Center=�60   .+�5�     �� --   5        $��btnChapNhan��5�  n   $��Chấp nhận��6   $��90��6-   $
��Left=�68   $��Center=�6S   $��0,0,0,0q�6�   6�   �� 5�     -.   5        $��btnHuy��5�  b   $��Thoát��6   $��90��6)   $
��Left=�64   $��	100,0,0,0q�6O   $��Center=�6p   6�   5�     5�     5�     5�     