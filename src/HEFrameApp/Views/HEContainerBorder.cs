using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup; // 添加这个命名空间
using System.Windows.Media;
using System.Windows.Input;

namespace HEFrameApp.Views
{
    [ContentProperty("Content")] // 添加这个特性以支持直接内容
    public class HEContainerBorder : Control
    {
        private Button _codeButton;
        private ContentPresenter _contentPresenter;

        static HEContainerBorder()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HEContainerBorder),
                new FrameworkPropertyMetadata(typeof(HEContainerBorder)));
        }

        public HEContainerBorder()
        {
            // 设置默认背景为透明
            this.Background = Brushes.Transparent;
        }

        #region 依赖属性

        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(HEContainerBorder),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, OnContentChanged));

        public object Content
        {
            get { return GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public static readonly DependencyProperty ContentTemplateProperty =
            DependencyProperty.Register("ContentTemplate", typeof(DataTemplate), typeof(HEContainerBorder),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure));

        public DataTemplate ContentTemplate
        {
            get { return (DataTemplate)GetValue(ContentTemplateProperty); }
            set { SetValue(ContentTemplateProperty, value); }
        }

        public static readonly DependencyProperty ContentTemplateSelectorProperty =
            DependencyProperty.Register("ContentTemplateSelector", typeof(DataTemplateSelector), typeof(HEContainerBorder),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure));

        public DataTemplateSelector ContentTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(ContentTemplateSelectorProperty); }
            set { SetValue(ContentTemplateSelectorProperty, value); }
        }

        #endregion

        #region 命令和事件

        public static readonly RoutedEvent CodeButtonClickEvent =
            EventManager.RegisterRoutedEvent("CodeButtonClick", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(HEContainerBorder));

        public event RoutedEventHandler CodeButtonClick
        {
            add { AddHandler(CodeButtonClickEvent, value); }
            remove { RemoveHandler(CodeButtonClickEvent, value); }
        }

        public static readonly DependencyProperty CodeButtonClickCommandProperty =
            DependencyProperty.Register("CodeButtonClickCommand", typeof(ICommand), typeof(HEContainerBorder));

        public ICommand CodeButtonClickCommand
        {
            get { return (ICommand)GetValue(CodeButtonClickCommandProperty); }
            set { SetValue(CodeButtonClickCommandProperty, value); }
        }

        #endregion

        /// <summary>
        /// 当内容改变时的处理
        /// </summary>
        private static void OnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var container = d as HEContainerBorder;
            if (container != null && container._contentPresenter != null)
            {
                // 确保名称范围正确
                container.EnsureNameScope();
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            // 获取模板中的部件
            _codeButton = GetTemplateChild("PART_CodeButton") as Button;
            _contentPresenter = GetTemplateChild("PART_ContentPresenter") as ContentPresenter;

            // 订阅按钮点击事件
            if (_codeButton != null)
            {
                _codeButton.Click -= OnCodeButtonClick;
                _codeButton.Click += OnCodeButtonClick;
            }

            // 确保名称范围正确
            EnsureNameScope();
        }

        private void OnCodeButtonClick(object sender, RoutedEventArgs e)
        {
            // 触发路由事件
            RaiseEvent(new RoutedEventArgs(CodeButtonClickEvent, this));

            // 执行命令
            if (CodeButtonClickCommand != null && CodeButtonClickCommand.CanExecute(null))
            {
                CodeButtonClickCommand.Execute(null);
            }

            // 执行原有的逻辑
            var owner = Window.GetWindow(this);
            var parentUserControl = FindParentUserControl(this);
            if (parentUserControl == null) return;

            var userControlTypeName = parentUserControl.GetType().Name;

            string xamlSamplePath = $"Views/{userControlTypeName}.xaml";
            string codeBehindSamplePath = $"Views/{userControlTypeName}.xaml.cs";
            string viewModelSamplePath = $"ViewModels/{userControlTypeName}Model.cs";

            XamlViewerWindow.ShowXamlAndCode(this, xamlSamplePath, codeBehindSamplePath, viewModelSamplePath, owner);
        }

        /// <summary>
        /// 确保名称范围正确设置
        /// </summary>
        private void EnsureNameScope()
        {
            // 确保ContentPresenter使用父级的名称范围
            if (_contentPresenter != null)
            {
                var parentNameScope = NameScope.GetNameScope(this);
                if (parentNameScope != null)
                {
                    NameScope.SetNameScope(_contentPresenter, parentNameScope);
                }
            }
        }

        /// <summary>
        /// 查找父级UserControl
        /// </summary>
        private UserControl FindParentUserControl(DependencyObject child)
        {
            var parent = VisualTreeHelper.GetParent(child);
            while (parent != null)
            {
                if (parent is UserControl userControl)
                {
                    return userControl;
                }
                parent = VisualTreeHelper.GetParent(parent);
            }
            return null;
        }
    }
}