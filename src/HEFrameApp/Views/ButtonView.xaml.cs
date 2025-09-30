using System.Windows;
using System.Windows.Controls;

namespace HEFrameApp.Views
{
    /// <summary>
    /// ButtonView.xaml 的交互逻辑
    /// </summary>
    public partial class ButtonView : UserControl
    {
        public ButtonView()
        {
            InitializeComponent();
        }

        private void btnShowXamlCode_Click(object sender, RoutedEventArgs e)
        {
            var owner = Window.GetWindow(this);
            string XamlSamplePath = "XamlSamples/ButtonView.xaml.txt";
            XamlViewerWindow.ShowXamlForControl(this, XamlSamplePath, owner);
        }
    }
}

