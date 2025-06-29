using System.Windows;


namespace ColorCreator
{
    public partial class MainWindow : Window
    {
        private ColorViewModel _ColorViewModel { get; set; }

        public MainWindow()
        {
            _ColorViewModel = new ColorViewModel();

            DataContext = _ColorViewModel;

            InitializeComponent();
        }
    }
}
