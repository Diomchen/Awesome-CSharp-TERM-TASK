using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 高级人事管理系统.管理员界面功能页
{
    /// <summary>
    /// newStaff.xaml 的交互逻辑
    /// </summary>
    public partial class newStaff : Page
    {
        public newStaff()
        {
            InitializeComponent();
        }

        private void SaveDetail_Click(object sender, RoutedEventArgs e)
        {
            
            using (var db = new MSDSecondEntities()) {
                staff stf = new staff();
                stf.s_name = nameBox.Text;
                ComboBoxItem item = genderCombox.SelectedItem as ComboBoxItem;
                stf.s_gender = item.Content.ToString();
                stf.s_birthday = datePickerBirthDate.SelectedDate.Value.Date;
                stf.s_phone = phoneBox.Text;
                stf.s_email = emailBox.Text;
                stf.s_post = postBox.Text;
                stf.s_salary = int.Parse(salaryBox.Text);
                stf.s_major = majorBox.Text;
                ComboBoxItem item1 = departmentCombox.SelectedItem as ComboBoxItem;
                stf.s_department = item1.Content.ToString();
                stf.s_username = usernameBox.Text;
                stf.s_password = passwordBox.Text;

                while (db.staff.Any(u => u.s_username == usernameBox.Text)) {
                    MessageBox.Show("数据库已存在相同用户名的");
                    MessageBox.Show(stf.s_username + " "+ stf.s_password);
                    usernameBox.Clear();
                    passwordBox.Clear();
                    stf.s_username = usernameBox.Text;
                    stf.s_password = passwordBox.Text;
                    return;
                }
                
                try {
                    db.staff.Add(stf);
                    db.SaveChanges();
                    MessageBox.Show("保存成功!");
                }
                catch(Exception ex) {
                    MessageBox.Show("保存失败。");
                }

            }

        }
 
    }
}
