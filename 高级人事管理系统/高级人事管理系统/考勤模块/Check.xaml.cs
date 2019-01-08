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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using 高级人事管理系统.考勤模块.员工信息自主查看界面;

namespace 高级人事管理系统.考勤模块
{
    /// <summary>
    /// Check.xaml 的交互逻辑
    /// </summary>
    public partial class Check : Window
    {
        private MSDSecondEntities db = new MSDSecondEntities();
        public Check(string username)
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            string name = "";
            int idc = 0;
            string department = "";

            var stf = from x in db.staff
                      where x.s_username.Trim() == username.Trim()
                      select x;

            foreach (var x in stf)
            {
                name = x.s_name;
                idc = x.s_Id;
                department = x.s_department;
            }
           
            nameLabel.Content = name;
            idLabel.Content = idc.ToString();
            departmentLabel.Content = department;

            int hour = DateTime.Now.Hour;

            var isExsit = db.CheckStaff.Any(u => u.c_name.Trim() == name.Trim());
            if (!isExsit)
            {
                string strconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\VsProject\\高级人事管理系统\\高级人事管理系统\\bin\\Debug\\MSDSecond.mdf;Integrated Security=True";
                SqlConnection sqlconn = new SqlConnection(strconn);
                sqlconn.Open();

                string sql = "insert into CheckStaff(c_name,c_normal,c_late) values ('" + name + "'," +0+ ","+0+")";

                SqlCommand sqlcmd = new SqlCommand(sql, sqlconn);
                sqlcmd.ExecuteNonQuery();
            }
            else {
                //MessageBox.Show(hour.ToString());
                if (hour >= 6 && hour <= 10)
                {
                    statusLabel.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                    statusLabel.Content = "正常";
                    string strconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\VsProject\\高级人事管理系统\\高级人事管理系统\\bin\\Debug\\MSDSecond.mdf;Integrated Security=True";
                    SqlConnection sqlconn = new SqlConnection(strconn);
                    sqlconn.Open();

                    string sql = "update CheckStaff set c_normal = c_normal + 1 where c_name = '"+name+"'";

                    SqlCommand sqlcmd = new SqlCommand(sql, sqlconn);
                    sqlcmd.ExecuteNonQuery();

                }
                else if (hour > 10 && hour < 22)
                {
                    statusLabel.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                    statusLabel.Content = "迟到";
                    string strconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\VsProject\\高级人事管理系统\\高级人事管理系统\\bin\\Debug\\MSDSecond.mdf;Integrated Security=True";
                    SqlConnection sqlconn = new SqlConnection(strconn);
                    sqlconn.Open();

                    string sql = "update CheckStaff set c_late = c_late + 1 where c_name = '" + name + "'";

                    SqlCommand sqlcmd = new SqlCommand(sql, sqlconn);
                    sqlcmd.ExecuteNonQuery();

                }
                else
                {
                    statusLabel.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    statusLabel.Content = " -无- ";
                }
            }

            

            
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//实现拖拽功能
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        public void Rotate()
        {
            Storyboard storyboard = new Storyboard();//创建故事板
            DoubleAnimation doubleAnimation = new DoubleAnimation();//实例化一个Double类型的动画
            RotateTransform rotate = new RotateTransform();//旋转转换实例
            this.BtnClose.RenderTransform = rotate;//给图片空间一个转换的实例
            storyboard.SpeedRatio = 5;//播放的数度
            //设置从0 旋转360度
            doubleAnimation.From = 0;
            doubleAnimation.To = 90;
            doubleAnimation.Duration = new Duration(new TimeSpan(0, 0, 1));//播放时间长度为2秒
            Storyboard.SetTarget(doubleAnimation, this.BtnClose);//给动画指定对象
            Storyboard.SetTargetProperty(doubleAnimation,
            new PropertyPath("RenderTransform.Angle"));//给动画指定依赖的属性
            storyboard.Children.Add(doubleAnimation);//将动画添加到动画板中
            storyboard.Begin(this.BtnClose);//启动动画
        }

        public void ReRotate()
        {
            Storyboard storyboard = new Storyboard();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            RotateTransform rotate = new RotateTransform();
            this.BtnClose.RenderTransform = rotate;
            storyboard.SpeedRatio = 5;

            doubleAnimation.From = 0;
            doubleAnimation.To = -90;
            doubleAnimation.Duration = new Duration(new TimeSpan(0, 0, 1));
            Storyboard.SetTarget(doubleAnimation, this.BtnClose);
            Storyboard.SetTargetProperty(doubleAnimation,
                  new PropertyPath("RenderTransform.Angle"));
            storyboard.Children.Add(doubleAnimation);
            storyboard.Begin(this.BtnClose);
        }

        private void BtnClose_MouseEnter(object sender, MouseEventArgs e)
        {
            BtnClose.Opacity = 1;
            Rotate();
        }

        private void BtnClose_MouseLeave(object sender, MouseEventArgs e)
        {
            BtnClose.Opacity = 0.7;
            ReRotate();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            BtnClose.Opacity = 1;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            BtnClose.Opacity = 0.7;
        }

        private void Into_Click(object sender, RoutedEventArgs e)
        {
            DetailSelf ds = new DetailSelf();
            this.Close();
            ds.ShowDialog();
            
        }
    }

}
