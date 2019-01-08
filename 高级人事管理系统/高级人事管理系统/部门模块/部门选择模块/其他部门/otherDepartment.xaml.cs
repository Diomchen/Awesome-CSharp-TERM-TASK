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
using 高级人事管理系统.部门模块.部门选择模块.其他部门.数据绑定类;

namespace 高级人事管理系统.部门模块.部门选择模块.其他部门
{
    /// <summary>
    /// otherDepartment.xaml 的交互逻辑
    /// </summary>
    public partial class otherDepartment : Window
    {
        private Shechi sc;
        public static string cont = "";
        public otherDepartment(string str)
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            Title.Content = str;
            sc = new Shechi();
            sc.TSTR = str;
            frame.DataContext = sc;
            cont = Title.Content.ToString();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        public void Rotate()
        {
            Storyboard storyboard = new Storyboard();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            RotateTransform rotate = new RotateTransform();
            this.BtnClose.RenderTransform = rotate;
            storyboard.SpeedRatio = 5;
            
            doubleAnimation.From = 0;
            doubleAnimation.To = 90;
            doubleAnimation.Duration = new Duration(new TimeSpan(0, 0, 1));
            Storyboard.SetTarget(doubleAnimation, this.BtnClose);
            Storyboard.SetTargetProperty(doubleAnimation,
            new PropertyPath("RenderTransform.Angle"));
            storyboard.Children.Add(doubleAnimation);
            storyboard.Begin(this.BtnClose);
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
        private void BtnSelect_MouseEnter(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            var ani = new ColorAnimation(Color.FromRgb(46, 86, 87), new Duration(TimeSpan.FromSeconds(0.5)));
            btn.Background = new SolidColorBrush(Color.FromRgb(39, 141, 124));
            btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, ani);
        }

        private void BtnSelect_MouseLeave(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            var ani = new ColorAnimation(Color.FromRgb(39, 141, 124), new Duration(TimeSpan.FromSeconds(0.5)));
            btn.Background = new SolidColorBrush(Color.FromRgb(46, 86, 87));
            btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, ani);
        }
        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string path = string.Format("/部门模块/部门选择模块/其他部门/其他部门功能页/{0}.xaml", btn.DataContext);
            
            Uri source = new Uri(path, UriKind.Relative);
            object obj = null;
            obj = Application.LoadComponent(source);

            Page p = obj as Page;
            if (p != null)
            {
                frame.NavigationService.RemoveBackEntry();
                frame.Source = source;
                return;
            }
        }
    }
   
}
