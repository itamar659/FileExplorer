using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using FileExplorer.Core;

namespace FileExplorer
{
    public static class ImageSource
    {
        private static readonly Dictionary<DirectoryItemType, BitmapImage> _types = new Dictionary<DirectoryItemType, BitmapImage>();

        public static void Initialize()
        {
            _types.Add(DirectoryItemType.Drive, new BitmapImage(new Uri(@"Images/drive.png", UriKind.RelativeOrAbsolute)));
            _types.Add(DirectoryItemType.File, new BitmapImage(new Uri(@"Images/file.png", UriKind.RelativeOrAbsolute)));
            _types.Add(DirectoryItemType.Folder, new BitmapImage(new Uri(@"Images/folder.png", UriKind.RelativeOrAbsolute)));
        }

        public static BitmapImage GetBitmapImage(DirectoryItemType type) => _types[type];
    }
}
