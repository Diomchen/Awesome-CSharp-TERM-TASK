using System;
using System.Collections.Generic;
using System.Data;
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

namespace 高级人事管理系统.部门模块.部门选择模块.人事部门.人事部门功能页
{
    /// <summary>
    /// AllDepartment.xaml 的交互逻辑
    /// </summary>
    public partial class AllDepartment : Page
    {
        private MSDSecondEntities db = new MSDSecondEntities();
        public AllDepartment()
        {
            InitializeComponent();
            this.Unloaded += AllDepartment_Unloaded;
      
            var list = from x in db.staff
                       join y in db.CheckStaff on x.s_name equals y.c_name
                       select new
                       {
                           s_Id = x.s_Id,
                           s_name = x.s_name,
                           s_post = x.s_post,
                           s_department = x.s_department,
                           s_salary = x.s_salary,
                           c_normal = y.c_normal,
                           c_late = y.c_late
                       };

            dataDepartAndStaff.ItemsSource = list.ToList();

            var list0 = from x in db.staff
                        join a in db.ApplySalary on x.s_Id equals a.s_Id
                        select new
                        {
                            s_Id = x.s_Id,
                            s_name = x.s_name,
                            s_post = x.s_post,
                            s_department = x.s_department,
                            s_salary = x.s_salary,
                            a_salary = a.a_salary,
                            s_rewAPub = a.s_rewAPub,
                        };
            dataChangeStaffSalary.ItemsSource = list0.ToList();
        }

        private void AllDepartment_Unloaded(object sender, RoutedEventArgs e)
        {
            db.Dispose();
        }

        private void saveChange(object sender, RoutedEventArgs e)
        {
            var a = this.dataChangeStaffSalary.SelectedItem;
            string b = a.ToString();
            int id = int.Parse((b.Split('=', ','))[1].Trim().ToString());

            try
            {
                int sa = 0;
                int re = 0;
                var li = from x in db.ApplySalary
                         where x.s_Id == id
                         select x;

                foreach (var x in li)
                {
                    sa = x.a_salary;
                    if (x.s_rewAPub == null)
                    {
                        re = 0;
                    }
                    else
                    {
                        re = int.Parse(x.s_rewAPub.ToString())*100;
                    }
                }

                string strconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\VsProject\\高级人事管理系统\\高级人事管理系统\\bin\\Debug\\MSDSecond.mdf;Integrated Security=True";
                SqlConnection sqlconn = new SqlConnection(strconn);
                sqlconn.Open();

                string sql = "update staff set s_salary = '" + (sa + re) + "'  where s_Id = " + id + "";
                SqlCommand sqlcmd = new SqlCommand(sql, sqlconn);
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "保存失败");
            }

            try
            {
                string strconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\VsProject\\高级人事管理系统\\高级人事管理系统\\bin\\Debug\\MSDSecond.mdf;Integrated Security=True";
                SqlConnection sqlconn = new SqlConnection(strconn);
                sqlconn.Open();

                string sql = "delete from ApplySalary where s_id = " + id + " ";
                SqlCommand sqlcmd = new SqlCommand(sql, sqlconn);
                sqlcmd.ExecuteNonQuery();
                MessageBox.Show("操作成功!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "保存失败");
            }

            var list = from x in db.staff
                       join y in db.CheckStaff on x.s_name equals y.c_name
                       select new
                       {
                           s_Id = x.s_Id,
                           s_name = x.s_name,
                           s_post = x.s_post,
                           s_department = x.s_department,
                           s_salary = x.s_salary,
                           c_normal = y.c_normal,
                           c_late = y.c_late
                       };

            dataDepartAndStaff.ItemsSource = list.ToList();

            var list0 = from x in db.staff
                        join f in db.ApplySalary on x.s_Id equals f.s_Id
                        select new
                        {
                            s_Id = x.s_Id,
                            s_name = x.s_name,
                            s_post = x.s_post,
                            s_department = x.s_department,
                            s_salary = x.s_salary,
                            a_salary = f.a_salary,
                            s_rewAPub = f.s_rewAPub,
                        };
            dataChangeStaffSalary.ItemsSource = list0.ToList();

        }

        private void deleteStaff(object sender, RoutedEventArgs e)
        {

            try
            {
                var z = this.dataChangeStaffSalary.SelectedItem;
                string b = z.ToString();
                int id = int.Parse((b.Split('=', ','))[1].Trim().ToString());

                try
                {
                    string strconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\VsProject\\高级人事管理系统\\高级人事管理系统\\bin\\Debug\\MSDSecond.mdf;Integrated Security=True";
                    SqlConnection sqlconn = new SqlConnection(strconn);
                    sqlconn.Open();

                    string sql = "delete from ApplySalary where s_id = " + id + " ";
                    SqlCommand sqlcmd = new SqlCommand(sql, sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show("操作成功!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "操作失败");
                }
                finally {

                    var list = from x in db.staff
                               join y in db.CheckStaff on x.s_name equals y.c_name
                               select new
                               {
                                   s_Id = x.s_Id,
                                   s_name = x.s_name,
                                   s_post = x.s_post,
                                   s_department = x.s_department,
                                   s_salary = x.s_salary,
                                   c_normal = y.c_normal,
                                   c_late = y.c_late

                               };
                    dataDepartAndStaff.ItemsSource = list.ToList();


                    var list0 = from x in db.staff
                                join a in db.ApplySalary on x.s_Id equals a.s_Id
                                select new
                                {
                                    s_Id = x.s_Id,
                                    s_name = x.s_name,
                                    s_post = x.s_post,
                                    s_department = x.s_department,
                                    s_salary = x.s_salary,
                                    a_salary = a.a_salary,
                                    s_rewAPub = a.s_rewAPub,
                                };
                    dataChangeStaffSalary.ItemsSource = list0.ToList();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "删除失败");
            }
        }
        
    }
}
