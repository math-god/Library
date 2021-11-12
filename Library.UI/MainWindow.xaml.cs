using System.Windows;
using Library.Service;
using Library.UI.LibrarianWindows;
using Library.UI.ReaderWindows;

namespace Library.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IsbnService _isbnService = new IsbnService();
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

        private void GoToReaderOfficeWindow_OnClick(object sender, RoutedEventArgs e)
        {
            new ReadersOfficeWindow().ShowDialog();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _isbnService.GetBook("9780980200447");
        }
    }
}