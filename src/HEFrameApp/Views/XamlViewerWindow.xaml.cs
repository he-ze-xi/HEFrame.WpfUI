using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Markup;
using System.Xml;
using ICSharpCode.AvalonEdit.Highlighting;

namespace HEFrameApp.Views
{
    public partial class XamlViewerWindow : Window
    {
        public XamlViewerWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            BtnClose.Focus();
        }

        /// <summary>
        /// 显示 XAML、Code-behind 和 ViewModel。优先使用传入路径，否则尝试序列化 element 并从磁盘搜索 ViewModel。
        /// </summary>
        public static void ShowXamlAndCode(System.Windows.FrameworkElement element,
                                          string xamlSamplePath = null,
                                          string codeBehindSamplePath = null,
                                          string viewModelSamplePath = null,
                                          Window owner = null)
        {
            var win = new XamlViewerWindow();
            if (owner != null)
            {
                win.Owner = owner;
                win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }

            string xaml = TryLoadSampleFile(xamlSamplePath);
            win.EditorXaml.Text = FormatXaml(xaml);
            win.EditorXaml.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("XML");

            string code = TryLoadSampleFile(codeBehindSamplePath);
            win.EditorCode.Text = code;
            win.EditorCode.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("C#");

            string vm = TryLoadSampleFile(viewModelSamplePath);
            win.EditorViewModel.Text = vm;
            win.EditorViewModel.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("C#");

            win.ShowDialog();
        }

        private static string TryLoadSampleFile(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath)) return null;
            try
            {
                var baseDir = AppDomain.CurrentDomain.BaseDirectory;
                var full = Path.IsPathRooted(relativePath) ? relativePath : Path.Combine(baseDir, relativePath);
                if (!File.Exists(full)) return null;
                return File.ReadAllText(full, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                return $"/* 读取文件失败: {ex.Message} */";
            }
        }


        private static string FormatXaml(string xaml)
        {
            if (string.IsNullOrEmpty(xaml)) return xaml;
            return xaml.Replace("><", ">\r\n<")
                       .Replace(" xmlns:", "\r\n    xmlns:")
                       .Replace(" />", "/>");
        }


        private void BtnCopy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = null;
                var selected = System.Windows.Controls.Primitives.Selector.SelectedValueProperty;
                var tab = System.Windows.Controls.TabControl.ItemsControlFromItemContainer(System.Windows.Controls.TabControl.ItemsControlFromItemContainer(this)) as System.Windows.Controls.TabControl;
                if (EditorXaml.IsVisible && EditorXaml.IsFocused == false && EditorXaml.Text.Length > 0 && EditorXaml.Visibility == Visibility.Visible && EditorXaml.Parent is FrameworkElement)
                {
                }
                if (EditorXaml.Visibility == Visibility.Visible) text = EditorXaml.Text;
                if (EditorCode.Visibility == Visibility.Visible) text = EditorCode.Text;
                if (EditorViewModel.Visibility == Visibility.Visible) text = EditorViewModel.Text;

                if (string.IsNullOrEmpty(text)) text = EditorXaml.Text; 
                Clipboard.SetText(text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"复制到剪贴板失败: {ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}