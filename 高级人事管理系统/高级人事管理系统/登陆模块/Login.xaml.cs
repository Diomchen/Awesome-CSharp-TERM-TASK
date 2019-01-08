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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using 高级人事管理系统.考勤模块;
using 高级人事管理系统.部门模块.部门验证类;

namespace 高级人事管理系统.登陆模块
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public string username { get; set; }
        public Login()
        {
            InitializeComponent();

            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
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

        private void BtnLogin_MouseEnter(object sender, MouseEventArgs e)
        {
            var ani = new ColorAnimation(Color.FromRgb(46, 86, 87), new Duration(TimeSpan.FromSeconds(0.5)));
            BtnLogin.Background = new SolidColorBrush(Color.FromRgb(39, 141, 124));
            BtnLogin.Background.BeginAnimation(SolidColorBrush.ColorProperty, ani);
        }

        private void BtnLogin_MouseLeave(object sender, MouseEventArgs e)
        {
            var ani = new ColorAnimation(Color.FromRgb(39, 141, 124), new Duration(TimeSpan.FromSeconds(0.5)));
            BtnLogin.Background = new SolidColorBrush(Color.FromRgb(46, 86, 87));
            BtnLogin.Background.BeginAnimation(SolidColorBrush.ColorProperty, ani);
        }

        private void loginOn_click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            ComboBoxItem item = comBox.SelectedItem as ComboBoxItem;
            string username = usernameBox.Text.ToString();
            this.username = username;
            string password = passBox.Password;
            string type = item.Content.ToString();

            if (type.Equals("系统管理员"))
            {
                using (var db = new MSDSecondEntities())
                {
                    var isExsit = db.Admin.Any(u => u.a_User.Trim() == username.Trim() && u.a_Pass.Trim() == password.Trim());
                    if (isExsit)
                    {
                        this.DialogResult = Convert.ToBoolean(1);
                        this.Close();
                    }
                    else
                    {
                        usernameBox.Text = String.Empty;
                        passBox.Clear();
                        MessageBox.Show("不存在此用户");
                    }

                }
            }
            else if (type.Equals("部门经理"))
            {
                using (var db = new MSDSecondEntities())
                {
                    var isExsit = db.staff.Any(u => u.s_username.Trim() == username.Trim() && u.s_password.Trim() == password.Trim() && u.s_post.Trim() == "部门经理");
                    if (isExsit)
                    {
                        ManagerChecking mc = new ManagerChecking();
                        this.Close();
                        mc.identifyDepartment(this.username);
                    }
                    else
                    {
                        usernameBox.Text = String.Empty;
                        passBox.Clear();
                        MessageBox.Show("不存在此用户");
                    }

                }
            }
            else if (type.Equals("普通职员"))
            {
                using (var db = new MSDSecondEntities())
                {
                    var isExsit = db.staff.Any(u => u.s_username.Trim() == username.Trim() && u.s_password.Trim() == password.Trim() && u.s_post.Trim() == "普通职员");
                    if (isExsit)
                    {
                       
                        Check ck = new Check(username.Trim());
                        this.Close();
                        ck.ShowDialog();
                    }
                    else
                    {
                        usernameBox.Text = String.Empty;
                        passBox.Clear();
                        MessageBox.Show("不存在此用户");
                    }

                }
            }
        }
        //private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    //有疑问
        //    if (string.IsNullOrEmpty(this.Username) == true)
        //    {
        //        Application.Current.Shutdown();
        //    }
        //}
    }
}
