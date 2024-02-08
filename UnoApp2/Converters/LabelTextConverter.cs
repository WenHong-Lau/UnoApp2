using Microsoft.UI.Xaml.Data;

namespace UnoApp2.Converters;

public class LabelTextConverter : IValueConverter
{

    /// <returns>A converted value. If the method returns null the valid null value is used</returns>
    public object Convert(object value, Type targetType, object parameter, string culture)
    {
        /// Returns the string representation of the value.
        if (value != null)
        {
            /// Returns the string representation of the value.
            if(value is Person) 
            {
                Person x = value as Person;
                if (x.IsVIP) return "VIP";
            }
        }
        return "Non VIP";
    }

    public object ConvertBack(object value, Type targetType, object parameter, string culture)
    {
        throw new NotImplementedException();
    }
}
