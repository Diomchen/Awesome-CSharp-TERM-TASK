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
    /// AssoDepartmentManager.xaml 的交互逻辑
    /// </summary>
    public partial class AssoDepartmentManager : Page
    {
        private MSDSecondEntities db = new MSDSecondEntities();
        public AssoDepartmentManager()
        {
            InitializeComponent();
            this.Unloaded += AssoDepartmentManager_Unloaded;

            var list = from x in db.department
                       select x;
            dataDepartment.ItemsSource = list.ToList();
        }

        private void AssoDepartmentManager_Unloaded(object sender, RoutedEventArgs e)
        {
            db.Dispose();
        }

        private void saveChange(object sender, RoutedEventArgs e)
        {

            try
            {
                int id = (dataDepartment.SelectedItem as department).m_Id;
                var b = (department)dataDepartment.SelectedItem;


                string strconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\VsProject\\高级人事管理系统\\高级人事管理系统\\bin\\Debug\\MSDSecond.mdf;Integrated Security=True";
                SqlConnection sqlconn = new SqlConnection(strconn);
                sqlconn.Open();

                string sql = "update department set m_Id = '" + b.m_Id + "',m_name = '" + b.m_name + "',m_productionc = '" + b.m_production + "' where m_Id = " + id + "";
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
                int id = (dataDepartment.SelectedItem as department).m_Id;

                try
                {
                    string strconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\VsProject\\高级人事管理系统\\高级人事管理系统\\bin\\Debug\\MSDSecond.mdf;Integrated Security=True";
                    SqlConnection sqlconn = new SqlConnection(strconn);
                    sqlconn.Open();

                    string sql = "delete from department where m_Id = " + id + " ";
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
                    var x = from t in c.department select t;
                    dataDepartment.ItemsSource = x.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "删除失败");
            }
        }
        
    }
}
