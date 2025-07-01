using System.Windows;
using ColorCreator.ViewModels;

namespace ColorCreator
{
    public partial class MainWindow : Window {
        private ColorViewModel _ColorViewModel { get; set; } = 
            new ColorViewModel();

        public MainWindow()
        { 
            DataContext = _ColorViewModel;
            InitializeComponent();
        }
    }
}
