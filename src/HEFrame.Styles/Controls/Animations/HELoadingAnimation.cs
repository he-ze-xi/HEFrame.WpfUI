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
    /// 加载动画
    /// </summary>
    public class HELoadingAnimation : Control, IHEUITheme
    {
        public static readonly DependencyProperty LoadingContentProperty = DependencyProperty.Register("LoadingContent", typeof(object), typeof(HELoadingAnimation), new PropertyMetadata("Loading"));
        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(HELoadingAnimation), new PropertyMetadata(false));
        public static readonly DependencyProperty AnimationRenderProperty = DependencyProperty.Register("AnimationRender", typeof(Brush), typeof(HELoadingAnimation));
        public static readonly DependencyProperty AnimationTypeProperty = DependencyProperty.Register("AnimationType", typeof(LoaddingAnimationType), typeof(HELoadingAnimation), new PropertyMetadata(LoaddingAnimationType.Default));
        public static readonly DependencyProperty ThemeTypeProperty = DependencyProperty.Register("ThemeType", typeof(ThemeType), typeof(HELoadingAnimation), new FrameworkPropertyMetadata(ThemeType.Light));
        public HELoadingAnimation()
        {

        }
        /// <summary>
        /// 动画类型
        /// </summary>
        [Bindable(true)]
        public LoaddingAnimationType AnimationType
        {
            get { return (LoaddingAnimationType)GetValue(AnimationTypeProperty); }
            set { SetValue(AnimationTypeProperty, value); }
        }
        /// <summary>
        /// 动画渲染颜色
        /// </summary>
        [Bindable(true)]
        public Brush AnimationRender
        {
            get { return (Brush)GetValue(AnimationRenderProperty); }
            set { SetValue(AnimationRenderProperty, value); }
        }
        /// <summary>
        /// 是否启用动画
        /// </summary>
        [Bindable(true)]
        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }
        /// <summary>
        /// 动画触发时要显示的内容
        /// </summary>
        [Bindable(true)]
        public object LoadingContent
        {
            get { return GetValue(LoadingContentProperty); }
            set { SetValue(LoadingContentProperty, value); }
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

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
    }
}
