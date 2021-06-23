using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FileExplorer.Core
{
    /// <summary>
    /// View model for each directory item.
    /// </summary>
    public class DirectoryItemViewModel : BaseViewModel
    {
        #region Public properties

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

        /// <summary>
        /// A list of all the chilren contained inside this item.
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }
        
        /// <summary>
        /// Indicate if this item can be expended.
        /// </summary>
        // NO NEED
        public bool CanExpend { get { return Type != DirectoryItemType.File; } }

        /// <summary>
        /// Indicate if the item has expended.
        /// </summary>
        public bool IsExpended
        {
            get
            {
                return Children?.Count(f => f != null) > 0;
            }
            set
            {
                if (value)
                    expend();
                else
                    clearChildren();
                OnpPropertyChanged("Children");
            }
        }

        #endregion

        /// <summary>
        /// The command to expend this item.
        /// </summary>
        public ICommand ExpendCommand { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="fullPath">The full path of this item.</param>
        /// <param name="type">The type of this item.</param>
        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            FullPath = fullPath;
            Type = type;
            // NO NEED
            ExpendCommand = new RelayCommand(expend);

            // Needed to create the first child.
            clearChildren();
        }

        private void clearChildren()
        {
            Children = new ObservableCollection<DirectoryItemViewModel>();

            // Add dummy item.
            if (Type != DirectoryItemType.File)
                Children.Add(null);
        }

        private void expend()
        {
            if (Type == DirectoryItemType.File)
                return;

            Children = new ObservableCollection<DirectoryItemViewModel>();

            foreach (var dvm in from item in DirectoryStructure.GetDirectoryContent(FullPath)
                                let dvm = new DirectoryItemViewModel(item.FullPath, item.Type)
                                select dvm)
            {
                Children.Add(dvm);
            }
        }
    }
}
