   M S B A M L   `   `   `  ����  StartsInternational.    (StartsInternational.User.GroupUser_Right   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5        $��frmGroupUser_Right��5   	     � Title$  Phân quyền cho nhóm��5   	   $	��544��6%   $	��800��62    � WindowStartupLocation$ CenterScreen=�5   	      WindowFormStyle#���   6.    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value  CheckBoxParentID  DataGridColumnButton d� 	IsChecked��%�  '        &	 �     &	 �     �� 5   
   "  6   .�5	      ��  � ��$ Center=�6;   �� 5
       � ��$ Center=�69   �� 5       � ��$ 30��6'   5      �� 5   
   " ��6)   .�5      ��  � ��
 �  ��6,   5      �� 5   
   .R�5      � .+�5      �� -   5        $��Center=�5      $��Center=�68   y�6S   �� *Show+ 5      �� *	ofgroup+��6P   �� *Br_N+5      5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   � $��0��6   .+�5       &   System.Windows.Controls.DataGrid  -   5        $��dgFunctions��5    ?   $��Stretch=�6   $��6q�63      CanUserAddRows .  	   AutoGenerateColumns	 .  
   CanUserSortColumns
 .     Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 350 6B      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *name+   Header 5$      �� 5%      $��Tên chức năng��6$   $��Center=�6<   $��28��6W   $
��Bold"�6c   5'      4  .System.Windows.Controls.DataGridTemplateColumn  5)         CellTemplate# [ 6-    . $	 160 6t    5*      �� 5+      -   5        $��ckAll��5+   a   $��Chức năng của nhóm��6'   $��Center=�6D   $��Center=�6n   $
��Bold"�6�   6�      	CellStyle 5-      �� 5.      *  $System.Windows.Controls.DataGridCell"  6$   .�5/   "   -   5        50      52      ��5<      �� 5=      )	  #System.Windows.Controls.DataGridRow" 	 6    �� Triggers 5>      �� 5?       �� Binding 6*   ��  �� Path$
 prid� �� Value 06H   .a�5@   "   ��  � ��$
 Bold"�6?   5A      5C      5E      5F      � 5H   
   $��1��6     
BottomGrid#���  6   $��0q�6A   .+�5I      � $��Center=�6   $��Center=�60   .+�5J      �� -   5        $��	btnUpdate��5J   a   $��Accept��6   $
��Left=�6*   $��0,0,0,0q�6E   $��80��6V   $��Center=�6r   6�   �� 5K      -   5        $��	btnCancel��5K   a   $
��Exit��6   $
��Left=�6)   $��85,0,0,0q�6D   $��80��6V   $��Center=�6r   6�   5L      5M      5N      5O      