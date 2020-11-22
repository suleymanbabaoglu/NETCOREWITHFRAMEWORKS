using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SAMPLE.ViewModels
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
