using System;
using System.Windows;
using System.Windows.Controls;
using Library.Service;
using Library.Service.Models;

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
            
                var title = TitleTextBox.Text.Trim();
                var genre = GenreTextBox.Text.Trim();
                var author = AuthorTextBox.Text.Trim();
                var publicationYear = PublicationYearTextBox.Text.Trim();
                var description = DescriptionTextBox.Text.Trim();
                var coverPreview = CoverPreviewTextBox.Text.Trim();
                var isbn = IsbnTextBox.Text.Trim();

                var bookDto = new BookDto()
                {
                    Title = title,
                    Genre = genre,
                    Author = author,
                    PublicationDate = publicationYear,
                    Description = description,
                    Isbn = isbn
                };

                _bookService.CreateBook(bookDto);

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