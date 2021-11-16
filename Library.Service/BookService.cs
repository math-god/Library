using Library.Service.Models;
using Library.Storage;
using Library.Storage.EntityModels;

namespace Library.Service
{
    public class BookService
    {
        private readonly DataBaseContext _dataBaseContext = DataBaseContextService.GetContext();
        private ImageService _imageService = new ImageService();
        private IsbnService _isbnService = new IsbnService();

        public void CreateBook(BookDto bookDto)
        {
            var inputData = new Book()
            {
                Title = bookDto.Title,
                Genre = bookDto.Genre,
                Author = bookDto.Author,
                PublicationDate = bookDto.PublicationDate,
                Description = bookDto.Description,
                Isbn = bookDto.Isbn
            };

            _dataBaseContext.Books.Add(inputData);
            _dataBaseContext.SaveChanges();
        }

        public void EditBook(string name, string genre, string author, string publicationYear,
            string description, string coverPreviewFilename, string isbn, bool isBanned, Book book)

        {
            book.Title = name;
            book.Genre = genre;
            book.Author = author;
            book.PublicationDate = publicationYear;
            book.Description = description;
            book.CoverPreview = _imageService.EncodeImage(coverPreviewFilename);
            book.Isbn = isbn;
            book.IsBanned = isBanned;

            _dataBaseContext.SaveChanges();
        }
        
        public void CreateBookByIsbn(string Isbn)
        {
            var bookDto = _isbnService.GetBook(Isbn);

            var inputData = new Book()
            {
                Title = bookDto.Title,
                Genre = bookDto.Genre,
                Author = bookDto.Author,
                PublicationDate = bookDto.PublicationDate,
                Description = bookDto.Description,
                Isbn = bookDto.Isbn
            };
            
            _dataBaseContext.Books.Add(inputData);
            _dataBaseContext.SaveChanges();
        }
    }
}