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
    /// 数据表格
    /// </summary>
    public class HEDataGrid : DataGrid, IHEUITheme
    {
        public static readonly DependencyProperty ThemeTypeProperty = DependencyProperty.Register("ThemeType", typeof(ThemeType), typeof(HEDataGrid), new FrameworkPropertyMetadata(ThemeType.Light));
        public static readonly DependencyProperty SelectedBrushProperty = DependencyProperty.Register("SelectedBrush", typeof(Brush), typeof(HEDataGrid));
        public static readonly DependencyProperty EditingTextColumnElementStyleProperty = DependencyProperty.Register("EditingTextColumnElementStyle", typeof(Style), typeof(HEDataGrid), new FrameworkPropertyMetadata(OnTextColumnElementStyleChanged));
        public static readonly DependencyProperty TextColumnElementStyleProperty = DependencyProperty.Register("TextColumnElementStyle", typeof(Style), typeof(HEDataGrid), new FrameworkPropertyMetadata(OnTextColumnElementStyleChanged));
        public static readonly DependencyProperty HyperlinkColumnElementStyleProperty = DependencyProperty.Register("HyperlinkColumnElementStyle", typeof(Style), typeof(HEDataGrid), new FrameworkPropertyMetadata(OnHyperlinkColumnElementStyleChanged));
        public static readonly DependencyProperty CheckBoxColumnEditingElementStyleProperty = DependencyProperty.Register("CheckBoxColumnEditingElementStyle", typeof(Style), typeof(HEDataGrid), new FrameworkPropertyMetadata(OnCheckBoxColumnElementStyleChanged));
        public static readonly DependencyProperty CheckBoxColumnElementStyleProperty = DependencyProperty.Register("CheckBoxColumnElementStyle", typeof(Style), typeof(HEDataGrid), new FrameworkPropertyMetadata(OnCheckBoxColumnElementStyleChanged));
        public static readonly DependencyProperty LoadingAnimationActiveProperty = DependencyProperty.Register("LoadingAnimationActive", typeof(bool), typeof(HEDataGrid));
        public HEDataGrid()
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
        /// 选中行的颜色
        /// </summary>
        [Bindable(true)]
        public Brush SelectedBrush
        {
            get { return (Brush)GetValue(SelectedBrushProperty); }
            set { SetValue(SelectedBrushProperty, value); }
        }
        /// <summary>
        /// TextColumn样式
        /// </summary>
        [Bindable(true)]
        public Style TextColumnElementStyle
        {
            get { return (Style)GetValue(TextColumnElementStyleProperty); }
            set { SetValue(TextColumnElementStyleProperty, value); }
        }
        /// <summary>
        /// EditingTextColumn样式
        /// </summary>
        [Bindable(true)]
        public Style EditingTextColumnElementStyle
        {
            get { return (Style)GetValue(EditingTextColumnElementStyleProperty); }
            set { SetValue(EditingTextColumnElementStyleProperty, value); }
        }
        /// <summary>
        /// HyperlinkColumn样式
        /// </summary>
        [Bindable(true)]
        public Style HyperlinkColumnElementStyle
        {
            get { return (Style)GetValue(HyperlinkColumnElementStyleProperty); }
            set { SetValue(HyperlinkColumnElementStyleProperty, value); }
        }
        /// <summary>
        /// CheckBoxColumn样式
        /// </summary>
        [Bindable(true)]
        public Style CheckBoxColumnElementStyle
        {
            get { return (Style)GetValue(CheckBoxColumnElementStyleProperty); }
            set { SetValue(CheckBoxColumnElementStyleProperty, value); }
        }
        /// <summary>
        /// CheckBoxColumnEditing样式
        /// </summary>
        [Bindable(true)]
        public Style CheckBoxColumnEditingElementStyle
        {
            get { return (Style)GetValue(CheckBoxColumnEditingElementStyleProperty); }
            set { SetValue(CheckBoxColumnEditingElementStyleProperty, value); }
        }
        /// <summary>
        /// 数据加载动画开关
        /// </summary>
        [Bindable(true)]
        public bool LoadingAnimationActive
        {
            get { return (bool)GetValue(LoadingAnimationActiveProperty); }
            set { SetValue(LoadingAnimationActiveProperty, value); }
        }

        private static void OnTextColumnElementStyleChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            if (!(dp is HEDataGrid dataGrid)) return;
            if (e.OldValue==null && e.NewValue != null)
            {
                dataGrid.UpdateTextStyle(dataGrid);
            }
        }
        private static void OnHyperlinkColumnElementStyleChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            if (!(dp is HEDataGrid dataGrid)) return;
            if (e.OldValue == null && e.NewValue != null)
            {
                dataGrid.UpdateHyperlinkStyle(dataGrid);
            }
        }
        private static void OnCheckBoxColumnElementStyleChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            if (!(dp is HEDataGrid dataGrid)) return;
            if (e.OldValue == null && e.NewValue != null)
            {
                dataGrid.UpdateCheckBoxStyle(dataGrid);
            }
        }
        private void UpdateTextStyle(HEDataGrid dataGrid)
        {
            if (dataGrid == null) return;
            if (TextColumnElementStyle != null)
            {
                foreach (var item in dataGrid.Columns.OfType<DataGridTextColumn>())
                {
                    var style = new Style() { BasedOn = item.ElementStyle, TargetType = TextColumnElementStyle.TargetType };
                    foreach (var setter in TextColumnElementStyle.Setters.OfType<Setter>())
                    {
                        style.Setters.Add(setter);
                    }
                    foreach (var setter in TextColumnElementStyle.Triggers.OfType<Trigger>())
                    {
                        style.Triggers.Add(setter);
                    }
                    item.ElementStyle = style;
                }
            }
            if (EditingTextColumnElementStyle != null)
            {
                foreach (var item in dataGrid.Columns.OfType<DataGridTextColumn>())
                {
                    var style = new Style() { BasedOn = item.EditingElementStyle, TargetType = EditingTextColumnElementStyle.TargetType };
                    foreach (var setter in EditingTextColumnElementStyle.Setters.OfType<Setter>())
                    {
                        style.Setters.Add(setter);
                    }
                    foreach (var setter in EditingTextColumnElementStyle.Triggers.OfType<Trigger>())
                    {
                        style.Triggers.Add(setter);
                    }
                    item.EditingElementStyle = style;
                }
            }
        }
        private void UpdateHyperlinkStyle(HEDataGrid dataGrid)
        {
            if (dataGrid == null) return;
            if (HyperlinkColumnElementStyle != null)
            {
                foreach (var item in dataGrid.Columns.OfType<DataGridHyperlinkColumn>())
                {
                    var style = new Style() { BasedOn = item.ElementStyle, TargetType = HyperlinkColumnElementStyle.TargetType };
                    foreach (var setter in HyperlinkColumnElementStyle.Setters.OfType<Setter>())
                    {
                        style.Setters.Add(setter);
                    }
                    foreach (var setter in HyperlinkColumnElementStyle.Triggers.OfType<Trigger>())
                    {
                        style.Triggers.Add(setter);
                    }
                    item.ElementStyle = style;
                }
            }
            if (EditingTextColumnElementStyle != null)
            {
                foreach (var item in dataGrid.Columns.OfType<DataGridHyperlinkColumn>())
                {
                    var style = new Style() { BasedOn = item.EditingElementStyle, TargetType = EditingTextColumnElementStyle.TargetType };
                    foreach (var setter in EditingTextColumnElementStyle.Setters.OfType<Setter>())
                    {
                        style.Setters.Add(setter);
                    }
                    foreach (var setter in EditingTextColumnElementStyle.Triggers.OfType<Trigger>())
                    {
                        style.Triggers.Add(setter);
                    }
                    item.EditingElementStyle = style;
                }
            }
        }
        private void UpdateCheckBoxStyle(HEDataGrid dataGrid)
        {
            if (dataGrid == null) return;
            if (CheckBoxColumnElementStyle != null)
            {
                foreach (var item in dataGrid.Columns.OfType<DataGridCheckBoxColumn>())
                {
                    var style = new Style() { BasedOn = item.ElementStyle, TargetType = CheckBoxColumnElementStyle.TargetType };
                    foreach (var setter in CheckBoxColumnElementStyle.Setters.OfType<Setter>())
                    {
                        style.Setters.Add(setter);
                    }
                    foreach (var setter in CheckBoxColumnElementStyle.Triggers.OfType<Trigger>())
                    {
                        style.Triggers.Add(setter);
                    }
                    item.ElementStyle = style;
                }
            }
            if (CheckBoxColumnEditingElementStyle != null)
            {
                foreach (var item in dataGrid.Columns.OfType<DataGridCheckBoxColumn>())
                {
                    var style = new Style() { BasedOn = item.EditingElementStyle, TargetType = CheckBoxColumnEditingElementStyle.TargetType };
                    foreach (var setter in CheckBoxColumnEditingElementStyle.Setters.OfType<Setter>())
                    {
                        style.Setters.Add(setter);
                    }
                    foreach (var setter in CheckBoxColumnEditingElementStyle.Triggers.OfType<Trigger>())
                    {
                        style.Triggers.Add(setter);
                    }
                    item.EditingElementStyle = style;
                }
            }
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            UpdateTextStyle(this);
            UpdateHyperlinkStyle(this);
            UpdateCheckBoxStyle(this);
        }
    }
}
