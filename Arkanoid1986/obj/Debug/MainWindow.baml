   M S B A M L   `   `   `  ����G  CArkanoid1986, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Arkanoid1986Arkanoid1986  5   	       Arkanoid1986.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Arkanoid1986     5   	   -   5          � Title$  Arkanoid 1986��5   	   $	��682��6   $	��754��6,    � 
ResizeMode$ CanMinimize=�68    � Triggers 5	      :� 5
   
    :� RoutedEvent$ Loaded��6   [�5      �� 5      .��5      ��  �� TargetProperty$ Width�6!    �� 
TargetName$ labelStartGame��68   .��5      W�  W� From$ 0X�6*   	 W� To$	 400X�63    g� AutoReverse .  	 g� Duration$	 0:0:3D�5      5      5      5      
 � 	Resources
 5         aniTextBlock1 �� 
TargetType �� Property �� Value �� Color �� Triggers �� From	 �� To g� RepeatBehavior  startButton �� 
TargetType �� Triggers ��Name �� CornerRadius  pauseButton  highScoreButton  playSoundButton  muteSoundButton  saveLoadButton  bCanvas �� ImageSource �� Opacity 
 paddle 	 bal��%h  &	        &	 z    &	 �    &	 *    &	 �    &	 �
    &	 2    &	 �    &	     &		 �    �� 5   
   " ��6&   .�5      ��  � �� 5      �� 5      $ 	OrangeRed��6&   5!       5"      :� 5#      $ TextBlock.Loaded��6   .[�5$      �� .��5%      �� .��5&      �� $( "Foreground.(SolidColorBrush.Color)�6-   $ 	OrangeRedX�6l   $ DarkBlueX�6}   $	 0:0:1D�6�    . $ Forever��6�   5'      5(      5)      5+      �� 5,   
   " ��6$   .�5-      ��  � �� 5.      �� 5/      " ��6&    50      :� 51      $ Click��6+   .[�52   "   �� .��53   &   �� .��54   *   W� $ 	startGame��55   )   $ Opacity�56   )   $ 0X�57   )   $ 1X�62   $	 0:0:0.3D�69   58   '   59   #   5:      .R�5<      �� $ 	startGame��6!   $ 25��64   
������$��2q�6b   
����ح�$��45��5=   ,   $	��150��68   ._�5>      �� $��10q�6-   $��Center=�69   $��Center=�6V   $��
Start Game��6q   $��Broadway)�6�   $
��Bold"�6�   $��18(�6�   5?      5@      5B      5D      �� 5E   
   " ��6$   .�5F      ��  � �� 5G      �� 5H      " ��6&    5I      :� 5J      $ Click��6+   .[�5K   "   �� .��5L   &   �� .��5M   *   W� $ 	pauseGame��5N   )   $ Opacity�5O   )   $ 0X�5P   )   $ 1X�62   $	 0:0:0.3D�69   5Q   '   5R   #   5S      .R�5U      �� $ 	pauseGame��6!   $ 25��64   
������$��2q�6b   
����ح�$��45��5V   ,   $	��150��68   ._�5W      �� $��10q�6-   $��Center=�69   $��Center=�6V   $��
Pause Game��6q   $��Broadway)�6�   $
��Bold"�6�   $��18(�6�   5X      5Y      5[      5]      �� 5^   
   " ��6(   .�5_      ��  � �� 5`      �� 5a      " ��6&    5b      :� 5c      $ Click��6+   .[�5d   "   �� .��5e   &   �� .��5f   *   W� $ 	highscore��5g   )   $ Opacity�5h   )   $ 0X�5i   )   $ 1X�62   $	 0:0:0.3D�69   5j   '   5k   #   5l      .R�5n      �� $ 	highscore��6!   $ 25��64   
