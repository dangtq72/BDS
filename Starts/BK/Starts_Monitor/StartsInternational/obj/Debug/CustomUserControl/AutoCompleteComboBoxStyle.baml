   M S B A M L   `   `   `  ����N  JStartsInternational, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:StartsInternational.CustomUserControl%StartsInternational.CustomUserControl  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   NormalBrush  �� Color  HorizontalNormalBrush �� 
StartPoint �� EndPoint � Color � Offset  
LightBrush  HorizontalLightBrush  PressedBrush  	DarkBrush  DisabledForegroundBrush  DisabledBackgroundBrush  WindowBackgroundBrush 	 SelectedBackgroundBrush 
 NormalBorderBrush  HorizontalNormalBorderBrush  DefaultedBorderBrush  PressedBorderBrush  DisabledBorderBrush  SolidBorderBrush  LightBorderBrush  
GlyphBrush  LightColorBrush  ComboBoxToggleButton �� 
TargetType � ColumnDefinitions ��Name �� CornerRadius	 �� Triggers
 P� Property P� Value �� 
TargetName �� Value �� Property  ComboBoxTextBox?    9StartsInternational.CustomUserControl.AutoCompleteTextBox �� 
TargetType �� 	ClickMode J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate ��Name �� 
IsReadOnly �� 
IsReadOnly �� CharacterCasing �� 	MaxLength �� IsDropDownOpen � AllowsTransparency J� SnapsToDevicePixels � ActualWidth �� MaxDropDownHeight K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation  P� 
SourceName! �� Triggers�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      =local3clr-namespace:StartsInternational.CustomUserControl  5      %�  &	        &	 !     &	 �     &	 u    &	     &	 #    &	 D    &	 b    &	 �    &		 �    &	
 �    &	 �    &	 �    &	 1    &	 �    &	 �    &	     &	 5    &	 S    &	 q    7 
 7  7  7  7  &	 c    '   �    7  7  7  7  7  �� 5      $  #fff94c��6*   �� 5      $	 0,0&�68   $	 1,0&�6I   ��5      � � 5      $
 #FFF��6   $	 0.0Q�6,   � 5      $
 #CCC��6   $	 1.0Q�6,   5      5      �� 5      $	 0,0&�6-   $	 0,1&�6>   ��5      � � 5      $
 #FFF��6   $	 0.0Q�6,   � 5      $
 #EEE��6   $	 1.0Q�6,   5      5      �� 5      $	 0,0&�67   $	 1,0&�6H   ��5       � � 5!      $
 #FFF��6   $	 0.0Q�6,   � 5"      $
 #EEE��6   $	 1.0Q�6,   5#      5%      �� 5.      $	 0,0&�6/   $	 0,1&�6@   ��50      � � 51      $
 #BBB��6   $	 0.0Q�6,   � 52      $
 #EEE��6   $	 0.1Q�6,   � 53      $
 #EEE��6   $	 0.9Q�6,   � 54      $
 #FFF��6   $	 1.0Q�6,   55      57      �� 58      $  #F0F0F0��6(   �� 59      $
  #888��66   �� 5:      $
  #EEE��66   �� 5;      $
  #FFF��64   �� 5<      $
  #DDD��66   �� 5F      $  #A8A8A8��60   �� 5G      $	 0,0&�6>   $	 1,0&�6O   ��5I      � � 5J      $
 #CCC��6   $	 0.0Q�6,   � 5K      $
 #444��6   $	 1.0Q�6,   5L      5N      �� 5O      $	 0,0&�67   $	 0,1&�6H   ��5Q      � � 5R      $
 #777��6   $	 0.0Q�6,   � 5S      $
 #000��6   $	 1.0Q�6,   5T      5V      �� 5W      $	 0,0&�65   $	 0,1&�6F   ��5Y      � � 5Z      $
 #444��6   $	 0.0Q�6,   � 5[      $
 #888��6   $	 1.0Q�6,   5\      5^      �� 5_      $
  #AAA��62   �� 5`      $
  #888��6/   �� 5a      $
  #AAA��6/   �� 5c      $
  #444��6)   �� 5d      $
  #DDD��6.   �� 5g      " d�63   .R�5h   
   �  5i      �� 5j      �� 5k      $��20 �6#   .+�5m      �� $ Border��6   $��2��6%   $ 1��69   #���   6J   8��  $��1q�5n   F   5t      	 5u   
   P� 5v      
 �@J�IsMouseOver . . �5w      �� $ Border��6   8   � ��6C   5x      P� 5~      
 � {� .  . �5      �� $ Border��6   8   � ��6C   �� 5�      $ Border��6   8   � ��6D   �� 5�      8   � ��6/   5�      5�      �� 5�      " ��6.   .R�5�   
   �� $ PART_ContentHost��6   |�.  #��z��6>   5�      �� 5�      "   6   .�5�   
   ��  �@J�SnapsToDevicePixels . 60   �� 5�   
    �@�OverridesDefaultStyle . 62   �� 5�   
    � ��$
 Auto=�6G   �� 5�   
    � ��$
 Auto=�6E   �� 5�   
    � �� . 6:   �� 5�   
    � ��$ 20��6&   �� 5�   
    � �� �#373A3D6'   �� 5�   
    �@��
IsEditable . 6'   �� 5�   
    � �� 5�      �� 5�      "   6"   .R�5�      � .+�5�      d� $��ToggleButton��6'   8��  $��2��5�   '   |�.  $ Press=�6I   5�      �� 5�      $��ContentSite��6+    .  #��z 6X   #��z 5�   +   #��z��5�   +   $��3,3,23,3q�5�   +   $��Center=�6=   $
��Left=�6X   �� 5�      $ PART_EditableTextBox��6"   8�� $
��Left=�5�   "   $��Center=�6=   $��3,3,23,3q�6Y   |�. 
������ $y�Hidden=�5�   ;   # z 6O   $ Upper=�5�   "   $ 12��6:   ��5�   @   Z� 5�   :   � 5�      $��Popup��6    $��Bottom=�6-   #��z 6@    . |�.  $��Slide=�5�   L   .��5�      � $��DropDown��6#    . #��z 6N   #��z 5�   #   .+�5�   "   �� $ DropDownBorder��6)   8�� $��1q�5�   )   8�� 6=   �� 5�   "   $��4,6,4,6q�6/    . .��5�   &   ��  . $ 	Contained=�6D   5�   #   5�      5�      5�      	 5�      P� 5�      
 �@��HasItems .  . �5�      �� $ DropDownBorder��6%    � ��$ 95��6V   5�      P� 5�      
 � {� .  . �5�      �� 8   � ��6;   5�      P� 5�      
 �@��
IsGrouping . . �5�      ��  � �� .  6N   5�      P� 5�      $  Popup��6"   
 �@�AllowsTransparency . . �5�      �� $ DropDownBorder��6%    �@��CornerRadius$ 4��6Y   �� 5�      $ DropDownBorder��6%    � ��$ 0,2,0,0q�6S   5�      P� 5�      
 �@��
IsEditable . . �5�      ��  � �� .  6:   �� 5�      $ PART_EditableTextBox��6%    � y�$ Visible=�6`   �� 5�      $ ContentSite��6%    � y�$ Hidden=�6T   5�      5�      5�      ! 5�   
   5�      5�      