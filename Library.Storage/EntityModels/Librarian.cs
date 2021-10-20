using System.ComponentModel.DataAnnotations;
using Library.StorageServices;

namespace Library.Storage.EntityModels
{
    public class Librarian : EntityModelsService
    {
        private string _password;
        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
        
        [Required]
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password 
        { 
            get => CryptographyService.EncodeDecrypt(_password);
            set => _password = CryptographyService.EncodeDecrypt(value); 
        }
    }
}