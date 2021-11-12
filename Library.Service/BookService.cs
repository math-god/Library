using Library.Storage;
using Library.Storage.EntityModels;

namespace Library.Service
{
    public class BookService
    {
        private readonly DataBaseContext _dataBaseContext = DataBaseContextService.GetContext();
        private ImageService _imageService = new ImageService();

        public void CreateBook(string name, string genre, string author, int publicationYear,
            string description, string coverPreviewFilename, string isbn)
        {
            var inputData = new Book()
            {
                Title = name,
                Genre = genre,
                Author = author,
                PublicationYear = publicationYear,
                Description = description,
                CoverPreview = _imageService.EncodeImage(coverPreviewFilename),
                Isbn = isbn
            };

            _dataBaseContext.Books.Add(inputData);
            _dataBaseContext.SaveChanges();
        }

        public void EditBook(string name, string genre, string author, int publicationYear,
            string description, string coverPreviewFilename, string isbn, bool isBanned, Book book)

        {
            book.Title = name;
            book.Genre = genre;
            book.Author = author;
            book.PublicationYear = publicationYear;
            book.Description = description;
            book.CoverPreview = _imageService.EncodeImage(coverPreviewFilename);
            book.Isbn = isbn;
            book.IsBanned = isBanned;

            _dataBaseContext.SaveChanges();
        }
    }
}