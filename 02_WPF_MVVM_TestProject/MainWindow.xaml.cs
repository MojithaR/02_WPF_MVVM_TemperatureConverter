using System.Windows;

using _02_WPF_MVVM_TestProject.ViewModels;

namespace _02_WPF_MVVM_TestProject
{
    public partial class MainWindow : Window
    {
        private TemperatureViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new TemperatureViewModel();
            DataContext = _viewModel;
        }
    }
}