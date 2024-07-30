using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fahasa.Models
{
    public class HoaDon
    {
        [Key]
        public int MaHD {  get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserName { get; set; }
        public string DiaChi { get; set; }
        public double TongTien { get; set; } =0;
       
        public string MaHDOnline { get; set; }
        public ICollection<ChiTietHD> ChiTietHDs { get; set; } = new List<ChiTietHD>();

        public virtual User User { get; set; } = null!;

    }
}
