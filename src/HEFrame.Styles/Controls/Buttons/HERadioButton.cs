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

namespace HEFrame.Styles.Controls
{
    /// <summary>
    /// RadioButton
    /// </summary>
    public class HERadioButton : RadioButton, IHEUITheme
    {
        public static readonly DependencyProperty ThemeTypeProperty = DependencyProperty.Register("ThemeType", typeof(ThemeType), typeof(HERadioButton), new FrameworkPropertyMetadata(ThemeType.Light));
        public HERadioButton()
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
    }
}
