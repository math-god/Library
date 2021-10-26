using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Library.StorageServices;

namespace Library.Storage.EntityModels
{
    [Table("Users")]
    public class Reader
    {
        private string _password;

        public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string Surname { get; set; }

        [Required] public string MiddleName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Password
        {
            get => CryptographyService.EncodeDecrypt(_password);
            set => _password = CryptographyService.EncodeDecrypt(value);
        }

        public string Rating { get; set; }

        public bool IsBanned { get; set; }

        public string BanButtonInfo { get; set; }
    }
}