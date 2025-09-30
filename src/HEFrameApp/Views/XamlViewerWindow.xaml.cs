using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Controls;
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
            // 设置焦点到关闭按钮，避免编辑器获得焦点
            BtnClose.Focus();
        }

        /// <summary>
        /// 打开并显示控件对应的 XAML。优先读取磁盘样例文件（relativePath 相对于可执行文件目录），否则回退到序列化 element。
        /// </summary>
        public static void ShowXamlForControl(System.Windows.FrameworkElement element, string sampleFileRelativePath = null, Window owner = null)
        {
            string xaml = TryLoadSampleFile(sampleFileRelativePath) ?? TrySerialize(element) ?? "<!-- 无法获取 XAML -->";
            var win = new XamlViewerWindow();
            if (owner != null)
            {
                win.Owner = owner;
                win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }

            // 格式化并设置到 AvalonEdit 编辑器
            win.Editor.Text = FormatXaml(xaml);
            // 明确设置语法高亮为 XML（XAML）
            win.Editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("XML");
            win.Editor.IsReadOnly = true;
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

        private static string TrySerialize(System.Windows.FrameworkElement element)
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

        private void BtnCopy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Clipboard.SetText(Editor.Text);
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