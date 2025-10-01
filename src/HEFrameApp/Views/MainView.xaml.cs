using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HEFrameApp.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            
            //header.MouseDown += (s, e) =>
            //{
            //    if (e.LeftButton == MouseButtonState.Pressed)
            //        DragMove();
            //    if (e.ClickCount >= 2)
            //        WindowState = WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
            //};
            //btMin.Click += (s, e) =>
            //{
            //    WindowState = WindowState.Minimized;
            //};
            //btMax.Click += (s, e) =>
            //{
            //    WindowState = WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
            //    btMax.Style = WindowState == WindowState.Normal ? (Style)Application.Current.FindResource("HEMaxButtonStyle")
            //                                                    : (Style)Application.Current.FindResource("HENormalButtonStyle");                     
            //};
            //btClose.Click += (s, e) =>
            //{
            //    Close();
            //};
        }

        private void GitHubButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/he-ze-xi/HEFrame.WpfUI",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
  
            }
        }
    }
}
