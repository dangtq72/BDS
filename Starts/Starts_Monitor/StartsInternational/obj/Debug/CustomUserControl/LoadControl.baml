   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5       StartsInternational7   1StartsInternational.CustomUserControl.LoadControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9system&clr-namespace:System;assembly=mscorlib     5        � 	Resources  5	         ParticleColor �� Color  ParticleBackgroundColor  ParticleOpacity  ParticleRadius  StartingPointX  StartingPointY  RotationPointX  RotationPointY  StoryBoardBeginTimeP0 	 StoryBoardBeginTimeP1 
 StoryBoardBeginTimeP2  StoryBoardBeginTimeP3  StoryBoardBeginTimeP4  StoryBoardDuration  ParticleOriginAngleP0  ParticleOriginAngleP1  ParticleOriginAngleP2  ParticleOriginAngleP3  ParticleOriginAngleP4  ParticleBeginAngle1  ParticleEndAngle1  ParticleBeginTime1  ParticleDuration1  ParticleBeginAngle2  ParticleEndAngle2  ParticleBeginTime2  ParticleDuration2  ParticleBeginAngle3  ParticleEndAngle3  ParticleBeginTime3  ParticleDuration3  EllipseStyle �� 
TargetType �� Property �� Value��%�  &	        &	 #     &	 H     &	 a     &	 z     &	 �     &	 �     &	 �     &	 �     &		     &	
 ,    &	 P    &	 t    &	 �    &	 �    &	 �    &	 �    &	     &	 &    &	 A    &	 Z    &	 t    &	 �    &	 �    &	 �    &	 �    &	     &	 9    &	 T    &	 o    &	 �    &	 �    7  7  7   7  �� 5
   
   $ 	#FF00496E��60   �� 5   
   $ Transparent��6:   X�5   
   1Q�63   X�5   
   6Q�62   X�5   
   0Q�62   X�5   
   -20Q�64   X�5   
   0.5Q�64   X�5   
   0.5Q�64   i�5   
   00:00:00.000h�6F   i�5   
   00:00:00.100h�6F   i�5   
   00:00:00.200h�6F   i�5   
   00:00:00.300h�6F   i�5   
   00:00:00.400h�6F   E�5   
   00:00:01.800D�6<   X�5   
   0Q�69   X�5   
   -10Q�6;   X�5    
   -20Q�6;   X�5!   
   -30Q�6;   X�5"   
   -40Q�6;   X�5%   
   0Q�67   X�5&   
   90Q�66   i�5'   
   00:00:00.000h�6C   E�5(   
   00:00:00.750D�6;   X�5+   
   90Q�68   X�5,   
   270Q�67   i�5-   
   00:00:00.751h�6C   E�5.   
   00:00:00.300D�6;   X�51   
   270Q�69   X�52   
   360Q�67   i�53   
   00:00:01.052h�6C   E�54   
   00:00:00.750D�6;   �� 56   
   " A�6%   .�57      ��  � ��8   6&   �� 58       � ��8  6'   �� 59       � ��8  6%   �� 5:       �@J�RenderTransformOrigin$ 0.5, 0.5&�66   �� 5;       �@J�Opacity8  6(   5<      5=      .��5>      �� $��50��6   $��50��6    � Triggers 5?   
   :� 5@       :� RoutedEvent$ Canvas.Loaded��6   [�5A      �� 5B      .��5C      ��  g� 	BeginTime# [ 6%    g� Duration# [ 5D   %   	 g� RepeatBehavior$	 Forever��6T   .��5E      W� 
 �� 
TargetName$
 p0��5F   !    �� TargetProperty$9 3(UIElement.RenderTransform).(RotateTransform.Angle)�5G   !    W� From# [ 5H   !   	 W� To# [ 5I   !   # [ 5J   !   # [ 5K   !   W� 5L      $
 p0��5M   !   $9 3(UIElement.RenderTransform).(RotateTransform.Angle)�5N   !   # [ 5O   !   # [ 5P   !   # [ 5Q   !   # [ 5R   !   W� 5S      $
 p0��5T   !   $9 3(UIElement.RenderTransform).(RotateTransform.Angle)�5U   !   # [ 5V   !   # [ 5W   !   # [ 5X   !   # [ 5Y   !   5Z      5[      �� 5\      .��5]      �� # [	 6%   # [ 5^   %   $	 Forever��6T   .��5`      W� $
 p1��6.   $9 3(UIElement.RenderTransform).(RotateTransform.Angle)�5a   .   # [ 5b   .   # [ 6Z   # [ 5c   .   # [ 6^   W� 5d      $
 p1��6.   $9 3(UIElement.RenderTransform).(RotateTransform.Angle)�5e   .   # [ 5f   .   # [ 6Z   # [ 5g   .   # [ 6^   W� 5h      $
 p1��6.   $9 3(UIElement.RenderTransform).(RotateTransform.Angle)�5i   .   # [ 5j   .   # [ 6Z   # [ 5k   .   # [ 6^   5l      5m      �� 5o      .��5p      �� # [
 6%   # [ 5q   %   $	 Forever��6T   .��5r      W� $
 p2��6.   $9 3(UIElement.RenderTransform).(RotateTransform.Angle)�5s   .   # [ 5t   .   # [ 6Z   # [ 5u   .   # [ 6^   W� 5v      $
 p2��6.   $9 3(UIElement.RenderTransform).(RotateTransform.Angle)�5w   .   # [ 5x   .   # [ 6Z   # [ 5y   .   # [ 6^   W� 5z      $
 p2��6.   $9 3(UIElement.RenderTransform).(RotateTransform.Angle)�5{   .   # [ 5|   .   # [ 6Z   # [ 5}   .   # [ 6^   5~      5      �� 5�      .��5�      �� # [ 6%   # [ 5�   %   $	 Forever��6T   .��5�      W� $
 p3��6.   $9 3(UIElement.RenderTransform).(RotateTransform.Angle)�5�   .   # [ 5�   .   # [ 6Z   # [ 5�   .   # [ 6^   W� 5�      $
 p3��6.   $9 3(UIElement.RenderTransform).(RotateTransform.Angle)�5�   .   # [ 5�   .   # [ 6Z   # [ 5�   .   # [ 6^   W� 5�      $
 p3��6.   $9 3(UIElement.RenderTransform).(RotateTransform.Angle)�5�   .   # [ 5�   .   # [ 6Z   # [ 5�   .   # [ 6^   5�      5�      �� 5�      .��5�      �� # [ 6%   # [ 5�   %   $	 Forever��6T   .��5�      W� $
 p4��6.   $9 3(UIElement.RenderTransform).(RotateTransform.Angle)�5�   .   # [ 5�   .   # [ 6Z   # [ 5�   .   # [ 6^   W� 5�      $
 p4��6.   $9 3(UIElement.RenderTransform).(RotateTransform.Angle)�5�   .   # [ 5�   .   # [ 6Z   # [ 5�   .   # [ 6^   W� 5�      $
 p4��6.   $9 3(UIElement.RenderTransform).(RotateTransform.Angle)�5�   .   # [ 5�   .   # [ 6Z   # [ 5�   .   # [ 6^   5�      5�      5�      .+�5�   
   �� -   5         ��Name$ p0��5�      #��[ 6    J� Opacity# [ 6S   z�5�      �� 5�       J� RenderTransformOrigin 5�      8� 5�       8� X# [ 6    8� Y# [ 6<   ._�5�      A� #��[ 6   z�5�      V� 5�      .~�5�      T�  T� X# [ 6-    T� Y# [ 6Q   �� 5�       �� Angle# [ 6*   5�      5�      5�      �� 5�   
   -   5        $ p1��5�      #��[ 6   # [ 6S   z�5�      �� 5�       5�      8� 5�      # [ 6   # [ 6<   ._�5�      A� #��[ 6   z�5�      V� 5�      .~�5�      T� # [ 6-   # [ 6Q   �� 5�      # [ 6*   5�      5�      5�      �� 5�   
   -   5        $ p2��5�      #��[ 6   # [ 6S   z�5�      �� 5�       5�      8� 5�      # [ 6   # [ 6<   ._�5�      A� #��[ 6   z�5�      V� 5�      .~�5�      T� # [ 6-   # [ 6Q   �� 5�      # [ 6*   5�      5�      5�      �� 5�   
   -   5        $ p3��5�      #��[ 6   # [ 6T   z�5�      �� 5�       5�      8� 5�      # [ 6   # [ 6<   ._�5�      A� #��[ 6   z�5�      V� 5�      .~�5�      T� # [ 6-   # [ 6Q   �� 5�      # [ 6*   5�      5�      5�      �� 5�   
   -   5        $ p4��5�      #��[ 6   # [ 6S   z�5�      �� 5�       5�      8� 5�      # [ 6   # [ 6<   ._�5�      A� #��[ 6   z�5�      V� 5�      .~�5�      T� # [ 6-   # [ 6Q   �� 5�      # [ 6*   5�      5�      5�      �� 5�   
   -   5         ��Name$ 
lblPercent��5�   l    �� Left$	 -15��6   
 �� Top$	 -10��6"   ���#006699$	��50%��6H   $��SemiBold"�6V   $y�Hidden=�6�   5�      5�      