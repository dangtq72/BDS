   M S B A M L   `   `   `  ����  StartsInternational%    Starts_Monitor.User.User_Rights   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$&   Phân quyền cho người dùng��5   	   $	��544��6+   $
��1000��68    � WindowStartupLocation$ CenterScreen=�5   	      WindowFormStyle#���   6.    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value  	Use_Right d� 	IsChecked��%�  '        &	 �     �� 5   
   "  6   .�5      ��  � ��$ Center=�6;   �� 5	       � ��$ Center=�69   �� 5
       � ��$
 Bold"�6+   �� 5       � ��$ 30��6'   5      �� 5   
   .R�5      � .+�5      �� $��us_right��6   -   5        $��Center=�5   +   $��Center=�6H   y�6c   �� *Show+ 5      �� *
authcode+��6T   �� *Br_N+5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   � $��0��6   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��	gr_Rights��5         CanUserAddRows .  	   AutoGenerateColumns	 .  $��3q�5      $��Stretch=�6"   $��Stretch=�6@   
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *name+   Header 5!      �� 5"      $��Tên chức năng��6$   $��Center=�6<   $��Center=�6Y   $
��Bold"�6t   5$      4  .System.Windows.Controls.DataGridTemplateColumn  5&         CellTemplate# [ 6-    . $ 80 6i    5'      �� 5(      $��Right��6$   $��Center=�64   $��Center=�6Q   $
��Bold"�6l      	CellStyle 5*      �� 5+      *  $System.Windows.Controls.DataGridCell"  6$   .�5,   "   -   5        5-      5/      ��53      �� 54      )	  #System.Windows.Controls.DataGridRow" 	 6    �� Triggers 55      �� 56       �� Binding 6*   ��  �� Path$
 prid� �� Value 06H   .a�57   "   ��  � ��$
 Bold"�6?   58      5:      5<      5=      � 5?   
   -   5        $��	grdButton��5?   L   $��2��6     
BottomGrid#���  6   $��0q�6A   .+�5@      � $��Center=�6   $��Center=�60   .+�5A      �� -   5        $��btnChapNhan��5A   n   $��Chấp nhận��6   $��90��6-   $
��Left=�68   $��Center=�6S   $��0,0,0,0q�6�   6�   �� 5B      -   5        $��btnHuy��5B   b   $��Thoát��6   $��90��6)   $
��Left=�64   $��	100,0,0,0q�6O   $��Center=�6p   6�   5C      5D      5E      5F      