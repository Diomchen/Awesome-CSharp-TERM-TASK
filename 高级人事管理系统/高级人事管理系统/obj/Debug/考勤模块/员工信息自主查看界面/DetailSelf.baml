   M S B A M L   `   `   `  ����S  O高级人事管理系统, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Rclr-namespace:高级人事管理系统.考勤模块.员工信息自主查看界面D高级人事管理系统.考勤模块.员工信息自主查看界面  5   	   U    O高级人事管理系统.考勤模块.员工信息自主查看界面.DetailSelf   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   dlocalRclr-namespace:高级人事管理系统.考勤模块.员工信息自主查看界面     5   	   -   5          � Title$  
DetailSelf��5   	   $	��450��6   $	��800��6)    � WindowStyle$
 None=�65    J� Opacity$	 0.9Q�6H   ���#3D3B3B � AllowsTransparency . .��5	      � .+�5
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
   $��	Task List��6   $��36(�6%   $��Center=�63   ���#3D3B3B���	#FFB36A6A$��74��6{   $��Center=�6�   $��Center=�6�   $��Right=�6�   $	��375��6�   $��0,0,208,375.6q�6�   $
��Bold"�6  $��	ROG Fonts)�6  &   System.Windows.Controls.DataGrid  5.   
   -   5        $��dataTaskList��5.      $
��Left=�6'   $	��361��6B   $��	10,79,0,0q�6O   $	��Top=�6b   $	��780��6z      AutoGenerateColumns .     Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      -   5        dtID��,  &System.Windows.Controls.DataGridColumn   Header$ 任务ID��50   3   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *t_id+  51      -   5        	dtSID��$ 职员ID��51   4    6B   �� *s_id+  52      -   5        	dtDec��$5 /                                   任务说明��52   4      Width5  /System.Windows.Controls.DataGridLengthConverter$	 300 6�    6e   �� *
s_declar+6�     53      -   5        dtStart��$ 任务分配时间��53   6    6F   �� *s_startTime+  54      -	   5        	dtEnd��$ 任务截止时间��54   4    6D   �� *	s_endTime+  55      -
   5        	dtProcess��$ 任务进度��55   8    6F   �� *	s_process+57      58      59      