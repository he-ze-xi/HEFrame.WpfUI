using HEFrame.Core.Enums;
using HEFrame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HEFrame.Styles.Controls
{
    /// <summary>
    /// 折叠板
    /// </summary>
    public class HEExpander : Expander, IHEUITheme
    {
        public static readonly DependencyProperty ThemeTypeProperty = DependencyProperty.Register("ThemeType", typeof(ThemeType), typeof(HEExpander), new FrameworkPropertyMetadata(ThemeType.Light));
        public static readonly DependencyProperty SplitLineColorProperty = DependencyProperty.Register("SplitLineColor", typeof(Color), typeof(HEExpander));
        public HEExpander()
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
        public Color SplitLineColor
        {
            get { return (Color)GetValue(SplitLineColorProperty); }
            set { SetValue(SplitLineColorProperty, value); }
        }

    }
}
