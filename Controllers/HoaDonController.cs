using Fahasa.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fahasa.Controllers
{
    public class HoaDonController : Controller
    {
        private readonly CompanyDbContext _context;

        public HoaDonController(CompanyDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var companyDbContext = _context.HoaDons;
            return View(await companyDbContext.ToListAsync());
        }
        public IActionResult Details(int id) {
            HoaDon hd = _context.HoaDons.Include(h => h.ChiTietHDs).ThenInclude(cthd => cthd.Sach)
                                .SingleOrDefault(h => h.MaHD == id);
           
            return View(hd);
        }
    }
}
