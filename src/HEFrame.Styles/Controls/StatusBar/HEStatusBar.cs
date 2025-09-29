using HEFrame.Core.Enums;
using HEFrame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace HEFrame.Styles.Controls
{
    public class HEStatusBar : StatusBar, IHEUITheme
    {
        public static readonly DependencyProperty ThemeTypeProperty = DependencyProperty.Register("ThemeType", typeof(ThemeType), typeof(HEStatusBar), new FrameworkPropertyMetadata(ThemeType.Light));
        public static readonly DependencyProperty SeparatorColorProperty = DependencyProperty.Register("SeparatorColor", typeof(Brush), typeof(HEStatusBar));
        public HEStatusBar()
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
        /// 分割线颜色
        /// </summary>
        [Bindable(true)]
        public Brush SeparatorColor
        {
            get { return (Brush)GetValue(SeparatorColorProperty); }
            set { SetValue(SeparatorColorProperty, value); }
        }
    }
}
