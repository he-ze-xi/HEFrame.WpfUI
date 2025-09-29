using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace HEFrame.Styles.Converters
{
    public class ProgressValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double value = (double)values[0];
            double trickness = (double)values[1];
            double radius = (double)values[2] / 2;
            double girth = Math.PI * (2 * radius - trickness) / trickness;
            double showPrecent = value / 100 * girth;
            var converter = TypeDescriptor.GetConverter(typeof(DoubleCollection));
            return (DoubleCollection)converter.ConvertFrom($"{showPrecent} {girth}");
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
