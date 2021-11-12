using System.Windows;
using Library.UI.LibrarianWindows.BookListWindows;
using Library.UI.LibrarianWindows.ReaderListWindows;

namespace Library.UI.LibrarianWindows
{
    public partial class LibrariansOffice : Window
    {
        public LibrariansOffice()
        {
            InitializeComponent();
        }


        private void GoToReaderListWindow_OnClick(object sender, RoutedEventArgs e)
        {
            new ReaderListWindow().ShowDialog();
        }

        private void GoToBookListWindow_OnClick(object sender, RoutedEventArgs e)
        {
            new BookListWindow().ShowDialog();
        }
    }
}