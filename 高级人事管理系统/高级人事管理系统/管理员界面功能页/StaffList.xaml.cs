using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace 高级人事管理系统.管理员界面功能页
{
    /// <summary>
    /// StaffList.xaml 的交互逻辑
    /// </summary>
    public partial class StaffList : Page
    {
        private MSDSecondEntities db = new MSDSecondEntities();
        
        public StaffList()
        {
            
            InitializeComponent();
            this.Unloaded += StaffList_Unloaded;
            var list = from x in db.staff
                       select x;
            dataTest.ItemsSource=list.ToList();
        }

        private void StaffList_Unloaded(object sender, RoutedEventArgs e)
        {
            db.Dispose();
        }

        private void saveChange(object sender, RoutedEventArgs e)
        {

            try
            {
                int id = (dataTest.SelectedItem as staff).s_Id;
                var b = (staff)dataTest.SelectedItem;


                string strconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\VsProject\\高级人事管理系统\\高级人事管理系统\\bin\\Debug\\MSDSecond.mdf;Integrated Security=True";
                SqlConnection sqlconn = new SqlConnection(strconn);
                sqlconn.Open();

                string sql = "update staff set s_name = '"+b.s_name+"',s_gender = '"+b.s_gender+"',s_birthday = '"+b.s_birthday+"',s_phone = '"+b.s_phone+"',s_email = '"+b.s_email+"',s_post = '"+ b.s_post + "',s_salary = "+b.s_salary+",s_major = '"+b.s_major+"',s_department = '"+b.s_department+"',s_username = '"+b.s_username+"',s_password = '"+b.s_password+"' where s_Id = "+id+"";
                SqlCommand sqlcmd = new SqlCommand(sql, sqlconn);
                sqlcmd.ExecuteNonQuery();
                MessageBox.Show("保存成功!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "保存失败");
            }
        }

        private void deleteStaff(object sender, RoutedEventArgs e)
        {

            try
            {
                int id = (dataTest.SelectedItem as staff).s_Id;

                try
                {
                    string strconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\VsProject\\高级人事管理系统\\高级人事管理系统\\bin\\Debug\\MSDSecond.mdf;Integrated Security=True";
                    SqlConnection sqlconn = new SqlConnection(strconn);
                    sqlconn.Open();

                    string sql = "delete from staff where s_id = "+id+" ";
                    SqlCommand sqlcmd = new SqlCommand(sql, sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show("删除成功!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "删除失败");
                }

                using (var c = new MSDSecondEntities())
                {
                    var x = from t in c.staff select t;
                    dataTest.ItemsSource = x.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "删除失败");
            }
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            try {
                string str = searchTextbox.Text;
                var stf = from x in db.staff
                          where x.s_username == str || x.s_name == str
                          select x;
                dataTest.ItemsSource = stf.ToList();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "未找到此人");
            }
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var c = new MSDSecondEntities())
                {
                    var q = from t in c.staff select t;
                    dataTest.ItemsSource = q.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "刷新失败");
            }
        }
    }
}
