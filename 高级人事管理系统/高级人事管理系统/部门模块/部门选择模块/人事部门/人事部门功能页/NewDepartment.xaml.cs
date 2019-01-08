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

namespace 高级人事管理系统.部门模块.部门选择模块.人事部门.人事部门功能页
{
    /// <summary>
    /// NewDepartment.xaml 的交互逻辑
    /// </summary>
    public partial class NewDepartment : Page
    {
        private MSDSecondEntities db = new MSDSecondEntities();
        public NewDepartment()
        {
            InitializeComponent();
            this.Unloaded += NewDepartment_Unloaded;
        }

        private void NewDepartment_Unloaded(object sender, RoutedEventArgs e)
        {
            db.Dispose();
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = nameBox.Text;
            string manager = managerBox.Text;

            while (!db.staff.Any(u => u.s_name.Trim() == manager.Trim())) {
                MessageBox.Show("不存在此职员！！");
                managerBox.Clear();
                manager = managerBox.Text;
                return;
            }
           

            try
            {

                string strconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\VsProject\\高级人事管理系统\\高级人事管理系统\\bin\\Debug\\MSDSecond.mdf;Integrated Security=True";
                SqlConnection sqlconn = new SqlConnection(strconn);
                sqlconn.Open();

                string sql = "insert into department(m_name,m_production) values (N'" + name + "',N'" + manager + "')";
                SqlCommand sqlcmd = new SqlCommand(sql, sqlconn);
                sqlcmd.ExecuteNonQuery();

                SqlConnection sqlconn1 = new SqlConnection(strconn);
                sqlconn1.Open();
                string sql1 = "update staff set s_post = N'部门经理',s_department = N'" + name + "' where s_name = '" + manager + "' ";
                SqlCommand sqlcmd1 = new SqlCommand(sql1, sqlconn);
                sqlcmd1.ExecuteNonQuery();

                MessageBox.Show("新建成功!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "新建失败");
            }
        }
    }
}
