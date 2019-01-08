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

namespace 高级人事管理系统.部门模块.部门选择模块.其他部门.其他部门功能页
{
    /// <summary>
    /// StaffWatch.xaml 的交互逻辑
    /// </summary>
    public partial class StaffWatch : Page
    {
        private MSDSecondEntities db = new MSDSecondEntities();
        
        public StaffWatch()
        {
            
            InitializeComponent();
            this.Loaded += StaffWatch_Loaded;

            var list = from x in db.staff
                       join y in db.TaskStaff on x.s_Id equals y.s_id
                       where x.s_department == otherDepartment.cont.Trim()
                       select new
                       {
                           s_Id = x.s_Id,
                           s_name = x.s_name,
                           s_post = x.s_post,
                           s_salary = x.s_salary,
                           t_id = y.t_id,
                           s_process = y.s_process
                       };
            StaffWatchGrid.ItemsSource = list.ToList();
        }

        private void StaffWatch_Loaded(object sender, RoutedEventArgs e)
        {
            db.Dispose();
        }


    }
}
