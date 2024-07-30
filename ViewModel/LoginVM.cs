using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Fahasa.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Không được bỏ trống")]
        public string UserName { get; set; }
        [PasswordPropertyText]
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string Password { get; set; }
    }
}
