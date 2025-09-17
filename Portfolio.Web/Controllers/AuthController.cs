using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;
using Portfolio.Web.Models;

namespace Portfolio.Web.Controllers
{
    [AllowAnonymous]
    public class AuthController(PortfolioContext context) : Controller
    {
        public  IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (! ModelState.IsValid) //değerlerim boş bırkılmışsa
            {
                return View(model);
            }

            var user = context.Users.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);
            if (user is null)
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
                return View(model);
            }
            var claims = new List<Claim>        //Kişi giriş yaptığı zaman hafızada o kişiyle ilgili bilgileri tutmamıza yarar
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim("FullName",string.Join(" ",user.FirstName,user.LastName))
            };

            var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddMinutes(30),  //30 dakika oturumu açık tutacak
                IsPersistent = false ,                     //ben siteden çıkınca komple atack loginden açılacak
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            HttpContext.Session.SetString("UserName", user.UserName);

            return RedirectToAction("Index","Statistics");

           
        }
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("UserName");
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Default");

        }
    }
}
