using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace DecoderApp
{
    /// <summary>
    /// Interaction logic for ApplicationView.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ApplicationViewModel _viewModel = new ApplicationViewModel();
        
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
    }
}