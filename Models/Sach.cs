using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace Fahasa.Models
{
    public class Sach
    {
        [Key]
        public int MaSach { get; set; }
        [Required]
        public string TenSach { get; set; }
        public string Hinh { get; set; }
        public int SoLuong { get; set; }
        public string MoTa { get; set; }
        public string TacGia { get; set; }
        public int Gia { get; set; }
        
        // Khóa ngoại nhà xuất bản
        //[ForeignKey("NhaXuatBan")]
        public string TenNXB { get; set; }
       // public virtual NhaXuatBan NhaXuatBan { get; set; } = null!;
        // Khóa ngoại thể loại

        [ForeignKey("TheLoai")]
        public int MaTL { get; set; }

        public virtual TheLoai TheLoai { get; set; } = null!;

        public ICollection<ChiTietHD> ChiTietHDs { get; set; } = new List<ChiTietHD>();

    }
}
