   M S B A M L   `   `   `  ����S  O高级人事管理系统, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:高级人事管理系统高级人事管理系统  5   	   )    #高级人事管理系统.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:高级人事管理系统     5   	   -   5          � Title$!  系统管理员操作界面��5   	   $	��450��6   $	��800��6(    � WindowStyle$
 None=�64    J� Opacity$	 0.9Q�6G    � AllowsTransparency . ���#3D3B3B.��5	      � $��
0,0,0,-0.4q�6   $��Right=�6   $	��800��6;   .+�5
   
   �� -   5         ��Name$ BtnClose��5
      $
��Left=�6$   $��
776,10,0,0q�6?   $	��Top=�6S   $��14��6k   $��15��6v   $��0q�6�   $	 0.5Q�6�    J� RenderTransformOrigin$ 0.5,0.5 &�6�   ��5      �� 5       �� 
TargetType" ��6"   .R�5      �� $��0q�6   ��5      �� 5       �� ImageSource$ /图片/关闭.png��6)   6D   5       �� Triggers 5      P� 5      	 P� Property	 �@J�IsMouseOver
 P� Value
 . . �5      ��  �� Property �@�Cursor �� Value$
 Hand��68   5      5      5      �� 5   
   -   5        $
��Left=�5      $��
748,10,0,0q�6-   $	��Top=�6A   $��23��6Y   $��15��6d   $��0q�6p   $	 0.5Q�6�   ��5      �� 5      " ��6"   .R�5      �� $��0q�6   ��5       �� 5!      $ /图片/减.png��6)   6C   5#       5%      P� 5&      	 �@J�IsMouseOver
 . . �5'      ��  �@�Cursor$
 Hand��68   5(      5*      5,      �� 5-   
   
����� �$��1q�6$   $
��Left=�68   $	��457��6S   $	��Top=�6`   $	��140��6x   $��-11,-3,0,-0.4q�6�   ._�5.      �� $	��457��6   $��Bottom=�6&   $��11.2,-0.8,-13.6,-1.8q�6A   ���	#FF9F9C9C.+�5/      �� $��
Management��6   $��36(�6.   $��Center=�6<   ���#3D3B3B���	#FFB36A6A$��74��6�   $��Center=�6�   $��Center=�6�   $��Right=�6�   $	��375��6�   $��
0,0,-235,0q�6�   $
��Bold"�6  $��	ROG Fonts)�6%  �� 50      -   5        $ 	BtnSelect��50   �    � DataContext$ 	StaffList��6   $��职员一览��61   $��55��6@   $��18(�6L   ���	#FFFFFCFC$��0 15 0 0q�6q   ��51      �� 52       �� 
TargetType" ��6    .�53      ��  � �� �	#FF1283706;   �� 54       � �� 55   "   �� 56   &   " ��66   .R�57   *   �� #��z��61    �� CornerRadius$ 4,4,4,4��6[   ._�58   .   �� $��Center=�6?   $��Center=�6\   59   +   5:   '   5<       �� Triggers 5=      P� 5>   "   	 �@J�IsMouseOver
 . . �5?   &   ��  �@�Cursor$
 Hand��6@   5@   #   5B      5D      �� 5E      -   5        $ BtnSelect_1��5E   �   $ newStaff��6   $��新建职员��60   $��55��6?   $��18(�6K   ���	#FFFFFCFC$��0 3 0 0q�6p   ��5F      �� 5G      " ��6    .�5H      ��  � �� �	#FF1283706;   �� 5I       � �� 5J   "   �� 5K   &   " ��66   .R�5L   *   �� #��z��61   $ 4,4,4,4��6[   ._�5M   .   �� $��Center=�6?   $��Center=�6\   5N   +   5O   '   5Q       5R      P� 5S   "   	 �@J�IsMouseOver
 . . �5T   &   ��  �@�Cursor$
 Hand��6@   5U   #   5W      5Y      �� 5Z      -   5        $ BtnSelect_2��5Z   �   $ Managerm��6   $��管理员一览��60   $��55��6@   $��18(�6L   ���	#FFFFFCFC$��0 3 0 0q�6q   ��5[      �� 5\      " ��6    .�5]      ��  � �� �	#FF1283706;   �� 5^       � �� 5_   "   �� 5`   &   " ��66   .R�5a   *   �� #��z��61   $ 4,4,4,4��6[   ._�5b   .   �� $��Center=�6?   $��Center=�6\   5c   +   5d   '   5f       5g      P� 5h   "   	 �@J�IsMouseOver
 . . �5i   &   ��  �@�Cursor$
 Hand��6@   5j   #   5l      5n      �� 5o      -   5        $ BtnSelect_3��5o   �   $ newAdmin��6   $��新建管理员��60   $��55��6@   $��18(�6L   ���	#FFFFFCFC$��0 3 0 0q�6q   ��5p      �� 5q      " ��6    .�5r      ��  � �� �	#FF1283706;   �� 5s       � �� 5t   "   �� 5u   &   " ��66   .R�5v   *   �� #��z��61   $ 4,4,4,4��6[   ._�5w   .   �� $��Center=�6?   $��Center=�6\   5x   +   5y   '   5{       5|      P� 5}   "   	 �@J�IsMouseOver
 . . �5~   &   ��  �@�Cursor$
 Hand��6@   5   #   5�      5�      5�      5�      �� 5�   
   $��   当前管理员：��6   $��Center=�6$   $
��Left=�6H   $��	0,394,0,0q�6c   $	��Top=�6v   $	��142��6�   ���	#FF4B3B3B6�   �� 5�   
   -   5        $��usernameLabel��5�      $��Center=�6'   $
��Left=�6K   $��	0,419,0,0q�6f   $	��Top=�6y   $	��142��6�   ���	#FFCD7B4E$��16(�6�    � 5�   
   -	   5        $��frame��5�   1     � NavigationUIVisibility$ Hidden=�6   $
��Left=�6>   $	��378��6Y   $��
151,72,0,0q�6f   $	��Top=�6z   $	��639��6�   ���	#FF9F9C9C6�   5�      5�      