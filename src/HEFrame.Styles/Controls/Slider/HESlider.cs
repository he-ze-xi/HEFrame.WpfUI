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
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace HEFrame.Styles.Controls
{
    public class HESlider : Slider, IHEUITheme
    {
        public static readonly DependencyProperty ThemeTypeProperty = DependencyProperty.Register("ThemeType", typeof(ThemeType), typeof(HESlider), new FrameworkPropertyMetadata(ThemeType.Light));
        public static readonly DependencyProperty ThumbBrushProperty = DependencyProperty.Register("ThumbBrush", typeof(Brush), typeof(HESlider));
        public static readonly DependencyProperty RepeatButtonBorderCornerRadiusProperty = DependencyProperty.Register("RepeatButtonBorderCornerRadius", typeof(CornerRadius), typeof(HESlider));
        public HESlider()
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
        /// 滑块颜色
        /// </summary>
        [Bindable(true)]
        public Brush ThumbBrush
        {
            get { return (Brush)GetValue(ThumbBrushProperty); }
            set { SetValue(ThumbBrushProperty, value); }
        }

        /// <summary>
        /// RepeatButton背景圆角
        /// </summary>
        [Bindable(true)]
        public CornerRadius RepeatButtonBorderCornerRadius
        {
            get { return (CornerRadius)GetValue(RepeatButtonBorderCornerRadiusProperty); }
            set { SetValue(RepeatButtonBorderCornerRadiusProperty, value); }
        }

        


    }
}
