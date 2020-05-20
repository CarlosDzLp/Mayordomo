using System;
using System.Globalization;
using Xamarin.Forms;

namespace MayordomoApp.Converts
{
    public class ImageConvertString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var file = value as string;
            if (file != null)
            {
                return "user_camera";
            }
            else
            {
                return file;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
