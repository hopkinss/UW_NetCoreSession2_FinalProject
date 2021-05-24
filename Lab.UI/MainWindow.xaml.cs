using Lab.UI.ViewModel;
using System;
using System.Windows;

namespace Lab.UI
{

    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            _viewModel = viewModel;
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
           await _viewModel.LoadAsync();
        }
    }
}
