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

namespace HEFrame.Styles.Controls
{
    /// <summary>
    /// 滚动条
    /// </summary>
    public class HEScrollBar : ScrollBar, IHEUITheme
    {
        public static readonly DependencyProperty ThemeTypeProperty = DependencyProperty.Register("ThemeType", typeof(ThemeType), typeof(HEScrollBar), new FrameworkPropertyMetadata(ThemeType.Light));
        public HEScrollBar()
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
    }
}
