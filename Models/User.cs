using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Fahasa.Models
{
    public class User
    {
        [Key]
        public string UserName { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }

        public string RandomKey { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Role { get; set; } = "Customer";
        public ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
    }
}