������$��2q�6b   
����ح�$��45��5o   ,   $	��150��68   ._�5p      �� $��10q�6-   $��Center=�69   $��Center=�6V   $��
High Score��6q   $��Broadway)�6�   $
��Bold"�6�   $��18(�6�   5q      5r      5t      5v      �� 5w   
   " ��6(   .�5x      ��  � �� 5y      �� 5z      " ��6&    5{      :� 5|      $ Click��6+   .[�5}   "   �� .��5~   &   �� .��5   *   W� $ 	playSound��5�   )   $ Opacity�5�   )   $ 0X�5�   )   $ 1X�62   $	 0:0:0.3D�69   5�   '   5�   #   5�      .R�5�      �� $ 	playSound��6!   $ 25��64   
������$��2q�6b   
����ح�$��45��5�   ,   $	��150��68   ._�5�      �� $��10q�6-   $��Center=�69   $��Center=�6V   $��
Play Sound��6q   $��Broadway)�6�   $
��Bold"�6�   $��18(�6�   5�      5�      5�      5�      �� 5�   
   " ��6(   .�5�      ��  � �� 5�      �� 5�      " ��6&    5�      :� 5�      $ Click��6+   .[�5�   "   �� .��5�   &   �� .��5�   *   W� $ 	muteSound��5�   )   $ Opacity�5�   )   $ 0X�5�   )   $ 1X�62   $	 0:0:0.3D�69   5�   '   5�   #   5�      .R�5�      �� $ 	muteSound��6!   $ 25��64   
������$��2q�6b   
����ح�$��45��5�   ,   $	��150��68   ._�5�      �� $��10q�6-   $��Center=�69   $��Center=�6V   $��
Mute Sound��6q   $��Broadway)�6�   $
��Bold"�6�   $��18(�6�   5�      5�      5�      5�      �� 5�   
   " ��6'   .�5�      ��  � �� 5�      �� 5�      " ��6&    5�      :� 5�      $ Click��6+   .[�5�   "   �� .��5�   &   �� .��5�   *   W� $ saveLoad��5�   )   $ Opacity�5�   )   $ 0X�5�   )   $ 1X�62   $	 0:0:0.3D�69   5�   '   5�   #   5�      .R�5�      �� $ saveLoad��6!   $ 25��63   
������$��2q�6a   
����ح�$��45��5�   ,   $	��150��68   ._�5�      �� $��10q�6-   $��Center=�69   $��Center=�6V   $��	Save/Load��6q   $��Broadway)�6�   $
��Bold"�6�   $��18(�6�   5�      5�      5�      5�      �� 5�   
   " ��6    .�5�      ��  � �� 5�      �� 5�      $ Img/background.png��6!   $ .9Q�6B   5�      5�      �� 5�   
   " ��6   .�5�      ��  � �� 5�      �� 5�      $ Img/paddle.png��6!   5�      5�      �� 5�   
   " A�6   .�5�      ��  � �� 5�      �� 5�      $ Img/ball-dark.png��6!   5�      5�      5�      .��5�      �� -   5         ��Name$ 
canvasGame��5�      #��[ 6!   .+�5�   
   �� -   5         ��Name$
 Menu��5�      $	��600��6#    �� Left$	 573��60   $	��175��6B   
���   �
 �� Top$ 51��6a   .+�5�      �� -   5         ��Name$ 	startGame��5�      #��[ 6(   $��
0,-40,10,0q�6Y   $	��124��6�   �� 5�      -   5        $ pause��5�      #��[ 6$   $��
0,-30,10,0q�6V   $	��124��6j   6w   �� 5�      -   5        $ 	highScore��5�      #��[ 6(   $��
0,-20,10,0q�6]   $	��124��6�   �� 5�      -   5        $ sound��5�      #��[ 6$   $��
0,-20,10,0q�6Y   $	��124��6m   6z   �� 5�      -   5        $ Notsound��5�      #��[ 6'   $��
0,-20,10,0q�6\   $	��124��6p   6}   �� 5�      -	   5        $ SaveGameButton��5�      #��[ 6-   $��
0,-20,10,0q�6a   $	��124��6u   6�   5�      �� 5�   
   -
   5        $ 	borderTop��5�      
���   �$	��748��67   $��51��6C   ._�5�      ��  �� Orientation$ 
Horizontal=�6   .+�5�      �� -   5         ��Name$ Score��5�      
��� E��$��20(�6B   $��Broadway)�6P   $��55,10,300,10q�6f   $��UltraCondensed&�6|   $��
ExtraBlack"�6�   ��6�   Z� SCORE:5�      �� 5�      -   5        $ 	Highscore��5�      #��[  6/   
��� E��$��20(�6n   $��Broadway)�6|   $��37��6�   $��0,10,0,4q�6�   $	��205��6�   �� 6�   $�High Score:��6�   5�      5�      5�      �� 5�   
   -   5        $ 	borderBot��5�      
