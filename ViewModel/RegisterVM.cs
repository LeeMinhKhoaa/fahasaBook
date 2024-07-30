using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Fahasa.ViewModel
{
    public class RegisterVM
    {
        [Required]
        public string UserName { get; set; }
        [PasswordPropertyText]
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
