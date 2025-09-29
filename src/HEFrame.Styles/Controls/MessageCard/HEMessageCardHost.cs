using HEFrame.Core.Enums;
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
    /// <summary>
    /// 消息卡片容器
    /// </summary>
    [TemplatePart(Name = "PART_ContainerItemsControl", Type = typeof(ItemsControl))]
    public class HEMessageCardHost : Control
    {
        public static readonly DependencyProperty ShowDirectionProperty =
            DependencyProperty.Register("ShowDirection", typeof(MessageShowDirectionType), typeof(HEMessageCardHost), new PropertyMetadata(MessageShowDirectionType.FromTop, OnShowDirectionChanged));
        public static readonly DependencyProperty MessageContainerProperty =
             DependencyProperty.Register("MessageContainer", typeof(ItemsControl), typeof(HEMessageCardHost));

        /// <summary>
        /// 消息容器
        /// </summary>
        public ItemsControl MessageContainer
        {
            get { return (ItemsControl)GetValue(MessageContainerProperty); }
            set { SetValue(MessageContainerProperty, value); }
        }
        /// <summary>
        /// 消息弹出方向
        /// </summary>
        [Bindable(true)]
        public MessageShowDirectionType ShowDirection
        {
            get { return (MessageShowDirectionType)GetValue(ShowDirectionProperty); }
            set { SetValue(ShowDirectionProperty, value); }
        }
        private static void OnShowDirectionChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            if (!(dp is HEMessageCardHost host) || !host.IsLoaded) return;
            switch (host.ShowDirection)
            {
                case MessageShowDirectionType.FromTop:
                    host.VerticalAlignment = VerticalAlignment.Top;
                    break;
                case MessageShowDirectionType.FromBottom:
                    host.VerticalAlignment = VerticalAlignment.Bottom;
                    break;
                default:
                    host.VerticalAlignment = VerticalAlignment.Top;
                    break;
            }
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if(GetTemplateChild("PART_ContainerItemsControl") is ItemsControl itemsControl)
            {
                if (itemsControl == null) return;
                MessageContainer = itemsControl;
            }
            switch (ShowDirection)
            {
                case MessageShowDirectionType.FromTop:
                    VerticalAlignment = VerticalAlignment.Top;
                    break;
                case MessageShowDirectionType.FromBottom:
                    VerticalAlignment = VerticalAlignment.Bottom;
                    break;
                default:
                    VerticalAlignment = VerticalAlignment.Top;
                    break;
            }
        }
    }
}
