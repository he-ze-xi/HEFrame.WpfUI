using HEFrame.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace HEFrame.Styles.Controls
{
    /// <summary>
    /// 消息卡片
    /// </summary>
    [TemplatePart(Name = "PART_CloseButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_Transition", Type = typeof(HETransitionAnimation))]
    public class HEMessageCard : Control
    {
        public static readonly DependencyProperty MessageContentProperty = DependencyProperty.Register("MessageContent", typeof(string), typeof(HEMessageCard));
        public static readonly DependencyProperty MessageDescriptionProperty = DependencyProperty.Register("MessageDescription", typeof(string), typeof(HEMessageCard));
        public static readonly DependencyProperty AutoCloseDelayTimeProperty = DependencyProperty.Register("AutoCloseDelayTime", typeof(double), typeof(HEMessageCard), new PropertyMetadata(3.0));
        public static readonly DependencyProperty CustomContentProperty = DependencyProperty.Register("CustomContent", typeof(object), typeof(HEMessageCard));
        public static readonly DependencyProperty IsAutoCloseProperty = DependencyProperty.Register("IsAutoClose", typeof(bool), typeof(HEMessageCard), new PropertyMetadata(true));
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(HEMessageCard), new PropertyMetadata(new CornerRadius(5)));
        public static readonly DependencyProperty MessageTypeProperty = DependencyProperty.Register("MessageType", typeof(MessageType), typeof(HEMessageCard), new PropertyMetadata(MessageType.DefaultDark));

        public HEMessageCard()
        {
            Loaded += HEMessageCard_Loaded;
        }
        public HEMessageCard(MessageType messageType, string messageContent, string messageDescription, bool isAutoClose, double autoCloseDelayTime):this()
        {
            MessageType = messageType;
            MessageContent = messageContent;
            MessageDescription = messageDescription;
            IsAutoClose = isAutoClose;
            AutoCloseDelayTime = autoCloseDelayTime;
        }

        //自动关闭消息卡片
        private async void HEMessageCard_Loaded(object sender, RoutedEventArgs e)
        {
            if(Parent is ItemsControl parent && parent.Items.Contains(this) && IsAutoClose)
            {
                await Task.Delay(TimeSpan.FromSeconds(AutoCloseDelayTime));
                parent.Items.Remove(this);
            }
        }

        /// <summary>
        /// 消息类型
        /// </summary>
        [Bindable(true)]
        public MessageType MessageType
        {
            get { return (MessageType)GetValue(MessageTypeProperty); }
            set { SetValue(MessageTypeProperty, value); }
        }
        /// <summary>
        /// 消息内容
        /// </summary>
        [Bindable(true)]
        public string MessageContent
        {
            get { return (string)GetValue(MessageContentProperty); }
            set { SetValue(MessageContentProperty, value); }
        }
        /// <summary>
        /// 消息描述
        /// </summary>
        [Bindable(true)]
        public string MessageDescription
        {
            get { return (string)GetValue(MessageDescriptionProperty); }
            set { SetValue(MessageDescriptionProperty, value); }
        }
        /// <summary>
        /// 指示是否自动关闭消息卡片
        /// </summary>
        [Bindable(true)]
        public bool IsAutoClose
        {
            get { return (bool)GetValue(IsAutoCloseProperty); }
            set { SetValue(IsAutoCloseProperty, value); }
        }
        /// <summary>
        /// 自动关闭消息卡片延时
        /// 单位：秒
        /// </summary>
        [Bindable(true)]
        public double AutoCloseDelayTime
        {
            get { return (double)GetValue(AutoCloseDelayTimeProperty); }
            set { SetValue(AutoCloseDelayTimeProperty, value); }
        }
        /// <summary>
        /// 自定义消息卡片内容
        /// </summary>
        [Bindable(true)]
        public object CustomContent
        {
            get { return (object)GetValue(CustomContentProperty); }
            set { SetValue(CustomContentProperty, value); }
        }
        /// <summary>
        /// 指示消息卡片的圆角宽度
        /// </summary>
        [Bindable(true)]
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("PART_CloseButton") is Button button)
            {
                button.Click += Button_Click;
            }
            if(GetTemplateChild("PART_Transition") is HETransitionAnimation animation)
            {
                if (Parent is ItemsControl parent && parent.Items.Contains(this) && parent.TemplatedParent is HEMessageCardHost host)
                {
                    switch (host.ShowDirection)
                    {
                        case MessageShowDirectionType.FromTop:
                            animation.TransitionType = TransitionAnimationType.SlideFromTop;
                            break;
                        case MessageShowDirectionType.FromBottom:
                            animation.TransitionType = TransitionAnimationType.SlideFromBottom;
                            break;
                        default:
                            animation.TransitionType = TransitionAnimationType.SlideFromTop;
                            break;
                    }
                }
            }
        }
        //关闭当前消息卡片
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Parent is ItemsControl parent && parent.Items.Contains(this))
            {
                parent.Items.Remove(this);
            }
        }
    }
}
