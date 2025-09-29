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
    public class HETabItem : TabItem, IHEUITheme
    {
        public static readonly DependencyProperty ThemeTypeProperty = DependencyProperty.Register("ThemeType", typeof(ThemeType), typeof(HETabItem), new FrameworkPropertyMetadata(ThemeType.Light));
        public static readonly DependencyProperty SelectedBrushProperty = DependencyProperty.Register("SelectedBrush", typeof(Brush), typeof(HETabItem));
        public HETabItem()
        {

        }
        public event Action<HETabItem> RemovedItemEvent;
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
        /// 选中时的颜色
        /// </summary>
        [Bindable(true)]
        public Brush SelectedBrush
        {
            get { return (Brush)GetValue(SelectedBrushProperty); }
            set { SetValue(SelectedBrushProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if(GetTemplateChild("PART_CloseButton") is Button button)
            {
                button.Click -= Button_Click;
                button.Click += Button_Click;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Parent is HETabControl tabControl && tabControl.Items.Contains(this))
            {
                tabControl.Items.Remove(this);
            }
            RemovedItemEvent?.Invoke(this);
        }
    }
}
