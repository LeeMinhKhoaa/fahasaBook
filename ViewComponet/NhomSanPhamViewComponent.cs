using Fahasa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fahasa.ViewComponet
{
    public class NhomSanPhamViewComponent: ViewComponent
    {
        private readonly CompanyDbContext _context;
        public NhomSanPhamViewComponent(CompanyDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var productGroups = await _context.TheLoais.ToListAsync();

            return View(productGroups);
        }
    }
}
