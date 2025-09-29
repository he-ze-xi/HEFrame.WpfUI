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
    public class HEToolBar : ToolBar, IHEUITheme
    {
        public static readonly DependencyProperty ThemeTypeProperty = DependencyProperty.Register("ThemeType", typeof(ThemeType), typeof(HEToolBar), new FrameworkPropertyMetadata(ThemeType.Light));
        public static readonly DependencyProperty HoverColorProperty = DependencyProperty.Register("HoverColor", typeof(Color), typeof(HEToolBar));
        public HEToolBar()
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
        /// 指示鼠标在按钮上方时的背景颜色
        /// </summary>
        [Bindable(true)]
        public Color HoverColor
        {
            get { return (Color)GetValue(HoverColorProperty); }
            set { SetValue(HoverColorProperty, value); }
        }

    }
}
