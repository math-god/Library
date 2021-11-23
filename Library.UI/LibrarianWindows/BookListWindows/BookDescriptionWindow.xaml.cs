using System.Windows;
using Library.Service;
using Library.Storage.EntityModels;

namespace Library.UI.LibrarianWindows.BookListWindows
{
    public partial class BookDescriptionWindow : Window
    {
        private ImageService _imageService = new ImageService();
        public BookDescriptionWindow(Book book = null)
        {
            InitializeComponent();
            
            CheckDescriptionForNull(book);

            DataContext = book;
            
            /*CoverImage.Source = _imageService.DecodeBase64(book.CoverPreview);*/
        }

        private void CheckDescriptionForNull(Book book)
        {
            DescriptionTextBlock.Text = book == null ? "Нет описания" : book.Description;
        }
        
    }
}