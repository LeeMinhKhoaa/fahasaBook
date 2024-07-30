using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fahasa.Models
{
    public class ChiTietHD
    {
        [Key]
        public int MaCTHD {  get; set; }
        [Required]
        [ForeignKey("HoaDon")]
        public int MaHD { get; set; }
        [Required]
        [ForeignKey("Sach")]
        public int MaSP { get; set; }
        public int quanlity {  get; set; }
        public double TongTien {  get; set; }

        public virtual HoaDon HoaDon { get; set; } = null!;

        public virtual Sach Sach { get; set; } = null!;
    }
}
