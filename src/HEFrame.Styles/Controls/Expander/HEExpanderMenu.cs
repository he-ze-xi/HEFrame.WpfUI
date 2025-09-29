using HEFrame.Styles.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HEFrame.Styles.Controls
{
    /// <summary>
    /// 折叠菜单组件
    /// </summary>
    [TemplatePart(Name = "PART_MenuItemsContent", Type = typeof(ItemsControl))]
    public class HEExpanderMenu : HEExpander
    {
        public static readonly DependencyProperty MenuItemsProperty = DependencyProperty.Register("MenuItems", typeof(IList<string>), typeof(HEExpanderMenu), new FrameworkPropertyMetadata(OnMenuItemsChanged));
        public static readonly DependencyProperty SelectedBrushProperty = DependencyProperty.Register("SelectedBrush", typeof(Brush), typeof(HEExpanderMenu));
        public static readonly DependencyProperty MenuSwitchCommandProperty = DependencyProperty.Register("MenuSwitchCommand", typeof(ICommand), typeof(HEExpanderMenu));
        internal ItemsControl PART_MenuItemsContent;
        public HEExpanderMenu()
        {
            CommandBinding binding = new CommandBinding(HECommands.ExpanderMenuItemSwitchCommand);
            binding.Executed += Binding_Executed;
            CommandBindings.Add(binding);
        }

        private void Binding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (MenuSwitchCommand != null && MenuSwitchCommand.CanExecute(e.Parameter))
            {
                MenuSwitchCommand.Execute(e.Parameter);
            }
        }
        /// <summary>
        /// 菜单切换命令
        /// </summary>
        [Bindable(true)]
        public ICommand MenuSwitchCommand
        {
            get { return (ICommand)GetValue(MenuSwitchCommandProperty); }
            set { SetValue(MenuSwitchCommandProperty, value); }
        }
        /// <summary>
        /// 菜单子项
        /// </summary>
        [Bindable(true)]
        public IList<string> MenuItems
        {
            get { return (IList<string>)GetValue(MenuItemsProperty); }
            set { SetValue(MenuItemsProperty, value); }
        }
        /// <summary>
        /// 菜单子项选中时的颜色
        /// </summary>
        [Bindable(true)]
        public Brush SelectedBrush
        {
            get { return (Brush)GetValue(SelectedBrushProperty); }
            set { SetValue(SelectedBrushProperty, value); }
        }

        private static void OnMenuItemsChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            if (dp is HEExpanderMenu menu)
            {
                AddItems(menu);
            }
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("PART_MenuItemsContent") is ItemsControl itemsControl)
            {
                PART_MenuItemsContent = itemsControl;
                AddItems(this);
            }
            
        }
        private static void AddItems(HEExpanderMenu meun)
        {
            if (meun.PART_MenuItemsContent == null || meun.MenuItems == null)
                return;
            foreach (var item in meun.MenuItems)
            {
                meun.PART_MenuItemsContent.Dispatcher.BeginInvoke(new Action(() =>
                {
                    meun.PART_MenuItemsContent.Items.Add(item);
                }));
            }
        }
    }
}
