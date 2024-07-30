using System.ComponentModel.DataAnnotations;

namespace Fahasa.Models
{
    public class TheLoai
    {
        [Key]
        public int MaTL { get; set; }
        [Required]
        public string TenTL {  get; set; }

        public ICollection<Sach> Saches { get; set; } = new List<Sach>();
    }
}
