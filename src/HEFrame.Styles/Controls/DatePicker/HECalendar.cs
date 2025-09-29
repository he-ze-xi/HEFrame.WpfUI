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
    /// 日历
    /// </summary>
    public class HECalendar : Calendar, IHEUITheme
    {
        public static readonly DependencyProperty ThemeTypeProperty = DependencyProperty.Register("ThemeType", typeof(ThemeType), typeof(HECalendar), new FrameworkPropertyMetadata(ThemeType.Light));
        public static readonly DependencyProperty TurnPageButtonMouseOverColorProperty = DependencyProperty.Register("TurnPageButtonMouseOverColor", typeof(Color), typeof(HECalendar));
        public HECalendar()
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
        /// 翻页按钮MouseOver颜色
        /// </summary>
        [Bindable(true)]
        public Color TurnPageButtonMouseOverColor
        {
            get { return (Color)GetValue(TurnPageButtonMouseOverColorProperty); }
            set { SetValue(TurnPageButtonMouseOverColorProperty, value); }
        }

    }
}
