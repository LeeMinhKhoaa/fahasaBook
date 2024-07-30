using System.Diagnostics;

namespace Fahasa.Models
{
    public class DbInitializer
    {
        public static void Initialize(CompanyDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Saches.Any())
            {
                return;   // DB has been seeded
            }
            var tl = new TheLoai[]
            {
                new TheLoai{TenTL="Văn học"},
                new TheLoai{TenTL="Kinh tế"},
                new TheLoai{TenTL="Ngoại Ngữ"},
            };
            foreach (TheLoai e in tl)
            {
                context.TheLoais.Add(e);
            }
            context.SaveChanges();
            var saches = new Sach[]
            {
                new Sach{TenSach="Đắc Nhân Tâm",TacGia="Dale Carnegie",Hinh="/img/dacnhantam.jpg",Gia=150,MoTa="Sách ",SoLuong=1,TenNXB="Thế Giới",MaTL=1},
                new Sach{TenSach="Dám Bị Ghét",TacGia="Kishimi Ichiro",Hinh="/img/dambighet.jpg",Gia=95,MoTa="Bạn bất hạnh không phải do quá khứ và hoàn cảnh",SoLuong=5,TenNXB="Hà Nội",MaTL=2},
                new Sach{TenSach="Định luật MURPHY",TacGia="Dale Carnegie",Hinh="/img/dinhluatmurphy.jpg",Gia=14,MoTa="Sách hay ",SoLuong=20,TenNXB="Công Thương",MaTL=1},
                new Sach{TenSach="Đánh thức bộ não",TacGia="Daniel G. Amen, MD",Hinh="/img/danhthucbonao.jpg",Gia=18,MoTa="Sách hay ",SoLuong=6,TenNXB="Hồng Đức",MaTL=2},
            };
            foreach (Sach e in saches)
            {
                context.Saches.Add(e);
            }
            context.SaveChanges();

            var users = new User[]
            {
                new User{UserName="LeKhoa",Password="37e92d44876fe86b0ff6b0dfc2a92188",Email="leminhkhoa5241@gmail.com",RandomKey="36I6N",Role="Customer"},
                new User{UserName="admin1",Password="e27536984f273ae32a0b065250ecd66b",Email="leminhkhoa5241@gmail.com",RandomKey="oLtta",Role="Admin"},
            };
            foreach (User e in users)
            {
                context.Users.Add(e);
            }
            context.SaveChanges();
        }
    }
}
