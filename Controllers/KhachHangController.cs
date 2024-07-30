using EComereceMVC.Helpers;
using Fahasa.Models;
using Fahasa.ViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace Fahasa.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly CompanyDbContext _context;

        public KhachHangController(CompanyDbContext context)
        {
            _context = context;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                User ng = new User();
                ng.UserName = registerVM.UserName;
                ng.RandomKey = MyUtil.GenerateRandomKey();
                ng.Password = registerVM.Password.ToMd5Hash(ng.RandomKey);
                ng.Email = registerVM.Email;
                
                _context.Users.Add(ng);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else { 
                return View(registerVM);
            }
        }
        public IActionResult Login(string? ReturnUrl) {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model, string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            if (ModelState.IsValid)
            {
                var kh = _context.Users.SingleOrDefault(kh => kh.UserName == model.UserName);
                if (kh != null)
                {
                    
                        if (kh.Password == model.Password.ToMd5Hash(kh.RandomKey))
                        {
                            var claims = new List<Claim>()
                            {
                                new Claim(ClaimTypes.Email,kh.Email),
                                new Claim(ClaimTypes.Name,kh.UserName),
                                new Claim(ClaimTypes.Role,kh.Role)
                            };
                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                            await HttpContext.SignInAsync(claimsPrincipal);

                            if (Url.IsLocalUrl(ReturnUrl))
                            {
                                return Redirect(ReturnUrl);
                            }
                            else
                            {
                                return Redirect("/");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("loi", "Sai mật khẩu");
                        }
                    
                }
                else
                {
                    ModelState.AddModelError("loi", "Không tồn tại khách hàng này");
                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
