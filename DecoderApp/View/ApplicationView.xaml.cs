using System.Windows;
using System.Windows.Input;
using DecoderApp.ViewModel;

namespace DecoderApp.View
{
    /// <summary>
    /// Interaction logic for ApplicationView.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly ApplicationViewModel _viewModel = new();
        
        public MainWindow()
        {
            InitializeComponent();

            DataContext = _viewModel;
        }

        private void ButtonOpenFile_OnClick(object sender, RoutedEventArgs e)
        {
            TextBoxOpenFile.Text = _viewModel.OpenFile();
        }

        private void ButtonSaveFile_OnClick(object sender, RoutedEventArgs e)
        {
            TextBoxSaveFile.Text = _viewModel.SaveFile();
        }

        private void ButtonDecrypt_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.DecryptFile(TextBoxOpenFile.Text, TextBoxSaveFile.Text, TextBoxArgument.Text);
        }

        private void ButtonCloseApp_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        
        private void ButtonWindowApp_OnClick(object sender, RoutedEventArgs e)
        {
            switch (WindowState)
            {
                case WindowState.Maximized:
                    WindowState = WindowState.Normal;
                    return;
                case WindowState.Normal:
                    WindowState = WindowState.Maximized;
                    return;
                case WindowState.Minimized:
                    WindowState = WindowState.Maximized;
                    return;
                default:
                    WindowState = WindowState.Maximized;
                    return;
            }
        }

        private void ButtonMinimizeApp_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton != MouseButtonState.Pressed) return;
            WindowState = WindowState.Normal;
            DragMove();
        }
    }
}