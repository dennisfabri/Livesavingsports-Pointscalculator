using System;
using Xamarin.Forms;

namespace de.df.points.View.Extensions
{
  public class IsValidConverter : IValueConverter
  {
    private static Color Black = Color.FromHex("FF606060");

    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      try {
        if (value is bool) {
          bool valid = (bool)value;
          return valid ? Black : Color.Red;
        }
        return Black;
      } catch (Exception) {
        return Color.Purple;
      }
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      return true;
    }
  }
}
