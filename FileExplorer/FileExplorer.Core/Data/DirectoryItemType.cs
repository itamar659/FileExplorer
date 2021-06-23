using System;

namespace FileExplorer.Core
{
    /// <summary>
    /// The type of a directory item.
    /// </summary>
    public enum DirectoryItemType
    {
        /// <summary>
        /// A logical drive.
        /// </summary>
        Drive,
        /// <summary>
        /// A folder.
        /// </summary>
        Folder,
        /// <summary>
        /// A physical file.
        /// </summary>
        File
    }
}
