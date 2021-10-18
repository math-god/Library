using System;
using System.Windows;
using Library.FileExplorer;
using Library.LibrarianWindows;
using Library.ReaderWindows;

namespace Library
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void GoToLibrarianSignInWindow_OnClick(object sender, RoutedEventArgs e)
        {
            var librarianSignInWindow = new LibrarianSignInWindow();
            librarianSignInWindow.ShowDialog();
            if (librarianSignInWindow.DialogResult == true)
            {
                Visibility = Visibility.Hidden;
                new LibrariansOffice().ShowDialog(); 
            }
        }

        private void GoToReaderSignInWindow_OnClick(object sender, RoutedEventArgs e)
        {
            new ReaderSignInWindow().ShowDialog();
        }

        private void GoToLibrariansOfficeWindow_OnClick(object sender, RoutedEventArgs e)
        {
            new LibrariansOffice().ShowDialog();
        }
    }
}