���   �$	��563��67   $��51��6C   $	 600��6O   $ 10��6`   ._�5�      �� -   5        $ Level��5�      
��� E��$��20(�6>   $��Broadway)�6L   $��55,10,18,10q�6b   $��UltraCondensed&�6w   $��
ExtraBlack"�6�   ��6�   Z� Level:6�   5�      �� 5�   
   -   5        $ 
borderLeft��5�      
���   �$	��648��68   $��57��6D   $	 297��6P     J� RenderTransformOrigin$  0.5,0.5&�6a   $
 -299��6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      ! �� Angle$! -89.789Q�6&   T� 5�      5�      ._�5�      �� $ Vertical=�6   .+�5      �� -   5        " ��Name$" life1��5      $��Img/life.png��6'   $��50��6=   $��
0,0,-500,0q�6I   z�5     �� 5     -   5        MyAnimatedScaleTransform2��# �� ScaleX$# 1Q�5     $ �� ScaleY$$ 1Q�6    5     :� 5     $ Loaded��6'   % :� 
SourceName$% life1��6<   .[�5     �� .��5  "   �� .��5	  &   W� $ MyAnimatedScaleTransform2��5
     $ (ScaleTransform.ScaleX)�5     $	 1.3X�5     $	 0:0:0.3D�6    . $ Forever��5     5  #   5     5     5     �� 5     -   5        $" life2��5     $��Img/life.png��6'   $��50��6=   $��0,-50,-400,0q�6J   z�5     �� 5     -   5        MyAnimatedScaleTransform1��$# 1Q�5     $$ 1Q�6    5     :� 5     $ Loaded��6'   $% life2��6<   .[�5     �� .��5  "   �� .��5  &   W� $ MyAnimatedScaleTransform1��5     $ (ScaleTransform.ScaleX)�5      $	 1.3X�5!     $	 0:0:0.3D�6    . $ Forever��5"     5#  #   5$     5%     5'     �� 5(     -   5        $" life3��5(     $��Img/life.png��6'   $��50��6=   $��0,-50,-300,0q�6J   z�5*     �� 5+     -   5        MyAnimatedScaleTransform��$# 1Q�5,     $$ 1Q�6    5.     :� 5/     $ Loaded��6'   $% life3��6<   .[�50     �� .��51  "   �� .��52  &   W� $ MyAnimatedScaleTransform��53     $ (ScaleTransform.ScaleX)�54     $	 1.3X�55     $	 0:0:0.3D�6    . $ Forever��56     57  #   58     59     5;     5=     5>     �� 5?  
   -   5        & ��Name$& rectTop��5?     
����  �$��21��61   $	��524��6=   $ 50��6I   $ 51��6Z   �� 5@  
   -   5        $& rectBot��5@     
����  �$��21��61   $	��523��6=   $ 50��6I   $	 579��6Z   �� 5A  
   -   5        $& rectLeft��5A     
����  �$��25��62   $	��546��6>   $
 -205��6J   $	 321��6]   $  0.503,0.912&�6n   z�5B     V� 5C     .~�5D     �� �� 5E     �� 5F     $! 89.982Q�6&   T� 5G     ' T� X$' -18.046Q�6)   ( T� Y$( -15.241Q�65   5H     5J     �� 5K  
   -   5        $& 	rectRight��5K     
����  �$��25��63   $	��547��6?   $	 294��6K   $	 319��6]   $  0.503,0.912&�6n   z�5L     V� 5M     .~�5N     �� �� 5O     �� 5P     $! 90.19Q�6&   T� 5Q     $' -18.046Q�6)   $( -15.241Q�65   5R     5T     �� 5U  
   -   5        ) ��Name$) labelStartGame��5U     $��Press START GAME or G��6(   $	 100��6H   $	 235��6Z   $	��445��6k   $��Broadway)�6w   $
��Bold"�6�   $��24(�6�   $	��135��6�   $��Center=�6�   * � UseLayoutRounding* . $��Right=�6�   + J� IsHitTestVisible+ .  $��Center=�6,  A� 5V  
   -   5        , A�Name$
, Ball��5V     #��[	 6    $��22��6=   $	 532��6H   $	 288��6Y   $��22��6l   �� 5W  
   -   5        $& rocket��5W     #��[ 6$   $��82��6F   $��15��6Q   $	 258��6]   $	 559��6o   5X     5Y     