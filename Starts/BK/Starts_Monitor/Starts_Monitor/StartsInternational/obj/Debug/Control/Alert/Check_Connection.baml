   M S B A M L   `   `   `  ����N  JStartsInternational, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:StartsInternational.CustomUserControl%StartsInternational.CustomUserControl  5   	   2    ,StartsInternational.Control.Check_Connection   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Fcustom3clr-namespace:StartsInternational.CustomUserControl     5   	   -   5          � Title$   ��5   	   $��351.316��6   $��697.368��6#    � 
ResizeMode$ NoResize=�63    � WindowStyle$
 None=�6I    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5        � 	Resources 5         HoverOnClose �� 
StartPoint �� EndPoint � Offset	 � Color  PressedOnClose  BtnClose
 �� 
TargetType �� Bullet 
� GradientOrigin 
� RadiusY 
� RadiusX �� RelativeTransform �� CenterY �� CenterX �� ScaleY �� ScaleX �� AngleY �� AngleX �� CenterY �� CenterX �� CenterY �� CenterX F�Name J� SnapsToDevicePixels �� Color �� Triggers P� Property P� Value  �� 
TargetName! �� Value" �� Property��%%  &	        &	 �     &	      7   7  �� 5	   
   $	 0,0&�63   $	 0,1&�6D   .��5
      � $ 0Q�6   $	 White��6&   � 5      $ 1Q�6   $		 Red��6&   5      �� 5   
   $	 0,0&�65   $	 0,1&�6F   .��5      � $ 0Q�6   $	 	#FFADADAD��6&   � 5      $ 1Q�6   $		 Red��6&   5      �� 5   
   "
 ��6+   .R�5      �� $��Center=�6   $��Center=�6;    5      � 5      .+�5      A� $��17��6"   $��17��6-   ��5      �� 5   "   $	 0,0&�66   $	 0,1&�6G   .��5   &   � $ 0Q�63   $	 Black��6>   � 5   &   $ 1Q�63   $
	 Gray��6>   5   #   5      A� 5      $��EllipseSmall��6"   $��14��66   $��14��6A   ��5      
� 5    "   $ 	0.5,-0.19&�66   $ 0.879Q�6Q   $ 2.166Q�6a    5!   &   V� 5"   *   .~�5#   .   �� $	 0.5Q�6=   $	 0.5Q�6K   $ 1Q�6Y   $ 1Q�6d   �� 5$   .   $ 0Q�6<   $ 0Q�6G   $	 0.5Q�6R   $	 0.5Q�6`   �� 5%   .   $	 0.5Q�6>   $	 0.5Q�6L   T� 5&   .   5'   +   .��5)   &   � $	 	#FFF5EFEF��63   $ 0.129Q�6E   � 5*   &   $	 	#FFEFE2E2��63   $ 0.734Q�6E   � 5+   &   $	 	#FFF92C2C��63   $ 0.332Q�6E   � 5,   &   $	 White��63   $ 0.906Q�6A   5-   #   5/      F� 50      $ xClose��51   +   $y�	Collapsed=�50      $��8��66   $��8��6@    .  $��2��53   +   +����        � z  z �     z � z     	��55      �� 56   "   $ 	#FF333333��62   58      59      5;       5=      P� 5>       �@J�IsMouseOver . . �5?      �� $  EllipseSmall��6   8!   " � ��6G   �� 5@      $  xClose��6   " � y�$! Visible=�6G   5A      P� 5C       � �� . . �5D      �� $  EllipseSmall��6   8!  " � ��6G   �� 5E      $  xClose��6   " � ��! �	#FF6464646C   5F      5I      5J      .��5K      �� ���	#FF373A3D$��1q�6%   ���#F3F3F3# �� Padding$# 1q�6N   ._�5L   
   � ��5M      �� 5N      $ �� ImageSource$;$ 5/StartsInternational;component/Images/image_login.jpg��6   .+�5Q      � -   5        $��gr_main��5Q      .+�5S      �� -   5        $��txtUsername��5S      $��Center=�6-   $��25��6J   $	��Top=�5T      $	��262��62   $��Center=�6>   $��95,226,89,0q�5U      =   7StartsInternational.CustomUserControl.CustomPasswordBox  5W      -   5        %  Name$% txtPassword��5W   `   =   7StartsInternational.CustomUserControl.CustomPasswordBox&   GotFocus$& passwordBox1_GotFocus��6�   '   	LostFocus$' passwordBox1_LostFocus��5X   ?   $��Center=�5W   +   $	��Top=�6H   $��25��6u   $	��262��5X      $��95,272,89,0q�6*   $��Center=�5Y      �� 5[      -   5        $��tblUser��5[   {   $��23��6   
���  ��$
��Bold"�69   $
��Left=�6K   $��218,206,0,0q�6f   $��Tên đăng nhập:��6�   $	��Top=�6�   �� 5\      -   5        $��tblError��5\   {   $��23��6   
���  ��$
��Bold"�69   $
��Left=�6K   $��307,166,0,0q�6f   $��Error��6�   $	��Top=�6�   �� 5]      -   5        $��tblPass��5]   {   $��23��6   
���  ��$
��Bold"�69   $
��Left=�6K   $��218,254,0,0q�6f   $��Mật khẩu:��6�   $	��Top=�6�   �� 5_      -   5        $��btnLogon��5_      $��Đăng nhập��6)   $
��Left=�6=   $��218,309,0,0q�5`      $	��Top=�6.   $��76��6F   6Q   �� 5a      -	   5        ( ��Name$( btnExit��5a      $
��Left=�6*     btnClose#���  6E   $��456,306,0,0q�5b      $	��Top=�6.   $��24��6F   $��24��6Q   ) J� RenderTransformOrigin$) 4,1.083&�6s   5d      �� 5e      -
   5        $��
stkLoading��5e   V   $��Center=�6   $	��120��66   $��	0,100,0,0q�6C   $y�	Collapsed=�6h   .+�5g      �� -   5        $��lblMes��5g      $��Center=�6*   $��Center=�6G   * �� TextAlignment$* Center=�6b   $
��Wrap=�5h      ���	#FF00496E$��SemiBold"�6C   $��aaaaaaaaaaaaaaaaaaa��6Y   $��20(�6t   7   1StartsInternational.CustomUserControl.LoadControl  5j      -   5        +  Name$+ controlLoad1��5j   U   $��Center=�6%   $��	37,30,0,0q�6B   $	��Top=�6k   5l      5n      5r      5s      