   M S B A M L   `   `   `  ����S  O高级人事管理系统, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullu?clr-namespace:高级人事管理系统.管理员界面功能页1高级人事管理系统.管理员界面功能页  5      @    :高级人事管理系统.管理员界面功能页.newStaff   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Qlocal?clr-namespace:高级人事管理系统.管理员界面功能页     5        N� Title$  newStaff��5	       N� ShowsNavigationUI .   J� Opacity$	 0.9Q�62    � 	Resources 5
         BirthDateTemplate �� StringFormat��%b   &	        �� 5   
   .R�5      �� ��6   �� *出生日期+$ 
yyyy-MM-dd��5      5      .��5      � ���	#FF9F9C9C$	 0.9Q�6"   $��0,0,0.2,-109.4q�60   .+�5   
   �� $
��Left=�6   $��	67,0,0,95q�60   $	��314��6C   $��Bottom=�6P   $	��268��6k   .+�5      � $
��55 0q�6   .+�5      �� $��姓名:��6   �� 5      -   5        $��nameBox��5      $	��100��6)   5      � 5      $��55 15 q�6   .+�5      �� $��性别:��6   �� 5      -   5        $��genderCombox��5      $��40��6/    5       �� 
TargetType �� Property �� Value��%�   '��       �� 5      " ��6    .�5      ��  �@��CornerRadius$ 2��6=   �� 5       �@J�Opacity$	 0.8Q�68   5      5      .@�5      �� $	��男��6#   $
��Left=�6/   $��40��6J   $��14(�6U   �� 5      $	��女��6#   $
��Left=�6/   $��40��6J   $��14(�6U   5       5!      � 5"      $��	31 0 10 0q�6   .+�5#      �� $��出生日期:��6   � 5$      .+�5%      (  "System.Windows.Controls.DatePicker  -   5        $��datePickerBirthDate��5%   !      SelectedDateFormat$ Short=�6<   5&      5(      � 5)      $��30 20q�6   .+�5*      �� $��手机号码:��6   �� 5+      -   5        $��phoneBox��5+      $	��100��6*   5,      � 5-      $
��55 0q�6   .+�5.      �� $��邮箱:��6   �� 5/      -   5        $��emailBox��5/      $	��100��6*   50      52      �� 53   
   -   5        $��
SaveDetail��53      $��保存��6   $	��100��60   $��40��6<   $��272,310,267,137q�6H   6a   �� 54   
   $��Right=�6   $��	0,0,65,95q�61   $	��314��6D   $��Bottom=�6Q   $	��234��6l   .+�55      � $
��35 0q�6   .+�56      �� $��职位:��6   �� 57      -   5        $��postBox��57      $	��100��6)   58      � 59      $��35 15q�6   .+�5:      �� $��薪水:��6   �� 5;      -   5        $��	salaryBox��5;      $	��100��6+   5<      � 5>      $
��35 0q�6   .+�5?      �� $��专业:��6   �� 5@      -	   5        $��majorBox��5@      $	��100��6*   5A      � 5C      $��	35 10 0 0q�6   .+�5D      �� $��部门:��6   �� 5E      -
   5        $��departmentCombox��5E      $	��120��63    5F      ��%�   '��       �� 5G      " ��6    .�5H      ��  �@��CornerRadius$ 2��6=   �� 5I       �@J�Opacity$	 0.4Q�68   5J      5K      .@�5L      �� $��人事管理部��6#   $
��Left=�63   $	��120��6N   $��14(�6Z   �� 5M      $��A部门��6#   $
��Left=�61   $	��120��6L   $��14(�6X   �� 5N      $��B部门��6#   $
��Left=�61   $	��120��6L   $��14(�6X   5O      5P      � 5Q      $��25 10q�6   .+�5R      �� $��
用户名:��6   �� 5S      -   5        $��usernameBox��5S      $	��100��6.   5T      � 5U      $
��35 0q�6   .+�5V      �� $��密码:��6   �� 5W      -   5        $��passwordBox��5W      $	��100��6-   5X      5Z      5[      5\      