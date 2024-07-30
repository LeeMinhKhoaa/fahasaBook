using Fahasa.Helpers;
using Fahasa.Models;
using Fahasa.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Fahasa.ViewComponet
{
    public class CartViewComponent : ViewComponent
    {
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var count = HttpContext.Session.Get<List<CartItem>>(Mysettings.CART_KEY)
                ?? new List<CartItem>();
            return View("Default", new CartModal
            {
                Quanlity = count.Sum(x => x.Quanlity),
                Total = count.Sum(x => x.ThanhTien),
            });


        }
    }
}
