using Library.StorageServices;

namespace Library.Storage.EntityModels
{
    public class Reader : Librarian
    {
        public string Rating { get; set; }
        
        public bool IsBanned { get; set; }
        
        public string BanButtonInfo { get; set; }
    }
}