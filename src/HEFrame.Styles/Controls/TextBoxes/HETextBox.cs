using HEFrame.Core.Enums;
using HEFrame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HEFrame.Styles.Controls
{
    [TemplatePart(Name = "PART_CloseButton", Type = typeof(Button))]
    public class HETextBox : TextBox, IHEUITheme
    {
        public static readonly DependencyProperty ThemeTypeProperty = DependencyProperty.Register("ThemeType", typeof(ThemeType), typeof(HETextBox), new FrameworkPropertyMetadata(ThemeType.Light));
        public static readonly DependencyProperty RegexStringProperty = DependencyProperty.Register("RegexString", typeof(string), typeof(HETextBox), new FrameworkPropertyMetadata("", new PropertyChangedCallback(RegexStringChanged)));
        public static readonly DependencyProperty WaterMarkProperty = DependencyProperty.Register("WaterMark", typeof(string), typeof(HETextBox), new PropertyMetadata("默认水印文字"));
        public static readonly DependencyProperty UseRegexProperty = DependencyProperty.Register("UseRegex", typeof(bool), typeof(HETextBox), new PropertyMetadata(false));
        public HETextBox()
        {
            
        }
        /// <summary>
        /// 主题类型
        /// </summary>
        [Bindable(true)]
        public ThemeType ThemeType
        {
            get => (ThemeType)GetValue(ThemeTypeProperty);
            set => SetValue(ThemeTypeProperty, value);
        }
        /// <summary>
        /// 水印
        /// </summary>
        [Bindable(true)]
        public string WaterMark
        {
            get { return (string)GetValue(WaterMarkProperty); }
            set { SetValue(WaterMarkProperty, value); }
        }
        /// <summary>
        /// 指示是否使用正则匹配
        /// </summary>
        [Bindable(true)]
        public virtual bool UseRegex
        {
            get { return (bool)GetValue(UseRegexProperty); }
            set { SetValue(UseRegexProperty, value); }
        }
        /// <summary>
        /// 正则匹配
        /// </summary>
        [Bindable(true)]
        public virtual string RegexString
        {
            get { return (string)GetValue(RegexStringProperty); }
            set { SetValue(RegexStringProperty, value); }
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (UseRegex)
            {
                if (e.Key == Key.Space) e.Handled = true;
            } 
            base.OnPreviewKeyDown(e);
        }
        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            if (!UseRegex) return;
            if (string.IsNullOrWhiteSpace(RegexString))
            {
                return;
            }
            //使用正则匹配时禁用输入法 （匹配中文除外）
            if (!RegexString.Equals(@"[\u4e00-\u9fa5]") && !RegexString.Equals(@"[^\x00-\xff]"))
            {
                InputMethod.SetIsInputMethodEnabled(this, false);
            }
            e.Handled = !new Regex(RegexString).IsMatch(e.Text);
        }
        private static void RegexStringChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            if (!(dp is HETextBox textBox)) return;
            if (string.IsNullOrWhiteSpace(textBox.RegexString))
            {
                return;
            }
            //使用正则匹配时禁用输入法 （匹配中文除外）
            if (!textBox.RegexString.Equals(@"[\u4e00-\u9fa5]") && !textBox.RegexString.Equals(@"[^\x00-\xff]"))
            {
                InputMethod.SetIsInputMethodEnabled(textBox, false);
            }
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if(GetTemplateChild("PART_CloseButton") is Button button)
            {
                button.Click += Button_Click;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Text.Length > 0)
                Text = string.Empty;
        }
    }
}
