   M S B A M L   `   `   `  ����N  JStartsInternational, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:StartsInternational.ContractStartsInternational.Contract  5   	   7    1StartsInternational.Contract.View_Contract_Tenant   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   <local*clr-namespace:StartsInternational.Contract     5   	   -   5        $��frmView_Contract_Tenant��5   	     � Title$S  MXEM CHI TIẾT HỢP ĐỒNG MÔI GIỚI BẤT ĐỘNG SẢN (cho thuê nhà)��5   	   $	��780��6L    � 
ResizeMode$ NoResize=�5   	    � SizeToContent$ Height=�6    � WindowStartupLocation$ CenterScreen=�66      WindowFormStyle#���   5	   	    � 	Resources 5
      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value:  4System.Windows.Controls.Primitives.DatePickerTextBox��%#  '        '  �     �� 5   
   "  6   .�5      ��  � ��$
 Bold"�6+   �� 5       � ��$ Center=�69   �� 5       � ��$ Center=�6;   �� 5       � ��$ 30��6'   5      �� 5   
   "  6   .�5      ��  �@��
IsReadOnly . 6+   5      5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��35 �6   .+�5   
   �� $��0��6   .@�5      �� -   5        $��tabContract��5   (   $��Hợp đồng��6   .��5      � $��0��6    5      �� 5      $	��135 �6(   �� 5      $	��165 �6(   �� 5       $	��190 �6(   .+�5#      �� $��0��6   $��5,0,0,0q�6,   $4��.Thông tin đối tượng bất động sản��6=   .��5$      � 	 � ColumnDefinitions	 5%      �� 5&   "   $	��130 �63   �� 5'   "   $��* �63    5)      �� 5*   "   $��25 �60   �� 5+   "   $��25 �60   �� 5,   "   $��25 �60   �� 5-   "   $��25 �60   .+�50      �� $��Tên căn hộ:��6$   $��0��6:   $��0��6J   $��Right=�6W   $��0,0,3,0q�6s   $��Center=�6�   �� 51      $��Mã căn hộ:��6$   $��0��69   $��1��6I   $��Right=�6V   $��0,0,3,0q�6r   $��Center=�6�   �� 52      $��Kiểu nhà:��6$   $��0��68   $��2��6H   $��Right=�6U   $��0,0,3,0q�6q   $��Center=�6�   �� 53      $��Diện tích:��6$   $��1��69   $��2��6I   $
��Left=�6V   $��	200,0,3,0q�6q   $��Center=�6�   �� 54      $��
Vị trí:��6$   $��0��66   $��3��6F   $��Right=�6S   $��0,0,3,0q�6o   $��Center=�6�   �� 56      -   5        $��lbl_Estate_Name��56   $   $�� ��6;   $��1��6F   $��0��6V   $
��Left=�6c   $��0,0,3,0q�6~   $��Center=�6�   �� 57      -   5        $��lbl_Estate_Code��57   $   $�� ��6;   $��1��6F   $��1��6V   $
��Left=�6c   $��0,0,3,0q�6~   $��Center=�6�   �� 58      -   5        $��lbl_Estate_Type_Name��58   $   $�� ��6@   $��1��6K   $��2��6[   $
��Left=�6h   $��0,0,3,0q�6�   $��Center=�6�   �� 59      -   5        $��lbl_Estate_Area��59   $   $�� ��6;   $��1��6F   $��2��6V   $
��Left=�6c   $��	250,0,3,0q�6~   $��Center=�6�   �� 5:      -   5        $��lbl_Address��5:   $   $��1��69   $��3��6I   $
��Left=�6V   $��0,0,3,0q�6q   $��Center=�6�   5;      5<      �� 5>      $��1��6   $	��155��6,   $��5,10,0,0q�69   $*��$Bên B - BÊN YÊU CẦU MÔI GIỚI��6K   .��5?      � 	 5@      �� 5A   "   $	��130 �63   �� 5B   "   $��* �63    5D      �� 5E   "   $��25 �60   �� 5F   "   $��25 �60   �� 5G   "   $��25 �60   �� 5H   "   $��25 �60   �� 5I   "   $��25 �60   .+�5L      �� $&�� Tên tổ chức / Cá nhân(*):��6$   $��0��6H   $��0��6X   $��Right=�6e   $��0,0,3,0q�6�   $��Center=�6�   �� 5M      -   5        $��txtRenter_Name��5M   Q   
 J� IsHitTestVisible
 .  |�.  $��1��6g   $��0��6w   $��Stretch=�6�   $��0,0,3,0q�6�   $��Center=�6�   �� 5O      $��Địa chỉ(*):��6$   $��0��6:   $��1��6J   $��Right=�6W   $��0,0,3,0q�6s   $��Center=�6�   �� 5P      -	   5        $��
txtAddress��5P   Q   
 .  |�.  $��1��6c   $��1��6s   $��Stretch=�6�   $��0,0,3,0q�6�   $��Center=�6�   �� 5R      $��Chức vụ:��6$   $��0��67   $��2��6G   $��Right=�6T   $��0,0,3,0q�6p   $��Center=�6�   �� 5S      -
   5        $��txtPosition��5S   Q   
 .  |�.  $��1��6d   $��2��6t   $
��Left=�6�   $	��220��6�   $��0,0,3,0q�6�   $��Center=�6�   �� 5U      $��Mã số thuế:��6$   $��1��6:   $��2��6J   $
��Left=�6W   $��	300,0,3,0q�6r   $��Center=�6�   �� 5V      -   5        $��
txtTaxCode��5V   Q   
 .  |�.  $��1��6c   $��2��6s   $
��Left=�6�   $	��227��6�   $��	370,0,3,0q�6�   $��Center=�6�   �� 5X      $��Điện thoại(*):��6$   $��0��6=   $��3��6M   $��Right=�6Z   $��0,0,3,0q�6v   $��Center=�6�   �� 5Y      -   5        $��txtPhone��5Y   Q   
 .  |�.  $��1��6a   $��3��6q   $
��Left=�6~   $	��220��6�   $��0,0,3,0q�6�   $��Center=�6�   �� 5[      $
��Fax:��6$   $��1��63   $��3��6C   $
��Left=�6P   $��	300,0,3,0q�6k   $��Center=�6~   �� 5\      -   5        $��txtFax��5\   Q   
 .  |�.  $��1��6_   $��3��6o   $
��Left=�6|   $	��227��6�   $��	370,0,3,0q�6�   $��Center=�6�   �� 5^      $��CMND/HC:��6$   
 .  |�.  $��0��6b   $��4��6r   $��Right=�6   $��0,0,3,0q�6�   $��Center=�6�   �� 5_      -   5        $��txtIdentity_Card��5_   &   $��1��6>   $��4��6N   $
��Left=�6[   $	��220��6v   $��0,0,3,0q�6�   $��Center=�6�   5`      5a      �� 5c      $��2��6   $	��180��6,   $��5,10,0,0q�69   $��Thông tin hợp đồng��6K   .��5d      � 	 5e      �� 5f   "   $	��130 �63   �� 5g   "   $��* �63    5i      �� 5j   "   $��25 �60   �� 5k   "   $��25 �60   �� 5l   "   $��25 �60   �� 5m   "   $��25 �60   �� 5n   "   $��25 �60   �� 5o   "   $��25 �60   .+�5q      �� $��Mã hợp đồng(*)��6$   $��0��6=   $��0��6M   $��Right=�6Z   $��0,0,3,0q�6v   $��Center=�6�   �� 5t      -   5        $��txtContract_Code��5t   &   
 .  |�.  $��1��6i   $��0��6y   $��Stretch=�6�   $��0,0,3,0q�6�   $��Center=�6�   �� 5w      $ ��Ngày ký hợp đồng(*)��6$   $��0��6B   $��1��6R   $��Right=�6_   $��0,0,3,0q�6{   $��Center=�6�   �� 5x      -   5        $��dpContractDate��5x   &   
 .  |�.  $��1��6g   $��1��6w   $
��Left=�6�   $��Center=�6�   $	��120��6�   $��0,0,3,0q�6�   �� 5z      $��Loại tiền��6$   $��1��68   $��1��6H   $
��Left=�6U   $��	150,0,0,0q�6p   $��Center=�6�   �� 5{      -   5        $��cboCurrency��5{   R   
 .  |�.  $	��120��6e   $��1��6q   $��1��6�   $
��Left=�6�   $��	250,0,3,0q�6�   $��Center=�6�   �� 5}      $��Thời gian thuê từ(*)��6$   $��0��6C   $��2��6S   $��Right=�6`   $��0,0,3,0q�6|   $��Center=�6�   �� 5~      -   5        $��
dpFromDate��5~   Q   
 .  |�.  $��1��6c   $��2��6s   $
��Left=�6�   $��Center=�6�   $	��120��6�   $��0,0,3,0q�6�   �� 5�      $��đến ngày(*)��6$   $��1��6:   $��2��6J   $
��Left=�6W   $��	150,0,3,0q�6r   $��Center=�6�   �� 5�      -   5        $��dpToDate��5�   Q   
 .  |�.  $��1��6a   $��2��6q   $
��Left=�6~   $��Center=�6�   $	��120��6�   $��	250,0,3,0q�6�   �� 5�      $��Trạng thái HĐ��6$   $��0��6<   $��3��6L   $��Right=�6Y   $��0,0,3,0q�6u   $��Center=�6�   �� 5�      -   5        $��	cboStatus��5�   R   
 .  |�.  $��1��6c   $��3��6s   $
��Left=�6�   $��Center=�6�   $	��120��6�   $��0,0,3,0q�6�   �� 5�      $��Người SD:��6$   $��0��68   $��4��6H   $��Right=�6U   $��0,0,3,0q�6q   $��Center=�6�   �� 5�      -   5        $��txtUsers��5�   &   
 .  |�.  $��1��6a   $��4��6q   $��Stretch=�6~   $��0,0,3,0q�6�   $��Center=�6�   �� 5�      $��Đại diện(*):��6$   $��0��6;   $��5��6K   $��Right=�6X   $��0,0,3,0q�6t   $��Center=�6�   �� 5�      -   5        $��txtRepresentive��5�   '   
 .  |�.  $��1��6i   $��5��6y   $��Stretch=�6�   $��0,0,3,0q�6�   $��Center=�6�   5�      5�      5�      5�      �� 5�      -   5        $��tabFee��5�   ,   $��Phí môi giới��6   .��5�      �  5�      �� 5�      �� 5�       5�        StatusDataProvider S� 
ObjectType0   *StartsInternational.Contract.StatusPayment S� 
MethodName  DateTemplate �� StringFormat  EditingDateTemplate(  "System.Windows.Controls.DatePicker   SelectedDate��%:  &	       &	 -     &	 �    S� 5�      "  6H   $ 	GetStatus��6r   �� 5�      .R�5�      �� $��20��6)   $��30��64   .+�5�   "   �� 
����ح�
���   �$��1q�6T   ._�5�   &   �� $��8(�6k   $��Center=�6x   ��60   �� *Pay_Date_Expected+$ {0:MMM}��6x   5�   #   �� 5�   "   
�������
���   �$��1q�6P   ._�5�   &   �� $��8(�6l   $
��Bold"�6y   $��Center=�6�   ��60   �� *Pay_Date_Expected+$ {0:yyyy}��6�   5�   #   5�      5�      �� 5�      .R�5�         6)   �� *Pay_Date_Expected+5�      5�      .+�5�      �� $��0��6   $��55��6,   $��5,10,0,0q�68   $!��Thông tin Phí môi giới��6J   .��5�      � 	 5�      �� 5�   "   $	��130 �63   �� 5�   "   $��* �63    5�      �� 5�   "   $��25 �60   .+�5�      �� $��Phí môi giới(*)��6$   $��0��6>   $��0��6N   $��Right=�6[   $��0,0,3,0q�6w   $��Center=�6�   �� 5�      -   5        $��txtFee��5�   Q   
 .  |�.  $��1��6_   $	��120��6o   $��0��6{   $
��Left=�6�   $��0,0,3,0q�6�   $��Center=�6�   �� 5�      $��Kỳ hạn thanh toán��6$   $��1��6@   $��0��6P   $
��Left=�6]   $��	135,0,0,0q�6x   $��Center=�6�   �� 5�      -   5        $��cboTerm��5�   R   
 .  |�.  $��1��6a   $��0��6q   $
��Left=�6~   $��Center=�6�   $	��120��6�   $��	235,0,3,0q�6�   5�      5�      �� 5�      $��1��6   $	��250��6,   $��5,10,0,0q�69   $��Thông tin thanh toán��6L   .��5�      &   System.Windows.Controls.DataGrid  -   5        $��dgrFee��5�   #   $	��220��6R      CanUserAddRows .     AutoGenerateColumns .     Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�   "   ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Lần TT��6j      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6z    " ElementStyle_VerticalAlignment1	  +System.Windows.Controls.DataGridBoundColumn 	  ElementStyle# �  6�    	  Binding 65   �� *Number_Payment+6�     5�   "    . $ Thời gian TT��6�   $	 110 6�     ElementStyle# �  6�    65   �� *Pay_Date_Expected+$ 
dd/MM/yyyy��6�     5�   "    . $ Số tiền phải TT��6|   $	 140 6�     ElementStyle_Number# �  6�    65   �� *Fee_Expected+$ #,##0��6�     5�   "    . $ Số tiền đã TT��6s   $	 140 6�   # �  6�    65   �� *Fee+$ #,##0��6�     5�   "    . $ 	Còn nợ��6|   $	 130 6�   # �  6�    65   �� *Debit_Amount+$ #,##0��6�     5�   "    . $ Trạng thái TT��6k   $ * 6�    65   �� *Pay_Status_Name+ 5�   &   �� 5�   *   " ��60   .�5�   .   ��  �@��TextAlignment$
 Left=�6N   �� 5�   .    � ��$ 5,0,0,0q�6G   �� 5�   .    � ��$ Center=�6R   �� 5�   .    � ��$
 Bold"�6K    �� Triggers 5�   .   �� 5�   2    �� Binding 6>   ��  �� Path$ 
Pay_Status� �� Value 16b   .a�5�   6   ��  � ��
 � � �6S   5�   3   �� 5�   2    6>   �� $ 
Pay_Status� 06b   .a�5�   6   ��  � ��
 �  ��6S   5�   3   5�   +   5�   #   5�      5�      5�      5�      �� 5�      -   5        $��	tabExtend��5�   0   $��Gia hạn hợp đồng��6   .��5�      �  5�      �� 5�      �� 5�      .+�5�      �� $��0��6   $	��105��6,   $��5,10,0,0q�69   $ ��Phí môi giới gia hạn��6K   .��5�      � 	 5�      �� 5�   "   $	��130 �63   �� 5�   "   $��* �63    5�      �� 5�   "   $��25 �60   �� 5�   "   $��25 �60   �� 5�   "   $��25 �60   .+�5�      �� $��Thời gian thuê từ(*)��6$   $��0��6C   $��0��6S   $��Right=�6`   $��0,0,3,0q�6|   $��Center=�6�   �� 5�      -   5        $��dpFromDate_Extend��5�   Q   
 .  |�.  $��1��6j   $��0��6z   $
��Left=�6�   $��Center=�6�   $	��120��6�   $��0,0,3,0q�6�   �� 5�      $��đến ngày(*)��6$   $��1��6:   $��0��6J   $
��Left=�6W   $��	150,0,3,0q�6r   $��Center=�6�   �� 5�      -   5        $��dpToDate_Extend��5�   Q   
 .  |�.  $��1��6h   $��0��6x   $
��Left=�6�   $��Center=�6�   $	��120��6�   $��	235,0,3,0q�6�   �� 5�      $��Phí môi giới(*)��6$   $��0��6>   $��1��6N   $��Right=�6[   $��0,0,3,0q�6w   $��Center=�6�   �� 5�      -   5        $��txtFee_Extend��5�   Q   
 .  |�.  $��1��6g   $	��120��6w   $��1��6�   $
��Left=�6�   $��0,0,3,0q�6�   $��Center=�6�   �� 5�      -   5        $��lblFeePay_Extend��5�   ?   $��Số tiền 1 lần TT��6$   $��1��6W   $��1��6g   $
��Left=�6t   $��	135,0,3,0q�6�   $��Center=�6�   �� 5�      -    5        $��txtFeeOnePay_Extend��5�   Q   
 .  |�.  {�.  $	��120��6~   $��1��6�   $��1��6�   $
��Left=�6�   $��	235,0,3,0q�6�   $��Center=�6�   �� 5�      $��Kỳ hạn thanh toán��6$   $��0��6@   $��2��6P   $��Right=�6]   $��0,0,0,0q�6y   $��Center=�6�   �� 5�      -!   5        $��cboTerm_Extend��5�   R   
 .  |�.  $��1��6h   $��2��6x   $
��Left=�6�   $��Center=�6�   $	��120��6�   $��0,0,0,0q�6�   5�      5      �� 5     $��1��6   $	��250��6,   $��5,10,0,0q�69   $*��$Thông tin thanh toán gia hạn HĐ��6L   .��5     � .+�5       -"   5        $��dgrFee_Extend��5  '   $	��220��6<    .   .   5  "     5  &    . $ Lần TT��6n   $ 50 6~   # �  6�    69   �� *Number_Payment+6�     5  &    . $ Thời gian TT��6�   $	 110 6�   # �  6�    69   �� *Pay_Date_Expected+$ 
dd/MM/yyyy��6�     5	  &    . $ Số tiền phải TT��6�   $	 140 6�   # �  6�    69   �� *Fee_Expected+$ #,##0��6�     5
  &    . $ Số tiền đã TT��6w   $	 140 6�   # �  6�    69   �� *Fee+$ #,##0��6�     5  &    . $ 	Còn nợ��6�   $	 130 6�   # �  6�    69   �� *Debit_Amount+$ #,##0��6�     5  &    . $ Trạng thái TT��6o   $ * 6�    69   �� *Pay_Status_Name+ 5  *   �� 5  .   " ��64   .�5  2   ��  �@��TextAlignment$
 Left=�6R   �� 5  2    � ��$ 5,0,0,0q�6K   �� 5  2    � ��$ Center=�6V   �� 5  2    � ��$
 Bold"�6O    5  2   �� 5  6    6B   �� $ 
Pay_Status� 16f   .a�5  :   ��  � ��
 � � �6W   5  7   �� 5  6    6B   �� $ 
Pay_Status� 06f   .a�5  :   ��  � ��
 �  ��6W   5  7   5  /   5  '   5     5      5!     5"     5#     �� 5%     -#   5        $��tabExtendInfo��5%  1   $��Thông tin gia hạn��6   .��5&     �  5'     �� 5(     .+�5+       -$   5        $��	dgrExtend��5+     $	��220��6R    .   .   5-       5.      . $ Lần gia hạn��6y   $	 100 6�   # �  6�    61   �� *Number_Extend+$ #,##0��6�     5/      . $ 
Từ ngày��6�      MinWidth$	 120Q�6�    61   �� *Contract_FromDate+$ 
dd/MM/yyyy��6�     50      . $ Đến ngày��6   $	 120Q�6�    61   �� *Contract_ToDate+$ 
dd/MM/yyyy��6�     51      . $ Phí môi giới��6o   $	 150 6�   # �  6�    61   �� *Fee+$ #,##0��6�   53     54     55     56     � 58  
   -%   5        $��	grdButton��58  L   $��1��6     
BottomGrid#���  6   $��0q�6A   .+�59     � $��Center=�6   $��Center=�60   .+�5:     �� -&   5        $��btnHuy��5:  `   $��Thoát��6   $��90��6)   $
��Left=�64   $��0,0,0,0q�6O   $��Center=�6n   6�   5;     5<     5=     5>     