   M S B A M L   `   `   `  ����H  DAvalonDock, Version=1.3.3585.0, Culture=neutral, PublicKeyToken=null'clr-namespace:AvalonDock
AvalonDock  5      Q7clr-namespace:AvalonDock.Properties;assembly=AvalonDockAvalonDock.Properties  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source   NavigatorWindowBackground �� Color  NavigatorWindowBorderBrush % !NavigatorWindowContentsBackground �� EndPoint �� 
StartPoint � Color � Offset , (NavigatorWindowSelectedContentBackground - )NavigatorWindowSelectedContentBorderBrush 5 1NavigatorWindowSelectedContentInternalBorderBrush + 'NavigatorWindowContentsListItemTemplate �� DataType$    AvalonDock.NavigatorWindowItem � Cursor	 �� Padding
 � ColumnDefinitions   AvalonDock.ImageEx , (NavigatorWindowDocumentsListItemTemplate,   &AvalonDock.NavigatorWindowDocumentItem 1 -NavigatorWindowContentsListItemContainerStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius J� Opacity �� Triggers P� Property P� Value �� 
TargetName $	  NavigatorWindowContentsListStyle %
 !NavigatorWindowDocumentsListStyle K� IsItemsHost � 	ItemWidth � Orientation    AvalonDock.NavigatorWindow J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius � RowDefinitions �� Path �� RelativeSource ��Name �� FallbackValue%   AvalonDock.Properties.Resources(    !NavigatorWindow_ActiveToolWindows!   DockableContents""   NavigatorWindow_ActiveFiles# ��Name$   	Documents�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      adclr-namespace:AvalonDock  5      AadRes7clr-namespace:AvalonDock.Properties;assembly=AvalonDock  5        5      �� 5	   
   $2 ,/AvalonDock;component/Resources/Brushes.xaml?�6   �� 5
   
   $1 +/AvalonDock;component/Resources/Common.xaml?�6   %�  &	        &	      &	 @     &	 
    &	 �    &	 �    &	     &	 �    &	     7  7  7  &		     7  7  &	
 �    7  7  '  =
    7   7  7  7 	 7 
 �� 5      $ White��68   �� 5      $ #8591A2��69   �� 5      $ 0.5,1&�6D   $ 0.5,0&�6U   .��5   
   � $ #CED4DB��6   $ 0Q�6'   � 5   
   $ #D7DEE6��6   $ 0.044Q�6'   � 5   
   $ #C8D5E8��6   $ 1Q�6'   5      �� 5      $ 0.5,1&�6K   $ 0.5,0&�6\   .��5   
   � $ #E2EDFA��6   $ 0Q�6'   � 5   
   $ #D5E6F9��6   $	 0.5Q�6'   � 5   
   $ #C5DDFA��6   $ 1Q�6'   5      �� 5      $ #80A9DB��6H   �� 5      $ #EBF3FB��6P   �� 5      "   6C   .R�5   
   �� 
������ $
 Hand��6*   $	 0,2,0,2q�68   ._�5      � 
 5       �� 5!      $
��Auto �6'   �� 5"      $��* �6'   .+�5$        $��16��65   ��6   �� *Icon+65   �� 5%      $��CharacterEllipsis=�63   $��4,0,0,0q�6T   $��NoWrap=�6e   $��1��6{   ��6   �� *Title+6{   5&      5'      5(      �� 5*      "  6D   .R�5+   
   �� 
������ $
 Hand��6*   $	 0,2,0,2q�68   ._�5,      � 
 5-      �� 5.      $
��Auto �6'   �� 5/      $��* �6'   .+�51        $��16��66   ��6   �� *Icon+66   �� 52      $��CharacterEllipsis=�63   $��4,0,0,0q�6T   $��NoWrap=�6e   $��1��6{   ��6   �� *Title+6{   53      54      55      �� 58      " ��6B   .�59   
   ��  � �� 5:      �� 5;      " ��6"   .R�5<      � .+�5=      �� $ intMouseOverBorder��5>      $��2��5?      $ 2��5@      $��1q�5A      8��  $y�	Collapsed=�5C      ._�5D      �� $ intSelectedItemBorder��5E   !   $	 0.5Q�5F   !   $��1q�5G   !   8�� $ 1��5I      8�� 5J      5L      �� 5M      5N       5O      P� 5P       �@J�IsMouseOver . . �5Q      �� $ intMouseOverBorder��6K    � y�$ Visible=�6;   6K   5R      P� 5S       �@��
IsSelected . . �5T      �� $ intMouseOverBorder��6K    � y�$ Visible=�6;   6K   �� 5U      $ intSelectedItemBorder��6D    �@J�Opacity$	 1.0Q�68   6D   5V      5X      5Z      5[      �� 5�      " ��66   .�5�   
   ��  � ��8   6)   �� 5�   
    � ��8  6/   �� 5�   
    � �� 6'   Z� �� 5�   
    � ��$ 0q�6,   �� 5�   
    � ��$ Disabled=�6G   5�      �� 5�      " ��66   .�5�   
   ��  � ��8   6)   �� 5�   
    � ��8  6/   �� 5�   
    � �� 6'   Z� �� 5�   
    � ��$ 0q�6,   �� 5�   
    � ��$ Disabled=�6E   �� 5�   
    � �� 5�      �� 5�      .R�5�      �  . $	 180��63   $ Vertical=�6C   5�      5�      5�      �� 5�      "  61   .�5�   
   ��  � �� 5�      �� 5�      "  6"   .R�5�      �� $	��574��6   $	��437��6)   8��  8�� $��1q�6�   $ 3��6�    5�        5�      $ 15Q�6/   ._�5�      �  5�   "   �� 5�   &   $��54 �64   �� 5�   &   $��* �64   �� 5�   &   $��42 �64   .+�5�   "   �� ._�5�   &   � $��5q�6+    5�   *   �� 5�   .   $��* �6<   �� 5�   .   $��* �6<   .+�5�   *   � 
 5�   .   �� 5�   2   $
��Auto �6C   �� 5�   2   $��* �6C   .+�5�   *     $��16��6�   ��65   �� $ SelectedContent.Icon� �� *TemplatedParent+6�   �� 5�   *   $ titleSelectedDocument��64   $��1��6S   $��14(�6�   $
��Bold"�6�   $��Center=�6�   $��4,0,0,0q�6�   $��CharacterEllipsis=�6  ��6c   �� $ SelectedContent.Title� �� *TemplatedParent+6  5�   +   �� 5�   &   $��1��60   $��Center=�6�   $��CharacterEllipsis=�6�   ��6=   �� $, &SelectedContent.ContentTypeDescription� �� *TemplatedParent+$  ��6�   5�   '   5�   #   �� 5�   "   $��1��6)   8�� ._�5�   &   � $��5q�6+   
 5�   *   �� 5�   .   $��* �6?   �� 5�   .   $��2* �6?   .+�5�   *   �  5�   .   �� 5�   2   $��20 �6@   �� 5�   2   $��* �6@   .+�5�   *   �� #��Z  64   $
��Bold"�6x   �� 5�   .   $��1��5�      $��0,0,10,0q�5�      #��z! 5�      8�� 5�   /   5�   +   � 5�   *   $��1��6/    5�   .   �� 5�   2   $��20 �6@   �� 5�   2   $��* �6@   .+�5�   *   �� #��Z" 64   $
��Bold"�6r   �� 5�   .   $# activeFileList��5�   1   $��1��5�      $��0,0,10,0q�5�      #��z$ 5�      8�� 5�   /   5�   +   5�   '   5�   #   �� 5�   "   $��2��6)   $��5q�66   ._�5�   "   �� $��Center=�6�   $��CharacterEllipsis=�6�   ��6,   �� $) #SelectedContent.ItemContent.InfoTip� �� *TemplatedParent+$  ��6�   5�   #   5�      5�      5�      5�      5�      5�      