using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using ColorCreator.Models;

namespace ColorCreator.Converters
{
    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            if (value is ItemColor colorItem)
            {
                return new SolidColorBrush(colorItem.ActualColor);
            }
            return Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}