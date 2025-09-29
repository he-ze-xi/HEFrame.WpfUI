using HEFrame.Core.Enums;
using HEFrame.Core.Interfaces;
using HEFrame.Styles.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HEFrame.Styles.Controls
{
    [TemplatePart(Name = "PART_MainGrid", Type = typeof(Grid))]
    public class HETitleBar : Control, IHEUITheme
    {
        public static readonly DependencyProperty ThemeTypeProperty = DependencyProperty.Register("ThemeType", typeof(ThemeType), typeof(HETitleBar), new FrameworkPropertyMetadata(ThemeType.Light));
        public static readonly DependencyProperty ShowMoreBoxProperty = DependencyProperty.Register("ShowMoreBox", typeof(bool), typeof(HETitleBar), new PropertyMetadata(true));
        public static readonly DependencyProperty ShowCloseBoxProperty = DependencyProperty.Register("ShowCloseBox", typeof(bool), typeof(HETitleBar), new PropertyMetadata(true));
        public static readonly DependencyProperty ShowMaxBoxProperty = DependencyProperty.Register("ShowMaxBox", typeof(bool), typeof(HETitleBar), new PropertyMetadata(true));
        public static readonly DependencyProperty ShowMinBoxProperty = DependencyProperty.Register("ShowMinBox", typeof(bool), typeof(HETitleBar), new PropertyMetadata(true));
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(object), typeof(HETitleBar));
        public static readonly DependencyProperty MorePopupContentProperty = DependencyProperty.Register("MorePopupContent", typeof(object), typeof(HETitleBar));

        private Grid PART_MainGrid;
        public HETitleBar()
        {

        }

        /// <summary>
        /// 承载此控件的主窗口
        /// </summary>
        public Window Windows => Window.GetWindow(this); 
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
        /// 标题内容
        /// </summary>
        [Bindable(true)]
        public object Header
        {
            get { return (object)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }
        /// <summary>
        /// 是否显示最小化按钮
        /// </summary>
        [Bindable(true)]
        public bool ShowMinBox
        {
            get { return (bool)GetValue(ShowMinBoxProperty); }
            set { SetValue(ShowMinBoxProperty, value); }
        }
        /// <summary>
        /// 是否显示最大化按钮
        /// </summary>
        [Bindable(true)]
        public bool ShowMaxBox
        {
            get { return (bool)GetValue(ShowMaxBoxProperty); }
            set { SetValue(ShowMaxBoxProperty, value); }
        }
        /// <summary>
        /// 是否显示关闭按钮
        /// </summary>
        [Bindable(true)]
        public bool ShowCloseBox
        {
            get { return (bool)GetValue(ShowCloseBoxProperty); }
            set { SetValue(ShowCloseBoxProperty, value); }
        }
        /// <summary>
        /// 是否显示更多按钮
        /// </summary>
        [Bindable(true)]
        public bool ShowMoreBox
        {
            get { return (bool)GetValue(ShowMoreBoxProperty); }
            set { SetValue(ShowMoreBoxProperty, value); }
        }
        /// <summary>
        /// 更多按钮点击后要显示的内容
        /// </summary>
        [Bindable(true)]
        public object MorePopupContent
        {
            get { return (object)GetValue(MorePopupContentProperty); }
            set { SetValue(MorePopupContentProperty, value); }
        }
        


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if(GetTemplateChild("PART_MainGrid") is Grid grid)
            {
                PART_MainGrid = grid;
                PART_MainGrid.MouseDown += (s, e) =>
                {
                    if (e.LeftButton == MouseButtonState.Pressed)
                        Windows.DragMove();
                    if (e.ClickCount >= 2)
                        Windows.WindowState = Windows.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
                };
            }
            if (GetTemplateChild("PART_MinButton") is HEButton minButton)
            {
                minButton.Click += (s, e) =>
                {
                    Windows.WindowState = WindowState.Minimized;
                };
            }
            if (GetTemplateChild("PART_MaxButton") is HEButton maxButton)
            {
                maxButton.Click += (s, e) =>
                {
                    Windows.WindowState = Windows.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
                    maxButton.Style = Windows.WindowState == WindowState.Normal ? (Style)Application.Current.FindResource("HEMaxButtonStyle")
                                                                             : (Style)Application.Current.FindResource("HENormalButtonStyle");
                };
            }
            if (GetTemplateChild("PART_CloseButton") is HEButton closeButton)
            {
                closeButton.Click += (s, e) =>
                {
                    Windows.Close();
                };
            }
        }
        
    }
}
