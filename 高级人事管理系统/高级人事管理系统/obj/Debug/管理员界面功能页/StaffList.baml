   M S B A M L   `   `   `  ����S  O高级人事管理系统, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullu?clr-namespace:高级人事管理系统.管理员界面功能页1高级人事管理系统.管理员界面功能页  5      A    ;高级人事管理系统.管理员界面功能页.StaffList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Qlocal?clr-namespace:高级人事管理系统.管理员界面功能页     5        N� Title$  	StaffList��5	       N� ShowsNavigationUI .   J� Opacity$	 0.9Q�63   .��5      � ���	#FF9F9C9C$	 0.9Q�6"   .+�5   
   �� .+�5      � .+�5      �� $0��*根据用户账号或姓名进行查询：��6   $
��Left=�62   $	��Top=�6M   $��	33,19,0,0q�6e   $	��191��6x   ���	#FF3A17176�   �� 5      -   5        $��searchTextbox��5      $
��Left=�6/   $��23��6J    �� TextWrapping$
 Wrap=�6V   $	��Top=�6j   $	��120��6�   $��
209,19,0,0q�6�   �� 5      -   5        $��	searchBtn��5      $��查询��6*   $
��Left=�67   $��
348,22,0,0q�6R   $	��Top=�6f   $��75��6~   6�   �� 5      -   5        $��
refreshBtn��5      $��刷新��6+   $
��Left=�68   $��
448,22,0,0q�6S   $	��Top=�6g   $��75��6   6�   5      �� 5      $��5��6   ���	#FF8C8080��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ Black��6'    � Offset$ 0Q�65   � 5      $ 	#FF9A3A3A��6'   $ 1Q�69   5      5      �� 5      $��职员信息一览��6   $��	37 5 0 0 q�6&   �� 5      $��5��6   &   System.Windows.Controls.DataGrid  5      -   5        $��dataTest��5         AutoGenerateColumns .  	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5       -   5        	dgtID��,  &System.Windows.Controls.DataGridColumn
   Header$
 职员Id��5    8   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *s_Id+  5!      -   5        dgtName��$
 姓名��5!   :    6F   �� *s_name+  5"      $
 性别��6)    65   �� *
s_gender+4  .System.Windows.Controls.DataGridTemplateColumn  5#      $
 出生日期��6-      SortMemberPath$ 
s_birthday��6;      BirthDateTemplate   CellTemplate# [  6W     EditingBirthDateTemolate   CellEditingTemplate# [ 6�     5$      $
 手机号码��6)    67   �� *	s_phone+  5%      $
 邮箱��6)    65   �� *	s_email+  5&      $
 职位��6)    65   �� *s_post+  5'      $
 薪水��6)    65   �� *
s_salary+  5(      $
 专业��6)    65   �� *	s_major+  5)      $
 部门��6)    65   �� *s_department+  5*      $
 	用户名��6)    66   �� *
s_username+  5+      $
 密码��6)    65   �� *
s_password+  5,       5-      �� 5.      .R�5/   "   �� -   5        $��Center=�5/   )   $��保存��6D   $��Center=�6Q   $��0,1,0,1q�6n   $��30��50   #   $��50��6/   $��0q�6:   6N   51      53        55       56      �� 57      .R�58   "   �� -   5        $��Center=�58   )   $��删除��6D   $��Center=�6Q   $��0,1,0,1q�6n   $��30��59   #   $��50��6/   ���	#FFF60909$��0q�6Q   6e   5:      5<      5>      5?      5@      5A      