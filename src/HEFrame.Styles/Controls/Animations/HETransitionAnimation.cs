using HEFrame.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace HEFrame.Styles.Controls
{
    /// <summary>
    /// 过渡动画容器
    /// </summary>
    public class HETransitionAnimation : ContentControl
    {
        private Grid _animationContainer; //动画容器

        public static readonly DependencyProperty TransitionTypeProperty =
            DependencyProperty.Register("TransitionType", typeof(TransitionAnimationType), typeof(HETransitionAnimation), new PropertyMetadata(TransitionAnimationType.Default, OnAnimationChanged));
        public static readonly DependencyProperty BeginTimeProperty =
            DependencyProperty.Register("BeginTime", typeof(double), typeof(HETransitionAnimation), new PropertyMetadata(0.0, OnAnimationChanged));
        public static readonly DependencyProperty IsStartAnimationProperty =
            DependencyProperty.Register("IsStartAnimation", typeof(bool), typeof(HETransitionAnimation), new PropertyMetadata(false, OnAnimationChanged));
        

        public HETransitionAnimation()
        {
            ClipToBounds = true;
        }
        /// <summary>
        /// 指示是否启动动画
        /// </summary>
        [Bindable(true)]
        public bool IsStartAnimation
        {
            get { return (bool)GetValue(IsStartAnimationProperty); }
            set { SetValue(IsStartAnimationProperty, value); }
        }
        /// <summary>
        /// 动画开始延迟时间
        /// 单位：秒
        /// </summary>
        [Bindable(true)]
        public double BeginTime
        {
            get { return (double)GetValue(BeginTimeProperty); }
            set { SetValue(BeginTimeProperty, value); }
        }
        /// <summary>
        /// 过渡动画类型
        /// </summary>
        [Bindable(true)]
        public TransitionAnimationType TransitionType
        {
            get { return (TransitionAnimationType)GetValue(TransitionTypeProperty); }
            set { SetValue(TransitionTypeProperty, value); }
        }
        //刷新动画容器
        private void RefreshAnimationContainer()
        {
            if (!IsStartAnimation && _animationContainer != null)
            {
                var storyDefault = new Storyboard()
                {
                    BeginTime = TimeSpan.FromSeconds(BeginTime)
                };
                storyDefault.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}ScaleXAnimation"] as DoubleAnimation);
                storyDefault.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}ScaleYAnimation"] as DoubleAnimation);
                storyDefault.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}OpacityAnimation"] as DoubleAnimation);
                storyDefault.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}SlideXAnimation"] as DoubleAnimation);
                storyDefault.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}SlideYAnimation"] as DoubleAnimation);
                storyDefault.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}OriginAnimation"] as PointAnimation);
                _animationContainer.BeginStoryboard(storyDefault);
                return;
            };
            var type = TransitionType.ToString();
            var story = new Storyboard() { BeginTime = TimeSpan.FromSeconds(BeginTime) };
            switch (TransitionType)
            {
                case TransitionAnimationType.Default:
                    story.Children.Add(Template.Resources[$"{type}ScaleXAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{type}ScaleYAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{type}OpacityAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{type}SlideXAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{type}SlideYAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{type}OriginAnimation"] as PointAnimation);
                    story.Children.Add(Template.Resources[$"{type}RatoteAnimation"] as DoubleAnimation);
                    break;
                case TransitionAnimationType.ZoomIn:
                    story.Children.Add(Template.Resources[$"{type}ScaleXAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{type}ScaleYAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"GradientInOpacityAnimation"] as DoubleAnimation);

                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}SlideXAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}SlideYAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}OriginAnimation"] as PointAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}RatoteAnimation"] as DoubleAnimation);
                    break;
                case TransitionAnimationType.ZoomOut:
                    story.Children.Add(Template.Resources[$"{type}ScaleXAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{type}ScaleYAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"GradientOutOpacityAnimation"] as DoubleAnimation);

                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}SlideXAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}SlideYAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}OriginAnimation"] as PointAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}RatoteAnimation"] as DoubleAnimation);
                    break;
                case TransitionAnimationType.GradientIn:
                case TransitionAnimationType.GradientOut:
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}ScaleXAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}ScaleYAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{type}OpacityAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}SlideXAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}SlideYAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}OriginAnimation"] as PointAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}RatoteAnimation"] as DoubleAnimation);
                    break;
                case TransitionAnimationType.SlideFromLeft:
                case TransitionAnimationType.SlideToLeft:
                case TransitionAnimationType.SlideFromRight:
                case TransitionAnimationType.SlideToRight:
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}ScaleXAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}ScaleYAnimation"] as DoubleAnimation);

                    var gradient = type.Contains("From") ? "GradientInOpacityAnimation" : "GradientOutOpacityAnimation";
                    story.Children.Add(Template.Resources[$"{gradient}"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{type}Animation"] as DoubleAnimationUsingKeyFrames);

                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}SlideYAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}OriginAnimation"] as PointAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}RatoteAnimation"] as DoubleAnimation);
                    break;
                case TransitionAnimationType.SlideFromTop:
                case TransitionAnimationType.SlideToTop:
                case TransitionAnimationType.SlideFromBottom:
                case TransitionAnimationType.SlideToBottom:
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}ScaleXAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}ScaleYAnimation"] as DoubleAnimation);

                    var gradient1 = type.Contains("From") ? "GradientInOpacityAnimation" : "GradientOutOpacityAnimation";
                    story.Children.Add(Template.Resources[$"{gradient1}"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{type}Animation"] as DoubleAnimationUsingKeyFrames);

                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}SlideXAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}OriginAnimation"] as PointAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}RatoteAnimation"] as DoubleAnimation);
                    break;
                case TransitionAnimationType.RotateIn:
                case TransitionAnimationType.RotateOut:
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}ScaleXAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}ScaleYAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}SlideXAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}SlideYAnimation"] as DoubleAnimation);

                    var gradient2 = type.Contains("In") ? "GradientInOpacityAnimation" : "GradientOutOpacityAnimation";
                    var rotate = type.Contains("In") ? "RotateInAnimation" : "RotateOutAnimation";
                    story.Children.Add(Template.Resources[$"{gradient2}"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"CornerOriginAnimation"] as PointAnimation);
                    story.Children.Add(Template.Resources[$"{rotate}"] as DoubleAnimationUsingKeyFrames);
                    break;
                default:
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}ScaleXAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}ScaleYAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}OpacityAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}SlideXAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}SlideYAnimation"] as DoubleAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}OriginAnimation"] as PointAnimation);
                    story.Children.Add(Template.Resources[$"{nameof(TransitionAnimationType.Default)}RatoteAnimation"] as DoubleAnimation);
                    break;
            }
            _animationContainer.BeginStoryboard(story);
        }
        //动画类型更新回调
        private static void OnAnimationChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            if (!(dp is HETransitionAnimation animation) || !animation.IsLoaded) return;
            animation.RefreshAnimationContainer();
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("PART_AnimationContainer") is Grid grid)
            {
                _animationContainer = grid;
                RefreshAnimationContainer();
            }
        }
    }
}
