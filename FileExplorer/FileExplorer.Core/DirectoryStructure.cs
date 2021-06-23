using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileExplorer.Core
{
    public static class DirectoryStructure
    {
        /// <summary>
        /// Get all the logical drives on the computer.
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrives()
        {
            return Directory.GetLogicalDrives().Select(drive => new DirectoryItem() { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();
        }

        /// <summary>
        /// Get all the files and folders inside a directory item.
        /// </summary>
        /// <param name="path">The full path of the directory.</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContent(string path)
        {
            var items = new List<DirectoryItem>();
            var sec = new List<System.Security.AccessControl.DirectorySecurity>();

            // Try to get directories from the folder.
            try
            {
                var dirs = Directory.GetDirectories(path);

                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(dir => new DirectoryItem() { FullPath = dir, Type = DirectoryItemType.Folder}));
            }
            catch { }

            // Try to get files from the folder.
            try
            {
                var files = Directory.GetFiles(path);

                if (files.Length > 0)
                    items.AddRange(files.Select(file => new DirectoryItem() { FullPath = file, Type = DirectoryItemType.File }));
            }
            catch { }

            return items;
        }

        /// <summary>
        /// Find the file or folder name from a full path.
        /// </summary>
        /// <param name="path">the full path.</param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            var lastIndex = path.LastIndexOf('\\') + 1;

            return path.Substring(lastIndex);
        }
    }
}
