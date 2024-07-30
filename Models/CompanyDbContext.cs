using Fahasa.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Fahasa.Models
{
    public class CompanyDbContext:DbContext
    {
        public DbSet<Sach> Saches { get; set; }
        //public DbSet<NhaXuatBan> NhaXuatBans { get; set; }

        public DbSet<TheLoai> TheLoais { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHD> chiTietHDs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies(); // Bật lazy loading
            //base.OnConfiguring(optionsBuilder);
        }

        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }


    }
}
