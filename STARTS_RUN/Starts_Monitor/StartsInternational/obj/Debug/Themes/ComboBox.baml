   M S B A M L   `   `   `  ����a  ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ComboBoxToggleButton  �� 
TargetType �Name ��Name ��Name F�Name � UseLayoutRounding �� Stretch �� Triggers P� 
SourceName	 P� Property
 P� Value �� 
TargetName �� Property �� Value  ComboBoxTextBox �� 
TargetType � 	Resources  Key g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value �� 	ClickMode d� 	IsChecked �� Path �� Mode �� RelativeSource d�Name ��Name �� SelectionBoxItem �� SelectionBoxItemTemplate J� IsHitTestVisible ��Name  �� 
IsReadOnly! �� 
IsReadOnly" J� Opacity# �Name$ �� IsDropDownOpen% � AllowsTransparency& �� MaxDropDownHeight' � ActualWidth( J� SnapsToDevicePixels) �� CornerRadius* K� IsItemsHost-   'System.Windows.Input.KeyboardNavigation+    DirectionalNavigation, N� ExitActions  
FocusedOff- N� EnterActions  	FocusedOn. ]� 
Conditions/ �� Property0 �� Value1 g� Duration	2 W� To3 ��Name  HighlightOff  HighlightOn�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      UThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero  5      %c  &	        &	 6    '�� �    7  7  '��     7  7  �� 5      "  d�63   .R�5   
   � $
 grid��6   .+�5      �� $ 
Background��6   ���#FFFFFF���#B9B9B96;   �� 5	      $ border��6   $��0q�6%   
������ $��20��6R   $��Right=�6]   $��0,0,0,0q�6y   ._�5
      F� $ BtnArrow��6   $��7��6)   ���#333333$��Center=�6B   "����        ���j     ��g5  �D 	 . $ Uniform=�5   M   5      5       5   
   P� 5      $ border��6:   	 �@J�IsMouseOver
 . . �5      �� $ border��6    � �� �#B9B9B96C   5      P� 5      $ 
Background��6-   	 �@J�IsMouseOver
 . . �5      �� $ 
Background��6    � �� �#F0F0F06A   5      P� 5      $ 
Background��6+   	 � {�
 .  . �5      �� $ 
Background��6    � �� �#F0F0F06A   5      5      �� 5      "  ��6.   .R�5   
   �� $ PART_ContentHost��6   |�.  
������ 6=   5      �� 5!      " ��6   .�5"   
   ��  � �� �#373A3D6'   �� 5#   
    � ��$ 	400-Arial)�6'   �� 5$   
    � ��$
 11.5(�6%   �� 5%   
    � ��
 ���� 6'   �� 5&   
    �@J�SnapsToDevicePixels . 60   �� 5'   
    � ��$ Stretch=�67   �� 5(   
    � ��$ Center=�65   �� 5)   
    � ��$ 21��6#   �� 5+   
    �@�UseLayoutRounding . 6.   �� 5,   
    � �� 5-      �� 5.      "  ��6"    5/      ���� 50      	FocusedOn .��51      U� $ 00:00:00X�6<   $ FocusVisualElement��6Q   $ (UIElement.Opacity)�6|   .\�52   "   �� $ 	00:00:0.3��67   $ 1Q�6K   53      54      �� 56      
FocusedOff .��57      U� $ 00:00:00X�6<   $ FocusVisualElement��6Q   $ (UIElement.Opacity)�6|   .\�58   "   �� $ 	00:00:0.3��67   $ 0Q�6K   59      5:      5;      .R�5=      � .+�5>      d� |�.  $ Press=�5?   '    5>   9   �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+��5?   9   Z� d� 5@      $ ToggleButton��6Y   #���   6'   |�.  $ Press=�5A   �    6'   �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+6�   �� 5B      $ ContentSite��6X   $
��Left=�6+   $��5,0,23,0q�6F   $��Center=�6m    . #��z 5C   +   #��z 6X   #��z��5D   +    .  6l   �� 5E      $ PART_EditableTextBox��5F   4   $y�Hidden=�5E   "   #���  66   $
��Left=�6c   $��3,0,23,0q�5F   "   $��Center=�6c   |�. 
������ #! z  5G   L   $��Center=�5H   "   
������ ��5F   R   Z� 5H   D   �� 5I      $ FocusVisualElement��6$   ���#F78A09$��1��6Q    .  $" 0Q�6~   � 5J      $# Popup��6]   #��z$ 6    $��Bottom=�6J   |�.  % . $��Slide=�5K   :   $��0,1,0,0q�6Q   .��5L      � $ DropDown��6|   #��z& 6#   #��z' 6S   ( . .+�5M   "   �� $ DropDownBorder��6)   $��0,-1,0,0q�6A   ���#f78a09$��1q�6i   $) 0,0,0,0��6}   ���#FFFFFF._�5N   &   �� $��1,1,1,1q�63   ( . $
��Auto=�6_   $
��Auto=�6�   ��. .��5O   *   �� * . $+ 	Contained=�6H   5P   '   5Q   #   5R      5S      5U       5V      P� 5W      	 �@J�	IsFocused
 . , 5X      �� 5Y   "   8��  62   - 5[      �� 5\   "   8�� 62   5^      ]� 5`      . 5a      �� 5b   "   / �@J�	IsFocused0 .  6A   �� 5c   "   / �@��
