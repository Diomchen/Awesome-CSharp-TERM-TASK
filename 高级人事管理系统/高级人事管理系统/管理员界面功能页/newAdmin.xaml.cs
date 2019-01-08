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
    /// newAdmin.xaml 的交互逻辑
    /// </summary>
    public partial class newAdmin : Page
    {
        public newAdmin()
        {
            InitializeComponent();
        }

        private MSDSecondEntities db = new MSDSecondEntities();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try {
                string strconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\VsProject\\高级人事管理系统\\高级人事管理系统\\bin\\Debug\\MSDSecond.mdf;Integrated Security=True";
                SqlConnection sqlconn = new SqlConnection(strconn);
                sqlconn.Open();

                string username = usernameBox.Text;
                string password = passwordBox.Text;

                string sql = "insert into Admin(a_User,a_Pass) values ('" + username + "','" + password + "')";
                SqlCommand sqlcmd = new SqlCommand(sql, sqlconn);
                sqlcmd.ExecuteNonQuery();
                MessageBox.Show("添加成功!");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message,"添加失败");
            }
        }
    }
}
