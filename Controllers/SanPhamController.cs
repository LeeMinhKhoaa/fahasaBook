using Fahasa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace Fahasa.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly CompanyDbContext  _context;

        public SanPhamController(CompanyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int trang = 1,string? sort = null,int? Loai = null)
        {

            List<Sach> saches;
            if (Loai != null)
            { 
                saches = _context.Saches.Where(x => x.MaTL == Loai).ToList();
            }
            else
            {
                saches = _context.Saches.ToList();
            }
            int tongTrang =(int) Math.Ceiling((double) saches.Count / 4);
            int soLuongBoQua = (trang - 1) * 4;
            saches = saches.Skip(soLuongBoQua).Take(4).ToList();
            ViewBag.tongTrang = tongTrang;
            ViewBag.trang = trang;
            if (sort != null) {
                if(sort.Equals("increase"))
                    saches = saches.OrderBy(s => s.Gia).ToList();
                else
                {
                    saches.OrderByDescending(s => s.Gia).ToList();
                }
            }
            return View(saches);
        }
        public async Task<IActionResult> Details(int? id) {


            var sach = await _context.Saches
               .Include(e => e.TheLoai)
               .FirstOrDefaultAsync(m => m.MaSach == id);
            if (sach != null)
            {
                
            }
            return View(sach);
        }
    }
}