IsEditable0 . 6B   ./�5e      �� $ FocusVisualElement��6%    � �� �#b9b9b96W   �� 5f       � �� .  6:   �� 5g      $ PART_EditableTextBox��6K    � y�$ Visible=�6;   6K   5h      P� 5o      	 � {�
 .  . �5p      ��  � �� �#8886;   �� 5q      $ ToggleButton��6%    � y�$ 	Collapsed=�6U   5r      P� 5t      	 �@��
IsGrouping
 . . �5u      ��  � �� .  6N   5v      P� 5x      $ Popup��6@   	 �@�AllowsTransparency
 . . �5y      �� $ DropDownBorder��6G    �@��CornerRadius$ 0��6=   6G   �� 5z      $ DropDownBorder��6G    � ��$ 0,2,0,0q�67   6G   5{      ]� 5}      . 5~      �� 5   "   / �@��IsDropDownOpen0 . 6F   5�      5�      5�      5�      �� 5�      " ��6   .�5�   
   ��  � �� �#373A3D6'   �� 5�   
    �@J�SnapsToDevicePixels . 60   �� 5�   
    � ��$ Stretch=�67   �� 5�   
    � ��$ Center=�65   �� 5�   
    � ��$ 3,1,3,1q�6$   �� 5�   
    � ��$ 20��6#   �� 5�   
    �@�UseLayoutRounding . 6.   �� 5�   
    � �� 5�      �� 5�      "  ��6"    5�      ���� 5�      HighlightOn .��5�      W� $1 00:00:00.1000000D�6.   $ BackgroundGradientOver��6J   $ Opacity�6y   $
2 0.73X�6�   5�      �� 5�      HighlightOff .��5�      W� $1 00:00:00.1000000D�6.   $ BackgroundGradientOver��6J   $ Opacity�6y   $2 0X�6�   5�      �� 5�      	FocusedOn .��5�      W� $1 00:00:00.1000000D�6.   $ recFocus��6J   $ Opacity�6k   $
2 0.73X�6�   5�      �� 5�      
FocusedOff .��5�      W� $1 00:00:00.1000000D�6.   $ recFocus��6J   $ Opacity�6k   $2 0X�6�   5�      5�      .R�5�      � ( . .+�5�      �� $ BackgroundGradientOver��6$   ���#B9B9B9���#B9B9B9$" 0Q�6d   �� 5�      $ recFocus��6$   ���#f78a09���#f78a09$" 0Q�6V   �� 5�      $ contentPresenter��6+   #��z��6E   #��z��5�   +    . 6N   5�       5�      P� 5�      	 �@J�IsMouseOver
 . , 5�      �� 5�   "   $#3 HighlightOff_BeginStoryboard1��6]   8��  - 5�      �� 5�   "   8�� 62   5�      P� 5�      	 � {�
 .  . �5�      ��  � �� �#8886;   5�      5�      5�      5�      5�      