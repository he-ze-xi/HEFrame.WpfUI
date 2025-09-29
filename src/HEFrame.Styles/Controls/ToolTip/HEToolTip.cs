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

namespace HEFrame.Styles.Controls
{
    public class HEToolTip : ToolTip, IHEUITheme
    {
        public static readonly DependencyProperty ThemeTypeProperty = DependencyProperty.Register("ThemeType", typeof(ThemeType), typeof(HEToolTip), new FrameworkPropertyMetadata(ThemeType.Light));
        public static readonly DependencyProperty ToolTipModeProperty = DependencyProperty.Register("ToolTipMode", typeof(HEToolTipMode), typeof(HEToolTip), new FrameworkPropertyMetadata(HEToolTipMode.Bottom));
        public HEToolTip()
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
        /// 显示方向
        /// </summary>
        [Bindable(true)]
        public HEToolTipMode ToolTipMode
        {
            get { return (HEToolTipMode)GetValue(ToolTipModeProperty); }
            set { SetValue(ToolTipModeProperty, value); }
        }

    }
}
