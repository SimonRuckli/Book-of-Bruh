namespace BookOfBruh.View
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using Core.Symbols;

    public class SymbolConverter : IValueConverter	
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"../Images/{value?.GetType().Name}.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}