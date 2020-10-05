using System.ComponentModel.DataAnnotations;

namespace COREVUE.ViewModels
{
    public class PasswordModel
    {
        public int UserId { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password doesn't match"), Required]
        public string RePassword { get; set; }
    }
}
