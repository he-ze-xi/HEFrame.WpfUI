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
    /// <summary>
    /// 切换按钮
    /// </summary>
    public class HEToggleButton : ToggleButton, IHEUITheme
    {
        public static readonly DependencyProperty ThemeTypeProperty = DependencyProperty.Register("ThemeType", typeof(ThemeType), typeof(HEToggleButton), new PropertyMetadata(ThemeType.Dark));
        public HEToggleButton()
        {
            
        }
        /// <summary>
        /// 主题类型
        /// </summary>
        [Bindable(true)]
        public ThemeType ThemeType
        {
            get { return (ThemeType)GetValue(ThemeTypeProperty); }
            set { SetValue(ThemeTypeProperty, value); }
        }


        [Bindable(true)]
        public Brush EllipseBrush
        {
            get { return (Brush)GetValue(EllipseBrushProperty); }
            set { SetValue(EllipseBrushProperty, value); }
        }
        public static readonly DependencyProperty EllipseBrushProperty = DependencyProperty.Register("EllipseBrush", typeof(Brush), typeof(HEToggleButton));


    }
}
