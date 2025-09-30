using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Xml;

namespace HEFrameApp.Views
{
    public partial class XamlViewerWindow : Window
    {
        public XamlViewerWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;

            // 设置窗口图标（如果存在）
            try
            {
                // 尝试设置图标，如果资源不存在会跳过
                // this.Icon = ... 已经在XAML中设置
            }
            catch
            {
                // 忽略图标加载错误
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            // 设置焦点到关闭按钮，避免文本框获得焦点
            BtnClose.Focus();
        }

        /// <summary>
        /// 打开并显示控件对应的 XAML。优先读取磁盘样例文件（relativePath 相对于可执行文件目录），否则回退到序列化 element。
        /// </summary>
        public static void ShowXamlForControl(FrameworkElement element, string sampleFileRelativePath = null, Window owner = null)
        {
            string xaml = TryLoadSampleFile(sampleFileRelativePath) ?? TrySerialize(element) ?? "<!-- 无法获取 XAML -->";
            var win = new XamlViewerWindow();
            if (owner != null)
            {
                win.Owner = owner;
                win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }

            win.TxtXaml.Text = FormatXaml(xaml);
            win.ShowDialog();
        }

        private static string TryLoadSampleFile(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath)) return null;
            try
            {
                var baseDir = AppDomain.CurrentDomain.BaseDirectory;
                var full = Path.Combine(baseDir, relativePath);
                if (!File.Exists(full)) return null;
                return File.ReadAllText(full, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                return $"<!-- 读取文件失败: {ex.Message} -->";
            }
        }

        private static string TrySerialize(FrameworkElement element)
        {
            if (element == null) return null;
            try
            {
                var settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "    ",
                    NewLineChars = "\r\n",
                    NewLineHandling = NewLineHandling.Replace
                };

                var sb = new StringBuilder();
                using (var writer = XmlWriter.Create(sb, settings))
                {
                    XamlWriter.Save(element, writer);
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                return $"<!-- 序列化失败: {ex.Message} -->";
            }
        }

        private static string FormatXaml(string xaml)
        {
            if (string.IsNullOrEmpty(xaml)) return xaml;

            // 简单的格式化：确保适当的换行
            return xaml.Replace("><", ">\r\n<")
                      .Replace(" xmlns:", "\r\n    xmlns:")
                      .Replace(" />", "/>");
        }

        private static string GetXamlLengthInfo(string xaml)
        {
            if (string.IsNullOrEmpty(xaml)) return "0 字符";

            var lines = xaml.Split('\n').Length;
            var chars = xaml.Length;
            return $"{lines} 行, {chars} 字符";
        }

        private void BtnCopy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Clipboard.SetText(TxtXaml.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"复制到剪贴板失败: {ex.Message}",
                              "错误",
                              MessageBoxButton.OK,
                              MessageBoxImage.Error);
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}