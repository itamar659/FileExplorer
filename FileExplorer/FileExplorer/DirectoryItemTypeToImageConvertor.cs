using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using FileExplorer.Core;

namespace FileExplorer
{
    /// <summary>
    /// Converts a directory item type to an image.
    /// </summary>
    [ValueConversion(typeof(DirectoryItemType), typeof(BitmapImage))]
    public class DirectoryItemTypeToImageConvertor : IValueConverter
    {
        public static DirectoryItemTypeToImageConvertor Instance = new DirectoryItemTypeToImageConvertor();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ImageSource.GetBitmapImage((DirectoryItemType)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
