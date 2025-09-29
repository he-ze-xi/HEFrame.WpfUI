using HEFrame.Core.Enums;
using HEFrame.Core.Interfaces;
using System;
using System.Collections;
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
    /// 按钮
    /// </summary>
    public class HEButton : Button ,IHEUITheme
    {
        public static readonly DependencyProperty IsLoadingProperty = DependencyProperty.Register("IsLoading", typeof(bool), typeof(HEButton), new PropertyMetadata(false));
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(HEButton), new PropertyMetadata(new CornerRadius(3)));
        public static readonly DependencyProperty ButtonTypeProperty = DependencyProperty.Register("ButtonType", typeof(ButtonType), typeof(HEButton), new PropertyMetadata(ButtonType.Primary));
        public static readonly DependencyProperty LoadingContentProperty = DependencyProperty.Register("LoadingContent", typeof(object), typeof(HEButton));
        public static readonly DependencyProperty PressedBackgroundProperty = DependencyProperty.Register("PressedBackground", typeof(Brush), typeof(HEButton));
        public static readonly DependencyProperty HoverBackgroundProperty = DependencyProperty.Register("HoverBackground", typeof(Brush), typeof(HEButton));        
        public static readonly DependencyProperty ThemeTypeProperty = DependencyProperty.Register("ThemeType", typeof(ThemeType), typeof(HEButton), new FrameworkPropertyMetadata(ThemeType.Light));
        public HEButton()
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
        /// 指示按钮类型
        /// </summary>
        [Bindable(true)]
        public ButtonType ButtonType
        {
            get { return (ButtonType)GetValue(ButtonTypeProperty); }
            set { SetValue(ButtonTypeProperty, value); }
        }
        /// <summary>
        /// 指示按钮圆角半径
        /// </summary>
        [Bindable(true)]
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        /// <summary>
        /// 指示按钮是否为加载状态
        /// </summary>
        [Bindable(true)]
        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }
        /// <summary>
        /// 指示加载状态时要显示的内容
        /// </summary>
        [Bindable(true)]
        public object LoadingContent
        {
            get { return GetValue(LoadingContentProperty); }
            set { SetValue(LoadingContentProperty, value); }
        }
        /// <summary>
        /// 指示鼠标在按钮上方时的背景颜色
        /// </summary>
        [Bindable(true)]
        public Brush HoverBackground
        {
            get { return (Brush)GetValue(HoverBackgroundProperty); }
            set { SetValue(HoverBackgroundProperty, value); }
        }
        /// <summary>
        /// 指示按钮按下时的背景颜色
        /// </summary>
        [Bindable(true)]
        public Brush PressedBackground
        {
            get { return (Brush)GetValue(PressedBackgroundProperty); }
            set { SetValue(PressedBackgroundProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
    }
}
