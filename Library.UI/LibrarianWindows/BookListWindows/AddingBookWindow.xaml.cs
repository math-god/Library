using System;
using System.Windows;
using System.Windows.Controls;
using Library.Service;

namespace Library.UI.LibrarianWindows.BookListWindows
{
    public partial class AddingBookWindow : Window
    {
        private readonly BookService _bookService = new BookService();
        public AddingBookWindow()
        {
            InitializeComponent();
        }

        private void OpenExplorer_OnClick(object sender, RoutedEventArgs e)
        {
            var filename = FileExplorerService.OpenExplorerAndGetFileName(FileExplorerService.FileFormat.Jpg);
            CoverPreviewTextBox.Text = filename;
        }

        private void AddBook_OnClick(object sender, RoutedEventArgs e)
        {
            
                var name = NameTextBox.Text.Trim();
                var genre = GenreTextBox.Text.Trim();
                var author = AuthorTextBox.Text.Trim();
                var publicationYear = Convert.ToInt32(PublicationYearTextBox.Text.Trim());
                var description = DescriptionTextBox.Text.Trim();
                var coverPreview = CoverPreviewTextBox.Text.Trim();
                var isbn = IsbnTextBox.Text.Trim();

                _bookService.CreateBook(name, genre, author, publicationYear, description, coverPreview, isbn);

                MessageBox.Show("Данные были успешно добавлены");
            
            /*catch (Exception)
            {
                MessageBox.Show("Невенрый формат данных");
                return;
            }*/

            DialogResult = true;
        }
    }
}