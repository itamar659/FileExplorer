using System.Windows;
using FileExplorer.Core;
namespace FileExplorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ImageSource.Initialize();

            DataContext = new DirectoryStructureViewModel();
        }
    }
}
