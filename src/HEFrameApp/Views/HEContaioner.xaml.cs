using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HEFrameApp.Views
{
    public partial class HEContaioner : UserControl
    {
        public HEContaioner()
        {
            InitializeComponent();
        }

        #region 依赖属性

        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(HEContaioner));

        public new object Content
        {
            get { return GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public static readonly DependencyProperty ContentTemplateProperty =
            DependencyProperty.Register("ContentTemplate", typeof(DataTemplate), typeof(HEContaioner));

        public new DataTemplate ContentTemplate
        {
            get { return (DataTemplate)GetValue(ContentTemplateProperty); }
            set { SetValue(ContentTemplateProperty, value); }
        }

        public static readonly DependencyProperty ContentTemplateSelectorProperty =
            DependencyProperty.Register("ContentTemplateSelector", typeof(DataTemplateSelector), typeof(HEContaioner));

        public new DataTemplateSelector ContentTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(ContentTemplateSelectorProperty); }
            set { SetValue(ContentTemplateSelectorProperty, value); }
        }

        #endregion

        private void HEButton_Click(object sender, RoutedEventArgs e)
        {
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
        /// 查找父级UserControl
        /// </summary>
        /// <param name="child">子元素</param>
        /// <returns>父级UserControl，如果没有找到则返回null</returns>
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
