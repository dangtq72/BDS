   M S B A M L   `   `   `  ����N  JStartsInternational, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:StartsInternational.CustomUserControl%StartsInternational.CustomUserControl  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   
ListBorder  �� Color  FocusBackground �� EndPoint �� 
StartPoint � Color � Offset  FilterTextBoxStyle �� 
TargetType �� Property �� Value �� 
TargetType	 ��Name
 J� SnapsToDevicePixels ��Name9    3StartsInternational.CustomUserControl.FilterControl � ColumnDefinitions ��Name �� AutoWordSelection �� RelativeSource �� AncestorType �� Path �� Mode �� UpdateSourceTrigger ��Name    Header J� IsHitTestVisible �� Triggers P� 
SourceName P� Property P� Value �� 
TargetName�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      >filter3clr-namespace:StartsInternational.CustomUserControl  5      8d2http://schemas.microsoft.com/expression/blend/2008  5      Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      %y  &	        &	 #     &	 �     '   �    7  �� 53      $  	#FF7F9DB9��6)   �� 55      $ 0.5,0&�62   $ 	0.5,1.667&�6C   .��56   
   � $ 	#FF073553��6   $ 0Q�6)   � 57   
   $ 	#FFA7D5F4��6   $ 0.796Q�6)   � 58   
   $ 	#FF5A88A8��6   $ 1Q�6)   59      �� 5;      " ��6'   .�5<   
   ��  � ��$ 2,0,0,0q�6$   �� 5=   
    �@�FocusVisualStyle 6-   Z� �� 5>   
    �@J�	AllowDrop . 6&   �� 5?   
    � �� 5@      �� 5A      " ��6"   .R�5B      �� $	 Bd��6   
 . #��z��6D   #��z��5C      #��z��6I   ._�5D      �� $ PART_ContentHost��6'   #
 z
 6A   5E      5F      5H      �� 5I   
    � ��$ 0,0,0,0q�6,   5J      �� 5L      "   6   .�5N   
   ��  � �� �#B9B9B96(   �� 5O   
    � ��$ 1q�6,   �� 5P   
    � ��$ 21��6#   �� 5Q   
    �@  FilterOnEnter .  6*   �� 5R   
    �@J�SnapsToDevicePixels . 60   �� 5S   
    � �� 5T      �� 5U      "   6"   .R�5V      �� $	 border��6   ���#FFF#��z��6?   #��z��5W      #��z��6Q   ._�5X      � $��1q�6    5Y      �� 5Z   "   $
��Auto �63   �� 5[   "   $��* �63   �� 5\   "   $
��Auto �63   .+�5`      �� $ PART_FilterBox��5a   &   8��   . $��1��5b   &   $��0,1,0,1q�66   $��Center=�6G   ��5c   &   ��  �� "   $ 
FilterText�$ TwoWay=�$ PropertyChanged=��� 5d      $ PART_Header��6(   #��z 6=   $��Center=�6^   $
��Left=�6y   $��2,0,0,0q�6�   $��1��5e   (   $��Italic$�68    .  ���#ADADAD5f   A   5j      5k       5l      P� 5m      $ PART_FilterBox��6D    �@J�	IsFocused . . �5n      �� $ border��6L    � �� �#f78a095o      P� 5p       �@J�IsMouseOver . . �5q      �� $ border��6;    � �� �#f0f0f06O   5r      5z      5|      5}      5~      