using System.Collections.ObjectModel;
using System.Linq;

namespace FileExplorer.Core
{
    /// <summary>
    /// This view model for the applications main Directory view.
    /// </summary>
    public class DirectoryStructureViewModel
    {
        /// <summary>
        /// A list of all directories on the machine.
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        public DirectoryStructureViewModel()
        {
            Items = new ObservableCollection<DirectoryItemViewModel>();

            foreach (var dvm in from item in DirectoryStructure.GetLogicalDrives()
                                let dvm = new DirectoryItemViewModel(item.FullPath, item.Type)
                                select dvm)
            {
                Items.Add(dvm);
            }
        }
    }
}
