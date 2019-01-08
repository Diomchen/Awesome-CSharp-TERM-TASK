using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Managerm.xaml 的交互逻辑
    /// </summary>
    public partial class Managerm : Page
    {
        private MSDSecondEntities db = new MSDSecondEntities();
        public Managerm()
        {
            InitializeComponent();
            this.Loaded += Managerm_Loaded;
            var list = from x in db.Admin
                       select x;
            datatest1.ItemsSource = list.ToList();
        }

        private void Managerm_Loaded(object sender, RoutedEventArgs e)
        {
            db.Dispose();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string str = searchTextbox.Text;
                var stf = from x in db.Admin
                          where x.a_User == str
                          select x;
                datatest1.ItemsSource = stf.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "未找到此人");
            }
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var c = new MSDSecondEntities())
                {
                    var q = from t in c.Admin select t;
                    datatest1.ItemsSource = q.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "刷新失败");
            }
        }

        private void saveChange(object sender, RoutedEventArgs e)
        {

            try
            {
                int id = (datatest1.SelectedItem as Admin).Id;
                var b = (Admin)datatest1.SelectedItem;


                string strconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\VsProject\\高级人事管理系统\\高级人事管理系统\\bin\\Debug\\MSDSecond.mdf;Integrated Security=True";
                SqlConnection sqlconn = new SqlConnection(strconn);
                sqlconn.Open();

                string sql = "update Admin set a_User = '" + b.a_User + "',a_Pass = '" + b.a_Pass+ "' where Id = " + id + "";
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
                int id = (datatest1.SelectedItem as Admin).Id;

                try
                {
                    string strconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\VsProject\\高级人事管理系统\\高级人事管理系统\\bin\\Debug\\MSDSecond.mdf;Integrated Security=True";
                    SqlConnection sqlconn = new SqlConnection(strconn);
                    sqlconn.Open();

                    string sql = "delete from Admin where Id = " + id + " ";
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
                    var x = from t in c.Admin select t;
                    datatest1.ItemsSource = x.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "删除失败");
            }
        }
    }
}
