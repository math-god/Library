using System.Windows;
using Library.Service;

namespace Library.UI.LibrarianWindows.BookListWindows
{
    public partial class AddingBookByIsbnWindow : Window
    {
        private readonly BookService _bookService = new BookService();

        public AddingBookByIsbnWindow()
        {
            InitializeComponent();
        }


        private void InputIsbnButton_OnClick(object sender, RoutedEventArgs e)
        {
            var isbn = IsbnTextBox.Text.Trim();

            _bookService.CreateBookByIsbn(isbn);

            MessageBox.Show("Данные успешно добавлены");

            DialogResult = true;
        }
    }
}