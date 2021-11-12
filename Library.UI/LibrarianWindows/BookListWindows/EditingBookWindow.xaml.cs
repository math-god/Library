using System;
using System.Windows;
using Library.Service;
using Library.Storage.EntityModels;

namespace Library.UI.LibrarianWindows.BookListWindows
{
    public partial class EditingBookWindow : Window
    {
        private readonly BookService _bookService = new BookService();
        private readonly Book _book;

        public EditingBookWindow(Book book = null)
        {
            InitializeComponent();

            DataContext = book;
            _book = book;
        }

        private void OpenExplorer_OnClick(object sender, RoutedEventArgs e)
        {
            var filename = FileExplorerService.OpenExplorerAndGetFileName(FileExplorerService.FileFormat.Jpg);
            CoverPreviewTextBox.Text = filename;
        }
        
        private void EditBook_OnClick(object sender, RoutedEventArgs e)
        {
            var name = NameTextBox.Text.Trim();
            var genre = GenreTextBox.Text.Trim();
            var author = AuthorTextBox.Text.Trim();
            var publicationYear = Convert.ToInt32(PublicationYearTextBox.Text.Trim());
            var description = DescriptionTextBox.Text.Trim();
            var coverPreview = CoverPreviewTextBox.Text.Trim();
            var isbn = IsbnTextBox.Text.Trim();
            var isBanned = (bool) BanCheckBox.IsChecked;

            _bookService.EditBook(name, genre, author, publicationYear, description, coverPreview,
                isbn, isBanned, _book);

            MessageBox.Show("Данные были успешно изменены");

            /*catch (Exception)
            {
                MessageBox.Show("Ввод ФИО является обязательным");
                return;
            }*/

            DialogResult = true;
        }
    }
}