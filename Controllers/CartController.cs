using Fahasa.Models;
using Microsoft.AspNetCore.Mvc;
using Fahasa.Helpers;
using Fahasa.ViewModel;
using Microsoft.AspNetCore.Authorization;
namespace Fahasa.Controllers
{
    public class CartController : Controller
    {
        private readonly CompanyDbContext _context;
        private readonly PaypalClient _paypal;

        public List<CartItem> Cart => HttpContext.Session.Get<List<CartItem>>(Mysettings.CART_KEY) ??
            new List<CartItem>();
        public CartController(CompanyDbContext context , PaypalClient paypal) {
            _context = context;
            _paypal = paypal;
        }

        public IActionResult Index()
        {
            ViewBag.ClientID = _paypal.ClientId;
            return View(Cart);
        }

        public IActionResult AddCart(int id , int quanlity = 1)
        {
            var cart = Cart;
            var item = cart.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                Sach sach = _context.Saches.FirstOrDefault(s => s.MaSach == id);
                CartItem cartItem = new CartItem()
                {
                    Id = id,
                    Image = sach.Hinh,
                    Name = sach.TenSach,
                    Price = sach.Gia,
                    Quanlity = quanlity,
                };
                cart.Add(cartItem);
            }
            else // đã tồn tại trong giỏ hàng
            {
                item.Quanlity += quanlity;
            }
            HttpContext.Session.Set(Mysettings.CART_KEY, cart);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveItem(int id) {
            var cart = Cart;
            var item = cart.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
               cart.Remove(item);
            }
            HttpContext.Session.Set(Mysettings.CART_KEY, cart);
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult PaymentSuccess()
        {
            var newestHoaDon = _context.HoaDons
                              .OrderByDescending(hd => hd.MaHD)
                              .FirstOrDefault();
            return View(newestHoaDon);
        }

        #region Paypal payment
        public class PaypalOrderDto
        {
            public List<string> Items { get; set; } // Đây là danh sách các data-id từ client
        }
        public class PaypalPriceDto
        {
            public float price { get; set; } // Đây là danh sách các data-id từ client
        }
        [Authorize]
        [HttpPost("/Cart/create-paypal-order")]
        public async Task<IActionResult>CreatePaypalOrder(CancellationToken cancellationToken, [FromBody] PaypalPriceDto price)
        {
            // Thông tin đơn hàng gửi qua Paypal
            var tongTien = price.price;
            var donViTienTe = "USD";
            var maDonHangThamChieu = "DH" + DateTime.Now.Ticks.ToString();
            
           
            try
            {
                var response = await _paypal.CreateOrder(tongTien.ToString(), donViTienTe, maDonHangThamChieu);

                return Ok(response);
            }
            catch (Exception ex)
            {
                var error = new { ex.GetBaseException().Message };
                return BadRequest(error);
            }
        }

        [Authorize]
        [HttpPost("/Cart/capture-paypal-order")]
        public async Task<IActionResult> CapturePaypalOrder(string orderID, CancellationToken cancellationToken, [FromBody] PaypalOrderDto Items)
        {
            try
            {
                var response = await _paypal.CaptureOrder(orderID);

                // Lưu database đơn hàng của mình
                HoaDon hd = new HoaDon();
                hd.MaHDOnline = orderID;
                hd.UserName = HttpContext.User.Identity.Name;
                hd.DiaChi = "Gò Vấp";
                hd.TongTien = 0;
                _context.HoaDons.Add(hd);
                await _context.SaveChangesAsync();
                // Lưu chi tiết hóa đơn
                var cart = Cart;
                var orderItems = Items.Items;
                orderItems.ForEach(item =>
                {
                    int id = Convert.ToInt32(item);
                    var c= cart.FirstOrDefault(x => x.Id == id);
                    if (c != null)
                    {
                        ChiTietHD chiTietHD = new ChiTietHD();
                        chiTietHD.MaSP = c.Id;
                        chiTietHD.MaHD = hd.MaHD;
                        chiTietHD.quanlity = c.Quanlity;
                        chiTietHD.TongTien = c.ThanhTien;
                        hd.TongTien += chiTietHD.TongTien;
                        _context.chiTietHDs.Add(chiTietHD);
                        // Xóa khỏi Cart
                        cart.Remove(c);
                        HttpContext.Session.Set(Mysettings.CART_KEY, cart);
                    }
                    
                });
                
                
                await _context.SaveChangesAsync();
               
                return Ok(response);
            }
            catch (Exception ex)
            {
                var error = new { ex.GetBaseException().Message };
                return BadRequest(error);
            }
        }
        #endregion

    }
}
