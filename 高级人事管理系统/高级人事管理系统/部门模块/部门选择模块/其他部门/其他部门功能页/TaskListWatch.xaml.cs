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

namespace 高级人事管理系统.部门模块.部门选择模块.其他部门.其他部门功能页
{
    /// <summary>
    /// TaskListWatch.xaml 的交互逻辑
    /// </summary>
    public partial class TaskListWatch : Page
    {
        private MSDSecondEntities db = new MSDSecondEntities();
        public TaskListWatch()
        {
            InitializeComponent();
        }

        private void ASsoTask_Click(object sender, RoutedEventArgs e)
        {
            //TaskStaff ts = new TaskStaff();
            //ts.s_id = int.Parse(idBox.Text);
            //ts.s_declar = declarBox.Text;
            //ts.s_startTime = StartTimeBox.SelectedDate.Value.Date;
            //ts.s_endTime = EndTimeBox.SelectedDate.Value.Date;
            //ts.s_process = 0;
            //int ids = int.Parse(idBox.Text);
            int id = int.Parse(idBox.Text);
            string dec = declarBox.Text;
            DateTime startTime = StartTimeBox.SelectedDate.Value.Date;
            DateTime endTime = EndTimeBox.SelectedDate.Value.Date;
            int process = 0;

            while (db.TaskStaff.Any(u => u.s_id == id))
            {
                MessageBox.Show("数据库已存在相同任务");
                idBox.Clear();
                id = int.Parse(idBox.Text);
                //ts.s_id = int.Parse(idBox.Text);
                return;
            }

            try
            {
                var staff = from s in db.staff
                            where s.s_department == otherDepartment.cont.Trim() && s.s_post != "部门经理"
                            select s;

                foreach (var d in staff) {
                    string strconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\VsProject\\高级人事管理系统\\高级人事管理系统\\bin\\Debug\\MSDSecond.mdf;Integrated Security=True";
                    SqlConnection sqlconn = new SqlConnection(strconn);
                    sqlconn.Open();

                    string sql = "insert into TaskStaff(t_id , s_id , s_declar , s_startTime , s_endTime , s_process) values (" + id + "," + d.s_Id + ",N'" + dec + "','" + startTime + "','" + endTime + "'," + process + ")";
                    SqlCommand sqlcmd = new SqlCommand(sql, sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    sqlconn.Close();
                }
                MessageBox.Show("保存成功!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"保存失败。");
            }
        }
    }
}
