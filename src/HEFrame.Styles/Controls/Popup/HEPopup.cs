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
    [TemplatePart(Name = "PART_PopupControl", Type = typeof(ToggleButton))]
    [TemplatePart(Name = "PART_Popup", Type = typeof(Popup))]
    public class HEPopup : ContentControl, IHEUITheme
    {
        public static readonly DependencyProperty ThemeTypeProperty = DependencyProperty.Register("ThemeType", typeof(ThemeType), typeof(HEPopup), new FrameworkPropertyMetadata(ThemeType.Light));
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(HEPopup));
        public static readonly DependencyProperty MouseOverColorProperty = DependencyProperty.Register("MouseOverColor", typeof(Color), typeof(HEPopup));
        public static readonly DependencyProperty VerticalOffsetProperty = DependencyProperty.Register("VerticalOffset", typeof(double), typeof(HEPopup));
        public static readonly DependencyProperty HorizontalOffsetProperty = DependencyProperty.Register("HorizontalOffset", typeof(double), typeof(HEPopup));
        public static readonly DependencyProperty PlacementProperty = DependencyProperty.Register("Placement", typeof(PlacementMode), typeof(HEPopup));
        private ToggleButton PART_PopupControl;
        private Popup PART_Popup;
        public HEPopup()
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
        /// 圆角
        /// </summary>
        [Bindable(true)]
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        /// <summary>
        /// 鼠标上移颜色
        /// </summary>
        [Bindable(true)]
        public Color MouseOverColor
        {
            get { return (Color)GetValue(MouseOverColorProperty); }
            set { SetValue(MouseOverColorProperty, value); }
        }

        /// <summary>
        /// Popup放置位置
        /// </summary>
        [Bindable(true)]
        public PlacementMode Placement
        {
            get { return (PlacementMode)GetValue(PlacementProperty); }
            set { SetValue(PlacementProperty, value); }
        }
        /// <summary>
        /// 水平偏移
        /// </summary>
        [Bindable(true)]
        public double HorizontalOffset
        {
            get { return (double)GetValue(HorizontalOffsetProperty); }
            set { SetValue(HorizontalOffsetProperty, value); }
        }
        /// <summary>
        /// 垂直偏移
        /// </summary>
        [Bindable(true)]
        public double VerticalOffset
        {
            get { return (double)GetValue(VerticalOffsetProperty); }
            set { SetValue(VerticalOffsetProperty, value); }
        }
        
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if(GetTemplateChild("PART_PopupControl") is ToggleButton toggleButton)
            {
                PART_PopupControl = toggleButton;
                PART_PopupControl.Checked -= PART_PopupControl_Checked;
                PART_PopupControl.Checked += PART_PopupControl_Checked;
            }
            if(GetTemplateChild("PART_Popup") is Popup popup)
            {
                PART_Popup = popup;
                PART_Popup.LostFocus += PART_Popup_LostFocus;
            }
        }

        private void PART_Popup_LostFocus(object sender, RoutedEventArgs e)
        {
            PART_Popup.IsOpen = false;
            PART_PopupControl.IsChecked = false;
        }


        private void PART_PopupControl_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)PART_PopupControl.IsChecked)
            {
                PART_Popup.IsOpen = true;
                PART_Popup.Focus();
            }
            else
            {
                PART_Popup.IsOpen = false;
            }
        }
    }
}
