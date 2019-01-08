using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace 高级人事管理系统.部门模块.部门选择模块.其他部门.其他部门功能页
{
    /// <summary>
    /// ChangeSalary.xaml 的交互逻辑
    /// </summary>
    public partial class ChangeSalary : Page
    {
        private MSDSecondEntities db = new MSDSecondEntities();
        public ChangeSalary()
        {
            InitializeComponent();
            this.Loaded += ChangeSalary_Loaded;
        }

        private void ChangeSalary_Loaded(object sender, RoutedEventArgs e)
        {
            db.Dispose();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int staffId = int.Parse(staffIDBox.Text);
            string staffName = staffNameBox.Text;
            int staffSalary = int.Parse(staffSalaryBox.Text);



            try
            {
                //MessageBox.Show(staffName + "---" + staffId);
                //while (!(db.staff.Any(u => u.s_name == staffName.Trim() && u.s_Id == staffId)))
                //{
                //    MessageBox.Show("不存在此职员！！");
                //    staffIDBox.Clear();
                //    staffNameBox.Clear();
                //    staffId = int.Parse(staffIDBox.Text);
                //    staffName = staffNameBox.Text;
                //    return;
                //}
                
                string strconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\VsProject\\高级人事管理系统\\高级人事管理系统\\bin\\Debug\\MSDSecond.mdf;Integrated Security=True";
                SqlConnection sqlconn = new SqlConnection(strconn);
                sqlconn.Open();

                string sql = "insert into ApplySalary(s_Id,a_salary,s_department,s_rewAPub) values (" + staffId + "," + staffSalary + ",N'" + otherDepartment.cont + "'," + 0 + ")";
                SqlCommand sqlcmd = new SqlCommand(sql, sqlconn);
                sqlcmd.ExecuteNonQuery();

                MessageBox.Show("申请成功!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "申请失败");
            }
        }
    }
}
