using System.ComponentModel.DataAnnotations;

namespace Library.Storage.EntityModels
{
    public class Book
    {
        public int Id { get; set; }
        [Required] public string Title { get; set; }
        public string Genre { get; set; }
        [Required] public string Author { get; set; }
        [Required] public string PublicationDate { get; set; }
        public string Description { get; set; }
        public string CoverPreview { get; set; }
        public string Isbn { get; set; }
        public bool IsBanned { get; set; }
        public int Penalty { get; set; }
        public int Amount { get; set; }
    }
}