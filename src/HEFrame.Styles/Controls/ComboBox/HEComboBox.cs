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
    public class HEComboBox : ComboBox, IHEUITheme
    {
        public static readonly DependencyProperty ThemeTypeProperty = DependencyProperty.Register("ThemeType", typeof(ThemeType), typeof(HEComboBox), new FrameworkPropertyMetadata(ThemeType.Light));
        public static readonly DependencyProperty MouseOverItemBackgroundProperty = DependencyProperty.Register("MouseOverItemBackground", typeof(Brush), typeof(HEComboBox));
        public static readonly DependencyProperty ArrowBrushProperty = DependencyProperty.Register("ArrowBrush", typeof(Brush), typeof(HEComboBox));
        public HEComboBox()
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
        /// 鼠标移动到项上方的背景颜色
        /// </summary>
        [Bindable(true)]
        public Brush MouseOverItemBackground
        {
            get { return (Brush)GetValue(MouseOverItemBackgroundProperty); }
            set { SetValue(MouseOverItemBackgroundProperty, value); }
        }
        /// <summary>
        /// 箭头颜色渲染
        /// </summary>
        [Bindable(true)]
        public Brush ArrowBrush
        {
            get { return (Brush)GetValue(ArrowBrushProperty); }
            set { SetValue(ArrowBrushProperty, value); }
        }
        
    }
}
