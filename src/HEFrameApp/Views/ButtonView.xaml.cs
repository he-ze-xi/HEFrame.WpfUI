using System;
using System.IO;
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

        //private void btnShowXamlCode_Click(object sender, RoutedEventArgs e)
        //{
        //    var owner = Window.GetWindow(this);

        //    string xamlSamplePath = "XamlSamples/ButtonView.xaml.txt";
        //    string codeBehindSamplePath = "XamlSamples/ButtonView.xaml.cs.txt";
        //    string viewModelSamplePath = "XamlSamples/ButtonViewModel.cs.txt";


        //    XamlViewerWindow.ShowXamlAndCode(this, xamlSamplePath, codeBehindSamplePath, viewModelSamplePath, owner);
        //}
    }
}