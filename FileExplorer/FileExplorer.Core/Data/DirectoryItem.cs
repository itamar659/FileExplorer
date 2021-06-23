namespace FileExplorer.Core
{
    public class DirectoryItem
    {
        /// <summary>
        /// The absolute path to this item.
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// The name of this directory item.
        /// </summary>
        public string Name { get => Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(FullPath); }

        /// <summary>
        /// The type of the 
        /// </summary>
        public DirectoryItemType Type { get; set; }


    }
}
